using System;
using System.Windows;
using OxyPlot;
using OxyPlot.Series;


namespace Lab_8
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

                PlotModel MyModel = new PlotModel { Title = "Lab_8 График" };
                MyModel.Series.Add(new FunctionSeries(Math.Exp, Math.Abs(x - y), (x + h) - y, 0.1, "e^(x-y)"));
                MyModel.Series.Add(new FunctionSeries(Math.Tan, Math.Pow(z, 2), Math.Pow((z + h), 2), 0.1, "tg^2(z)"));
                //MyModel.Series.Add(new FunctionSeries(Math.Sqrt, Math.Pow(Math.Abs(x-y), 2), Math.Pow(Math.Abs(x + h - y), 2), 0.1, "|x-y|^2"));

                Graphic_PlotView.Model = MyModel;

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
    }
}
