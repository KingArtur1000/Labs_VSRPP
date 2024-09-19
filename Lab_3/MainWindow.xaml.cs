using System;
using System.Windows;


namespace Lab_3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            n_TextBox.TextChanged += N_TextBox_TextChanged;
            Calculate_N();
        }

        private void N_TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            Calculate_N();
        }


        private void Calculate_N()
        {
            try
            {
                double x1 = double.Parse(x1_TextBox.Text);
                double x2 = double.Parse(x2_TextBox.Text);
                double n = double.Parse(n_TextBox.Text);
                double h = (x2 - x1) / n;

                h_TextBox.Text = h.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }


        private static double Factorial(double x)
        {
            return (x == 0) ? 1 : x * Factorial(x - 1);
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double x1 = double.Parse(x1_TextBox.Text);
                double x2 = double.Parse(x2_TextBox.Text);
                double n = double.Parse(n_TextBox.Text);
                double h = double.Parse(h_TextBox.Text);

                Result_TextBlock.Text = "\tЛабораторная работа №3 Борсук-Дмитриев (Вариант 2)\n";
                Result_TextBlock.Text += "X1 = " + x1.ToString() + '\n';
                Result_TextBlock.Text += "X2 = " + x2.ToString() + '\n';
                Result_TextBlock.Text += "N = " + n.ToString() + '\n';
                Result_TextBlock.Text += "H = " + h.ToString() + "\n\n";

                while (x1 <= x2)
                {
                    double s = 0;
                    for (int i = 0; i <= n; i++)
                    {
                        s += Math.Pow(x1, 2 * i) / Factorial(2 * i);
                    }

                    double y = ( Math.Exp(x1) + Math.Exp(-x1) ) / 2;

                    Result_TextBlock.Text += "\tПри x = " + x1.ToString() + ":\n";
                    Result_TextBlock.Text += "S(x) = " + s.ToString() + ":\n";
                    Result_TextBlock.Text += "Y(x) = " + y.ToString() + ":\n\n";

                    x1 += h;
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }


        }
    }
}
