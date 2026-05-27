using System.Linq;

namespace ConsoleApp19
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("Введите количество строк n: ");
            int m = int.Parse(Console.ReadLine()!);

            string[] strings = Enumerable.Range(0, m)
                .Select(i =>
                {
                    Console.Write($"Введите строку [{i}]: ");
                    return Console.ReadLine()!;
                })
                .ToArray();

            string[] filtered = strings
                .Where(s => s.Length > 3)
                .OrderBy(s => s, StringComparer.CurrentCultureIgnoreCase)
                .ToArray();

            int countA = strings.Sum(s => s.Count(c => c == 'а' || c == 'А'));

            Console.WriteLine();
            Console.WriteLine("Строки длиной > 3:");
            foreach (string line in filtered)
                Console.WriteLine($"  {line}");

            Console.WriteLine();
            Console.WriteLine($"Количество букв 'а' во всех строках: {countA}");
        }
    }
}
