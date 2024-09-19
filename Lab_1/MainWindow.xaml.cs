using System;
using System.Windows;


namespace Lab_1
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double x = double.Parse(x_TextBox.Text);
                double y = double.Parse(y_TextBox.Text);
                double z = double.Parse(z_TextBox.Text);

                double resultNumerator = 8 + Math.Pow(Math.Abs(x - y), 2) + 1;

                double resultDenominator = Math.Pow(x, 2) + Math.Pow(y, 2) + 2;

                double PowResultNumerator = Math.Pow(resultNumerator, 2 / 3);

                const double EXP = 2.71828;

                double resultExp = Math.Pow(EXP, Math.Abs(x - y));

                double resultRight = Math.Pow(Math.Pow(Math.Tan(z), 2) + 1, x);

                double resultFinal = PowResultNumerator / resultDenominator - (resultExp * resultRight);

                Result_TextBlock.Text += "\tЛабораторная работа №1 Борсук-Дмитриев (Вариант 2)\n";
                Result_TextBlock.Text += "X = " + x.ToString() + '\n';
                Result_TextBlock.Text += "Y = " + y.ToString() + '\n';
                Result_TextBlock.Text += "Z = " + z.ToString() + '\n';
                Result_TextBlock.Text += "\tРезультат  U = " + resultFinal.ToString() + '\n';

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }


        }
    }
}
