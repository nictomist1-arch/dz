
public class StringArray
{
    private string[] _words;

    public StringArray(int size)
    {
        if (size <= 0)
            throw new ArgumentException("Размер массива должен быть больше 0.");

        _words = new string[size];
    }

    public int Length => _words.Length;

    public string this[int index]
    {
        get
        {
            if (index < 0 || index >= _words.Length)
                throw new IndexOutOfRangeException("Индекс выходит за границы массива.");

            return _words[index] ?? string.Empty;
        }
        set
        {
            if (index < 0 || index >= _words.Length)
                throw new IndexOutOfRangeException("Индекс выходит за границы массива.");

            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException($"Слово в индексе {index} не может быть пустым или состоять только из пробелов.");

            string trimmedValue = value.Trim();
            if (trimmedValue.Length == 0)
                throw new ArgumentException($"Слово в индексе {index} должно содержать хотя бы один символ.");

            _words[index] = trimmedValue;
        }
    }

    public void PrintWordFrequencies()
    {
        var wordCount = new Dictionary<string, int>();

        foreach (string word in _words)
        {
            if (!string.IsNullOrWhiteSpace(word))
            {
                string normalizedWord = word.Trim();
                if (wordCount.ContainsKey(normalizedWord))
                    wordCount[normalizedWord]++;
                else
                    wordCount[normalizedWord] = 1;
            }
        }

        Console.WriteLine("\nЧастота повторения слов в массиве:");

        if (wordCount.Count == 0)
        {
            Console.WriteLine("Массив не содержит слов.");
            return;
        }

        foreach (var pair in wordCount.OrderBy(x => x.Key))
        {
            string plural = pair.Value == 1 ? "раз" : "раза";
            Console.WriteLine($"Слово \"{pair.Key}\" встречается {pair.Value} {plural}");
        }

        Console.WriteLine($"Всего уникальных слов: {wordCount.Count}");
        Console.WriteLine($"Всего слов в массиве: {_words.Length}");
    }

    public void PrintAllWords()
    {
        Console.WriteLine("\nСодержимое массива:");
        for (int i = 0; i < _words.Length; i++)
        {
            Console.WriteLine($"[{i}]: {_words[i]}");
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                StringArray moreWords = new StringArray(7);
                moreWords[0] = "кот";
                moreWords[1] = "собака";
                moreWords[2] = "кот";
                moreWords[3] = "птица";
                moreWords[4] = "кот";
                moreWords[5] = "рыба";
                moreWords[6] = "собака";

                moreWords.PrintAllWords();
                moreWords.PrintWordFrequencies();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}