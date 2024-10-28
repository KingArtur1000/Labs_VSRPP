using System;
using System.Windows;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;


namespace Lab_13
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


        private void Result_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double x = double.Parse(x_TextBox.Text);
                double y = double.Parse(y_TextBox.Text);
                double z = double.Parse(z_TextBox.Text);
                double h = double.Parse(h_TextBox.Text);

                double resultNumerator = 8 + Math.Pow(Math.Abs(x - y), 2) + 1;

                double resultDenominator = Math.Pow(x, 2) + Math.Pow(y, 2) + 2;

                double PowResultNumerator = Math.Pow(resultNumerator, 2 / 3);

                double resultExp = Math.Pow(Math.E, Math.Abs(x - y));

                double resultRight = Math.Pow(Math.Pow(Math.Tan(z), 2) + 1, x);

                double resultFinal = PowResultNumerator / resultDenominator - (resultExp * resultRight);


                CreateGraphic(x, y, z, h);


                Result_TextBlock.Text = "\tЛабораторная работа №8 Борсук-Дмитриев (Вариант 2)\n";
                Result_TextBlock.Text += "X = " + x.ToString() + '\n';
                Result_TextBlock.Text += "Y = " + y.ToString() + '\n';
                Result_TextBlock.Text += "Z = " + z.ToString() + '\n';
                Result_TextBlock.Text += "H = " + h.ToString() + '\n';

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }


        private void CreateGraphic(double x, double y, double z, double h)
        {
            PlotModel MyModel = new PlotModel { Title = "Lab_8 График" };

            // График 1: e^(x-y)
            FunctionSeries expSeries = new FunctionSeries(Math.Exp, Math.Abs(x - y), (x + h) - y, 0.1, "e^(x-y)")
            {
                Color = OxyColors.Red
            };
            MyModel.Series.Add(expSeries);


            // График 2: tg^2(z)
            FunctionSeries tanSquaredSeries = new FunctionSeries(Math.Tan, Math.Pow(z, 2), Math.Pow((z + h), 2), 0.1, "tg^2(z)")
            {
                Color = OxyColors.Blue
            };
            MyModel.Series.Add(tanSquaredSeries);


            MyModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "x" });
            MyModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "y" });


            // Добавляем легенду
            MyModel.Legends.Add(new OxyPlot.Legends.Legend
            {
                LegendPosition = OxyPlot.Legends.LegendPosition.RightTop,
                LegendPlacement = OxyPlot.Legends.LegendPlacement.Inside
            });

            Graphic_PlotView.Model = MyModel;
        }


        private void ClearGraph()
        {
            Graphic_PlotView.Model = new PlotModel();
        }


        private void ClearInputs()
        {
            x_TextBox.Clear();
            y_TextBox.Clear();
            z_TextBox.Clear();
            h_TextBox.Clear();
        }

        private void ClearAllButton_Click(object sender, RoutedEventArgs e)
        {
            ClearGraph();
            ClearInputs();
        }

        private void ClearGraphButton_Click(object sender, RoutedEventArgs e)
        {
            ClearGraph();
        }


        private void ClearTextBoxButton_Click(object sender, RoutedEventArgs e)
        {
            ClearInputs();
        }
    }
}
