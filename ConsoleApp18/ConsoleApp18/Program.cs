namespace ConsoleApp18
{
    class WordSearcher
    {
        public static bool ContainsWordInFiles(string directory, string word)
        {
            string[] files = Directory.GetFiles(directory, "*.txt");

            foreach (string file in files)
            {
                string content = File.ReadAllText(file);
                if (content.Contains(word, StringComparison.OrdinalIgnoreCase))
                    return true;
            }

            return false;
        }
    }

    internal class Program
    {
        private const string WorkDirectory = @"C:\Users\admin\source\repos\dz\ConsoleApp18\ConsoleApp18\bin\Debug\net8.0";

        static void Main()
        {
            Console.WriteLine($"Папка с файлами: {WorkDirectory}\n");

            Directory.CreateDirectory(WorkDirectory);

            Console.Write("Введите слово для поиска: ");
            string word = Console.ReadLine()!;

            bool found = WordSearcher.ContainsWordInFiles(WorkDirectory, word);
            Console.WriteLine(found);
        }
    }
}
