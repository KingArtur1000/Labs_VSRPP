namespace Lab_6
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public string Date { get; set; }


        public Product(
            int id,
            string name,
            int amount,
            double price,
            string date)
        {
            Id = id;
            Name = name;
            Amount = amount;
            Price = price;
            Date = date;
        }


        public string getInfo()
        {
            string name = "Название: " + Name + "; ";
            string amount = "Кол-во: " + Amount + "; ";
            string price = "Цена за 1шт.: " + Price + "; ";
            string date = "Дата добавления: " + Date;

            return name + amount + price + date;
        }
    }
}