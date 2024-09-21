using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Lab_4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static int size;
        private static double[,] matrix;
        public MainWindow()
        {
            InitializeComponent();
        }


        private void changeArrSize_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                /* Очищаем Grid */
                arrA_Grid.Children.Clear();
                arrA_Grid.ColumnDefinitions.Clear();
                arrA_Grid.RowDefinitions.Clear();


                /* Добавялем первый дочерний элемент в Grid*/
                Label arrName_Label = new Label()
                {
                    Content = "Массив A:",
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center
                };

                ColumnDefinition columnDefinition1 = new ColumnDefinition()
                {
                    Width = new GridLength(1, GridUnitType.Star)
                };

                RowDefinition rowDefinition1 = new RowDefinition()
                {
                    Height = new GridLength(1, GridUnitType.Star)
                };
                arrA_Grid.ColumnDefinitions.Add(columnDefinition1);
                arrA_Grid.RowDefinitions.Add(rowDefinition1);

                Grid.SetRow(arrName_Label, 0);
                Grid.SetColumn(arrName_Label, 0);
                arrA_Grid.Children.Add(arrName_Label);


                size = int.Parse(arrSize_TextBox.Text);

                /* Добавляем первый ряд в таблице */
                for (int i = 0; i < size; i++)
                {
                    Label index_Label = new Label()
                    {
                        Content = "i = " + (i + 1).ToString(),
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        VerticalContentAlignment = VerticalAlignment.Center
                    };

                    Border border = new Border()
                    {
                        BorderThickness = new Thickness(1, 0, 0, 0),
                        BorderBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0))
                    };

                    border.Child = index_Label;

                    ColumnDefinition columnDefinition = new ColumnDefinition()
                    {
                        Width = new GridLength(1, GridUnitType.Star)
                    };
                    arrA_Grid.ColumnDefinitions.Add(columnDefinition);

                    Grid.SetRow(border, 0);
                    Grid.SetColumn(border, i + 1);
                    arrA_Grid.Children.Add(border);
                }


                /* Добавляем первую колонну в таблице */
                for (int i = 0; i < size; i++)
                {
                    Label index_Label = new Label()
                    {
                        Content = "i = " + (i + 1).ToString(),
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        VerticalContentAlignment = VerticalAlignment.Center
                    };

                    Border border = new Border()
                    {
                        BorderThickness = new Thickness(0, 1, 0, 0),
                        BorderBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0))
                    };

                    border.Child = index_Label;

                    RowDefinition rowDefinition = new RowDefinition()
                    {
                        Height = new GridLength(1, GridUnitType.Star)
                    };
                    arrA_Grid.RowDefinitions.Add(rowDefinition);

                    Grid.SetRow(border, i + 1);
                    Grid.SetColumn(border, 0);
                    arrA_Grid.Children.Add(border);
                }


                /* Добавляем все остальные ячейки */
                for (int i = 1; i < size + 1; i++)
                {
                    for (int j = 1; j < size + 1; j++)
                    {
                        TextBox textBox = new TextBox()
                        {
                            HorizontalContentAlignment = HorizontalAlignment.Center,
                            VerticalContentAlignment = VerticalAlignment.Center,
                            BorderThickness = new Thickness(0)
                        };

                        Border border = new Border()
                        {
                            BorderThickness = new Thickness(1, 1, 0, 0),
                            BorderBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0))
                        };

                        border.Child = textBox;

                        RowDefinition rowDefinition = new RowDefinition()
                        {
                            Height = new GridLength(1, GridUnitType.Star)
                        };

                        Grid.SetRow(border, i);
                        Grid.SetColumn(border, j);
                        arrA_Grid.Children.Add(border);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }


        private void Result_Button_Click(object sender, RoutedEventArgs e)
        {
            /* Очищаем Grid */
            arrB_Grid.Children.Clear();
            arrB_Grid.ColumnDefinitions.Clear();
            arrB_Grid.RowDefinitions.Clear();
            
            /* Вставляем в первую ячейку название массива */
            Label label1 = new Label()
            {
                Content = "Массив B:",
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center
            };

            Border border1 = new Border()
            {
                BorderThickness = new Thickness(0),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0))
            };

            border1.Child = label1;

            RowDefinition rowDefinition1 = new RowDefinition()
            {
                Height = new GridLength(1, GridUnitType.Star)
            };
            arrB_Grid.RowDefinitions.Add(rowDefinition1);

            Grid.SetRow(border1, 0);
            Grid.SetColumn(border1, 0);
            arrB_Grid.Children.Add(border1);


            // Заполняем матрицу заданными значениями
            FillMatrix();


            // Заполняем Массив B:
            for (int i = 0; i < size; i++)
            {
                Label label = new Label()
                {
                    Content = GetValue(i),
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center
                };

                Border border = new Border()
                {
                    BorderThickness = new Thickness(0, 1, 0, 0),
                    BorderBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0))
                };

                border.Child = label;

                RowDefinition rowDefinition = new RowDefinition()
                {
                    Height = new GridLength(1, GridUnitType.Star)
                };
                arrB_Grid.RowDefinitions.Add(rowDefinition);

                Grid.SetRow(border, i + 1);
                Grid.SetColumn(border, 0);
                arrB_Grid.Children.Add(border);
            }
        }


        private void FillMatrix()
        {
            matrix = new double[size, size];    // Инициализируем квадратную матрицу 
            int k = 0;
            int m = 0;


            /* Обходим весь Grid и заполняем матрицу */
            for (int i = 0; i < (size + 1) * (size + 1); i++)
            {
                // Определяем ячейку Grid: работаем, если ячейка - TextBox
                if (arrA_Grid.Children[i] is Border border && border.Child is TextBox textBox)
                {
                    // Если ряд прошли, переходим на следующий
                    if (m == size)
                    {
                        k++;
                        m = 0;
                    }
                    try
                    {
                        matrix[k, m] = double.Parse(textBox.Text);
                        m++;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }

                }
            }
        }


        private string GetValue(int row)
        {
            // Проверка условию, что строка в матрице 
            for (int i = 0; i < size - 1; i++)
            {
                if (matrix[row, i] <= matrix[row, i + 1])
                {
                    return "0";
                }
            }

            return "1";
        }
    }
}
