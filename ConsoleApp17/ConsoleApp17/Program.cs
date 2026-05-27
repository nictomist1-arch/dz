namespace ConsoleApp17
{
    class CaesarCipher
    {
        private const string LowerRu = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        private const string UpperRu = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

        public static string Encrypt(string text, int shift)
        {
            char[] result = new char[text.Length];

            for (int i = 0; i < text.Length; i++)
                result[i] = ShiftChar(text[i], shift);

            return new string(result);
        }

        private static char ShiftChar(char ch, int shift)
        {
            int index = LowerRu.IndexOf(ch);
            if (index >= 0)
                return LowerRu[(index + shift % LowerRu.Length + LowerRu.Length) % LowerRu.Length];

            index = UpperRu.IndexOf(ch);
            if (index >= 0)
                return UpperRu[(index + shift % UpperRu.Length + UpperRu.Length) % UpperRu.Length];

            return ch;
        }

        public static string ReadText(string inputPath)
        {
            return File.ReadAllText(inputPath);
        }

        public static string SaveEncrypted(string encryptedText, string inputPath, string? outputPath = null)
        {
            outputPath ??= GetDefaultOutputPath(inputPath);
            File.WriteAllText(outputPath, encryptedText);
            return outputPath;
        }

        private static string GetDefaultOutputPath(string inputPath)
        {
            string dir = Path.GetDirectoryName(inputPath) ?? "";
            string name = Path.GetFileNameWithoutExtension(inputPath);
            string ext = Path.GetExtension(inputPath);
            return Path.Combine(dir, $"{name}.encrypted{ext}");
        }
    }

    internal class Program
    {
        private const string WorkDirectory = @"C:\Users\admin\source\repos\dz\ConsoleApp17\ConsoleApp17\bin\Debug\net8.0";

        static void Main()
        {
            Console.WriteLine($"Рабочая папка: {WorkDirectory}");
            Console.WriteLine("Входной файл: data.txt\n");

            Directory.CreateDirectory(WorkDirectory);
            string inputPath = Path.Combine(WorkDirectory, "data.txt");

            Console.Write("Введите сдвиг: ");
            int shift = int.Parse(Console.ReadLine()!);

            try
            {
                string sourceText = CaesarCipher.ReadText(inputPath);
                string encryptedText = CaesarCipher.Encrypt(sourceText, shift);

                Console.WriteLine("\nИсходный текст:");
                Console.WriteLine(sourceText);

                Console.WriteLine("\nЗашифрованный текст:");
                Console.WriteLine(encryptedText);

                string outputPath = CaesarCipher.SaveEncrypted(encryptedText, inputPath);
                Console.WriteLine($"\nГотово. Зашифрованный файл сохранён в:\n{outputPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
