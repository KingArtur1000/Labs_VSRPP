using System.Windows;
using System.Windows.Controls;
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
    }
}
