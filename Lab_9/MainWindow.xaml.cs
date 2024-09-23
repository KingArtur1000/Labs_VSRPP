using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Lab_9
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


        private enum Functions
        {
            SH = 1,
            X_SQUARE,
            EXP_X
        }


        private double CalculateFX(int choice, double x)
        {
            switch ((Functions)choice)
            {
                case Functions.SH:
                    return Math.Sinh(x);
                case Functions.X_SQUARE:
                    return Math.Pow(x, 2);
                case Functions.EXP_X:
                    return Math.Pow(Math.E, 2);
                default:
                    return 1;
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int choice = 0;

            if ((bool)rBtn1.IsChecked) choice = 1;
            else if ((bool)rBtn2.IsChecked) choice = 2;
            else if ((bool)rBtn3.IsChecked) choice = 3;


            try
            {
                double x = double.Parse(x_TextBox.Text);
                double y = double.Parse(y_TextBox.Text);
                double fx = CalculateFX(choice, x);
                double result = 0;

                if (x / y > 0)
                {
                    result = Math.Log(fx) + Math.Pow(Math.Pow(fx, 2) + y, 3);
                }
                else if (x / y < 0)
                {
                    result = Math.Log(Math.Abs(fx / y)) + Math.Pow(fx + y, 3);
                }
                else if (x == 0)
                {
                    result = Math.Pow(Math.Pow(fx, 2) + y, 3);
                }

                Result_TextBlock.Text = "\tЛабораторная работа №2 Борсук-Дмитриев (Вариант 2)\n";
                Result_TextBlock.Text += "X = " + x.ToString() + '\n';
                Result_TextBlock.Text += "Y = " + y.ToString() + '\n';
                Result_TextBlock.Text += "\tРезультат  b = " + result.ToString() + '\n';
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void PaintButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
