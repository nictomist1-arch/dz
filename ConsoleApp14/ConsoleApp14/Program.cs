namespace ConsoleApp14
{
    class Validator<T>
    {
        private readonly List<Predicate<T>> rules = new();

        public void AddRule(Predicate<T> rule) => rules.Add(rule);

        public bool Validate(T item) => rules.All(rule => rule(item));
    }

    internal class Program
    {
        static void Main()
        {
            var intValidator = new Validator<int>();
            intValidator.AddRule(x => x > 0);
            intValidator.AddRule(x => x < 100);
            intValidator.AddRule(x => x % 2 == 0);

            Console.WriteLine("Validator<int>:");
            foreach (int value in new[] { 10, -5, 101, 7, 50 })
                Console.WriteLine($"  {value} -> {(intValidator.Validate(value) ? "OK" : "Ошибка")}");

            Console.WriteLine();

            var stringValidator = new Validator<string>();
            stringValidator.AddRule(s => !string.IsNullOrWhiteSpace(s));
            stringValidator.AddRule(s => s.Length >= 3);
            stringValidator.AddRule(s => s.Any(char.IsLetter));

            Console.WriteLine("Validator<string>:");
            foreach (string value in new[] { "abc", "", "12", "hello" })
                Console.WriteLine($"  \"{value}\" -> {(stringValidator.Validate(value) ? "OK" : "Ошибка")}");
        }
    }
}
