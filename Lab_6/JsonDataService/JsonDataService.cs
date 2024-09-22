using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows;


namespace Lab_6
{
    public static class JsonDataService
    {
        private static readonly string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string productsFilePath = Path.Combine(baseDirectory, @"Data\Products.json");

        public static Task<List<Product>> GetProductsAsync()
        {
            return Task.Run(() =>
            {
                if (!File.Exists(productsFilePath))
                {
                    MessageBox.Show("Файл с БД не найден по пути: " + productsFilePath);
                    return new List<Product>();
                }
                string json = File.ReadAllText(productsFilePath);
                return JsonConvert.DeserializeObject<List<Product>>(json);
            });
        }


        public static Task SaveProductsAsync(List<Product> clients)
        {
            return Task.Run(() =>
            {
                string json = JsonConvert.SerializeObject(clients, Formatting.Indented);
                File.WriteAllText(productsFilePath, json);
            });
        }
    }
}
