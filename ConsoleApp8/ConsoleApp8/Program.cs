using System;

namespace ConsoleApp8
{
    interface IPayment
    {
        string Name { get; set; }
        double Balance { get; set; }
        void Vvod(double sum);
        void Vivod(double sum);
    }

    class Card : IPayment
    {
        public string Name { get; set; } = "";
        public double Balance { get; set; }

        public void Vvod(double sum)
        {
            if (sum > 0)
                Balance += sum;
        }

        public void Vivod(double sum)
        {
            if (sum > 0 && sum <= Balance)
                Balance -= sum;
        }
    }

    class Cash : IPayment
    {
        public string Name { get; set; } = "";
        public double Balance { get; set; }

        public void Vvod(double sum)
        {
            if (sum > 0)
                Balance += sum;
        }

        public void Vivod(double sum)
        {
            if (sum > 0 && sum <= Balance)
                Balance -= sum;
        }
    }

    class Crypto : IPayment
    {
        public string Name { get; set; } = "";
        public double Balance { get; set; }

        public void Vvod(double sum)
        {
            if (sum > 0)
                Balance += sum;
        }

        public void Vivod(double sum)
        {
            if (sum > 0 && sum <= Balance)
                Balance -= sum;
        }
    }

    class Program
    {
        static void Main()
        {
            IPayment card = new Card { Name = "Карта", Balance = 1000 };
            IPayment cash = new Cash { Name = "Наличные", Balance = 500 };
            IPayment crypto = new Crypto { Name = "Крипто", Balance = 0.5 };

            card.Vvod(200);
            card.Vivod(150);

            cash.Vvod(100);
            cash.Vivod(50);

            crypto.Vvod(0.2);
            crypto.Vivod(0.1);

            Console.WriteLine($"{card.Name}: {card.Balance}");
            Console.WriteLine($"{cash.Name}: {cash.Balance}");
            Console.WriteLine($"{crypto.Name}: {crypto.Balance}");
        }
    }
}
