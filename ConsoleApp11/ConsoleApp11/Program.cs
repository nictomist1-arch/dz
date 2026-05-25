namespace ConsoleApp11
{
    class TArray<T> where T : IComparable
    {
        public T[] data = null!;

        public T FindMax()
        {
            T max = data[0];
            for (int i = 1; i < data.Length; i++)
            {
                if (data[i].CompareTo(max) > 0)
                    max = data[i];
            }

            return max;
        }
    }

    internal class Program
    {
        static void Main()
        {
            var numbers = new TArray<int> { data = new[] { 5, 2, 8, 1, 9, 3 } };
            Console.WriteLine("int: " + string.Join(" ", numbers.data));
            Console.WriteLine("FindMax: " + numbers.FindMax());

            var words = new TArray<string> { data = new[] { "яблоко", "груша", "абрикос", "банан" } };
            Console.WriteLine();
            Console.WriteLine("string: " + string.Join(" ", words.data));
            Console.WriteLine("FindMax: " + words.FindMax());

            var doubles = new TArray<double> { data = new[] { 1.5, 7.2, 3.1, 7.8, 0.4 } };
            Console.WriteLine();
            Console.WriteLine("double: " + string.Join(" ", doubles.data));
            Console.WriteLine("FindMax: " + doubles.FindMax());
            GC.Collect();
        }
    }
}
