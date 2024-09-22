using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace Lab_6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<Product> products;

        public MainWindow()
        {
            InitializeComponent();

            Date_TextBox.Text = DateTime.Now.ToString("d");
        }


        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = products.Count;
                string name = Name_TextBox.Text;
                int amount = int.Parse(Amount_TextBox.Text);
                double price = double.Parse(Price_TextBox.Text);
                string date = Date_TextBox.Text;

                Product product = new Product(id, name, amount, price, date)
                {
                    Id = id,
                    Name = name,
                    Amount = amount,
                    Price = price,
                    Date = date
                };

                int numberOfString = Products_ListBox.Items.Count + 1;
                TextBlock textBlock = new TextBlock()
                {
                    Text = numberOfString.ToString() + ") " + product.getInfo()
                };

                Products_ListBox.Items.Add(textBlock);

                products.Add(product);

                SortProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                products.RemoveAt(Products_ListBox.SelectedIndex);
                Products_ListBox.Items.Remove(Products_ListBox.SelectedItem);

                SortProducts();
            }
            catch (Exception)
            {
                MessageBox.Show("Выберите запись для удаления!");
            }
        }


        private async void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            await JsonDataService.SaveProductsAsync(products);
            MessageBox.Show("Изменения успешно сохранены!");
        }


        private async void Products_ListBox_Loaded(object sender, RoutedEventArgs e)
        {
            products = await JsonDataService.GetProductsAsync();

            SortProducts();
        }

        private void Sort_Button_Click(object sender, RoutedEventArgs e)
        {
            Products_ListBox.Items.Clear();

            // Текущая дата для сравнения
            DateTime currentDate = DateTime.Now;

            IEnumerable<Product> IEproducts = products
                .Where(product => (currentDate - ConvertStringToDate(product.Date)).Days > 30  // Фильтрация по сроку хранения и стоимости
                                    && ( (product.Price * product.Amount) > 1000000) )
                .OrderBy(product => product.Name); // Сортировка по алфавиту

            products = IEproducts.ToList();

            foreach (Product product in products)
            {
                int numberOfString = Products_ListBox.Items.Count + 1;

                TextBlock textBlock = new TextBlock()
                {
                    Text = numberOfString.ToString() + ") " + product.getInfo()
                };

                Products_ListBox.Items.Add(textBlock);
            }
        }


        private void SortProducts()
        {
            Products_ListBox.Items.Clear();

            IEnumerable<Product> IEproducts = products.OrderBy(product => product.Name);
            products = IEproducts.ToList();

            foreach (Product product in products)
            {
                int numberOfString = Products_ListBox.Items.Count + 1;

                TextBlock textBlock = new TextBlock()
                {
                    Text = numberOfString.ToString() + ") " + product.getInfo()
                };

                Products_ListBox.Items.Add(textBlock);
            }
        }


        private DateTime ConvertStringToDate(string dateString)
        {
            string format = "dd.MM.yyyy"; // формат даты

            DateTime date = DateTime.ParseExact(dateString, format, null);

            return date;
        }
    }
}
