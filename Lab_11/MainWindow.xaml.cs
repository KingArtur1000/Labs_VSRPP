using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;


namespace Lab_11
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private Point startPoint;
        private UIElement currentShape;
        private string currentTool = "Line";


        private void Circle_Button_Click(object sender, RoutedEventArgs e)
        {
            Ellipse circle = new Ellipse()
            {
                Width = 150,
                Height = 150,
                Fill = new SolidColorBrush(Color.FromRgb(173, 216, 230))
            };

            Grid.SetColumn(circle, 0);
            Grid.SetRow(circle, 2);
            Shape_Grid.Children.Add(circle);

            MessageBox.Show("Круг нарисован!");
        }


        private void Rectangle_Button_Click(object sender, RoutedEventArgs e)
        {
            Rectangle rectangle = new Rectangle()
            {
                Width = 150,
                Height = 100,
                Fill = new SolidColorBrush(Color.FromRgb(181, 133, 230))
            };

            Grid.SetColumn(rectangle, 1);
            Grid.SetRow(rectangle, 2);
            Shape_Grid.Children.Add(rectangle);

            MessageBox.Show("Прямоугольник нарисован!");
        }


        private void Square_Button_Click(object sender, RoutedEventArgs e)
        {
            Rectangle square = new Rectangle()
            {
                Width = 150,
                Height = 150,
                Fill = new SolidColorBrush(Color.FromRgb(230, 76, 107))
            };

            Grid.SetColumn(square, 2);
            Grid.SetRow(square, 2);
            Shape_Grid.Children.Add(square);

            MessageBox.Show("Квадрат нарисован!");
        }


        private void Triangle_Button_Click(object sender, RoutedEventArgs e)
        {
            PointCollection points = new PointCollection();
            points.Add(new Point(0, 150));
            points.Add(new Point(100, 0));
            points.Add(new Point(200, 150));
            points.Add(new Point(0, 150));


            Polygon triangle = new Polygon()
            {
                Points = points,
                Fill = new SolidColorBrush(Color.FromRgb(185, 230, 79)),
                Stretch = Stretch.Uniform,
                Margin = new Thickness(30)
            };

            Grid.SetColumn(triangle, 3);
            Grid.SetRow(triangle, 2);
            Shape_Grid.Children.Add(triangle);

            MessageBox.Show("Треугольник нарисован!");
        }


        private void Line_Button_Click(object sender, RoutedEventArgs e)
        {
            Line line = new Line()
            {
                X1 = 10,
                Y1 = 10,

                X2 = 100,
                Y2 = 50,

                Stretch = Stretch.Uniform,
                Margin = new Thickness(30),
                Stroke = Brushes.Red
            };

            Grid.SetRow(line, 2);
            Grid.SetColumn(line, 0);
            Line_Grid.Children.Add(line);

            MessageBox.Show("Линия нарисована!");
        }


        private void Ellipse_Button_Click(object sender, RoutedEventArgs e)
        {
            Ellipse ellipse = new Ellipse()
            {
                Width = 150,
                Height = 100,
                Fill = new SolidColorBrush(Color.FromRgb(173, 216, 230))
            };

            Grid.SetColumn(ellipse, 1);
            Grid.SetRow(ellipse, 2);
            Line_Grid.Children.Add(ellipse);

            MessageBox.Show("Эллипс нарисован!");
        }


        private void Path_Button_Click(object sender, RoutedEventArgs e)
        {
            Path path = new Path()
            {
                Data = Geometry.Parse("M 1 4 L 4 8 L 8 0 L 8 4 L 4 10 L 0 6"),
                Fill = Brushes.LightGreen,
                Stretch = Stretch.Uniform,
                Margin = new Thickness(30)
            };

            Grid.SetColumn(path, 2);
            Grid.SetRow(path, 2);
            Line_Grid.Children.Add(path);

            MessageBox.Show("Галочка нарисована! :)");
        }





        private void DrawingCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(drawingCanvas);
            switch (currentTool)
            {
                case "Линия":
                    currentShape = new Line()
                    {
                        Stroke = Brushes.Black,
                        X1 = startPoint.X,
                        Y1 = startPoint.Y,
                        X2 = startPoint.X,
                        Y2 = startPoint.Y
                    };
                    break;
                case "Прямоугольник":
                    currentShape = new Rectangle()
                    {
                        StrokeThickness = 2,
                        Stroke = Brushes.Red,
                        Fill = Brushes.Blue
                    };
                    break;
                case "Эллипс":
                    currentShape = new Ellipse()
                    {
                        Fill = Brushes.Purple,
                        StrokeThickness = 2,
                        Stroke = Brushes.Orange
                    };
                    break;
            }
            drawingCanvas.Children.Add(currentShape);
        }

        private void DrawingCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            currentShape = null;
        }

        private void DrawingCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && currentShape != null)
            {
                Point currentPoint = e.GetPosition(drawingCanvas);
                switch (currentTool)
                {
                    case "Линия":
                        Line line = (Line)currentShape;
                        line.X2 = currentPoint.X;
                        line.Y2 = currentPoint.Y;
                        break;
                    case "Прямоугольник":
                    case "Эллипс":
                        double width = Math.Abs(currentPoint.X - startPoint.X);
                        double height = Math.Abs(currentPoint.Y - startPoint.Y);
                        double left = Math.Min(startPoint.X, currentPoint.X);
                        double top = Math.Min(startPoint.Y, currentPoint.Y);
                        Shape shape = (Shape)currentShape;
                        shape.Width = width;
                        shape.Height = height;
                        Canvas.SetLeft(shape, left);
                        Canvas.SetTop(shape, top);
                        break;
                }
            }
        }

        private void Tool_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton != null)
            {
                currentTool = radioButton.Content.ToString();
            }
        }
    }
}
