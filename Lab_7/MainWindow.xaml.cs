using System;
using System.Windows;


namespace Lab_7
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
            Calculate_H();
        }

        private enum FUNCTIONS
        {
            X_2 = 0,
            SIN,
            COS,
            SQRT,
            EXP
        }

        private void N_TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            Calculate_H();
        }


        private void Calculate_H()
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

                    double y = 0;

                    switch ((FUNCTIONS)Functions_ComboBox.SelectedIndex)
                    {
                        case FUNCTIONS.X_2: y = Functions.Function1(x1); break;
                        case FUNCTIONS.SIN: y = Functions.Function2(x1); break;
                        case FUNCTIONS.COS: y = Functions.Function3(x1); break;
                        case FUNCTIONS.SQRT: y = Functions.Function4(x1); break;
                        case FUNCTIONS.EXP: y = Functions.Function5(x1); break;
                    }

                    Result_TextBlock.Text += "\tПри x = " + x1.ToString() + ":\n";
                    Result_TextBlock.Text += "\ty(x) = " + y.ToString() + "\n";

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
