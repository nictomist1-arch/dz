using System;

internal class Program
{
    private class Product
    {
        public string Name;
        public int Price;

        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }

    private class Products
    {
        private readonly List<Product> _items = new();

        public void Add(string name, string priceText)
        {
            if (name.Length == 0)
                throw new ArgumentException("Название товара пустое.");

            if (priceText.Contains(','))
                throw new FormatException("Цена не может быть дробной (введите целое число).");

            if (!int.TryParse(priceText, out int price))
                throw new FormatException("Цена введена строкой/не числом (введите целое число).");

            if (price < 0)
                throw new ArgumentOutOfRangeException("Цена не может быть отрицательной.");

            _items.Add(new Product(name, price));
        }

        public void Print()
        {
            Console.WriteLine("Список товаров:");
            int i = 1;
            foreach (var item in _items)
                Console.WriteLine($"{i++}) {item.Name} — {item.Price} руб.");
        }
    }

    static void Main(string[] args)
    {
        var products = new Products();
        Console.WriteLine();
        Console.WriteLine("Добавление товаров.");

        while (true)
        {
            try
            {
                Console.Write("Название товара: ");
                string? name = Console.ReadLine();
               
                Console.Write("Цена (целое число): ");
                string? priceText = Console.ReadLine();

                products.Add(name ?? "", priceText ?? "");
                Console.WriteLine("Товар добавлен.");
                Console.WriteLine();
                products.Print();
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"Тип: {ex.GetType().Name}");
                Console.WriteLine();
            }
        }
    }
}