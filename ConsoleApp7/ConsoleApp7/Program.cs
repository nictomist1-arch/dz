using System;

namespace ConsoleApp7
{
    interface ISortable
    {
        void BubbleSort();
        void SelectSort();
    }

    class OneDimensionalArray : ISortable
    {
        public int[] data = null!;

        public void BubbleSort()
        {
            for (int i = 0; i < data.Length - 1; i++)
                for (int j = 0; j < data.Length - 1 - i; j++)
                    if (data[j] > data[j + 1])
                        Swap(ref data[j], ref data[j + 1]);
        }

        public void SelectSort()
        {
            for (int i = 0; i < data.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < data.Length; j++)
                    if (data[j] < data[min])
                        min = j;
                Swap(ref data[i], ref data[min]);
            }
        }

        static void Swap(ref int a, ref int b)
        {
            int t = a;
            a = b;
            b = t;
        }
    }

    class TwoDimensionalArray : ISortable
    {
        public int[,] data = null!;

        public void BubbleSort()
        {
            for (int row = 0; row < data.GetLength(0); row++)
                for (int i = 0; i < data.GetLength(1) - 1; i++)
                    for (int j = 0; j < data.GetLength(1) - 1 - i; j++)
                        if (data[row, j] > data[row, j + 1])
                            Swap(ref data[row, j], ref data[row, j + 1]);
        }

        public void SelectSort()
        {
            for (int row = 0; row < data.GetLength(0); row++)
                for (int i = 0; i < data.GetLength(1) - 1; i++)
                {
                    int min = i;
                    for (int j = i + 1; j < data.GetLength(1); j++)
                        if (data[row, j] < data[row, min])
                            min = j;
                    Swap(ref data[row, i], ref data[row, min]);
                }
        }

        static void Swap(ref int a, ref int b)
        {
            int t = a;
            a = b;
            b = t;
        }
    }

    class StringArray : ISortable
    {
        public string[] data = null!;

        public void BubbleSort()
        {
            for (int i = 0; i < data.Length - 1; i++)
                for (int j = 0; j < data.Length - 1 - i; j++)
                    if (string.Compare(data[j], data[j + 1]) > 0)
                        Swap(ref data[j], ref data[j + 1]);
        }

        public void SelectSort()
        {
            for (int i = 0; i < data.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < data.Length; j++)
                    if (string.Compare(data[j], data[min]) < 0)
                        min = j;
                Swap(ref data[i], ref data[min]);
            }
        }

        static void Swap(ref string a, ref string b)
        {
            string t = a;
            a = b;
            b = t;
        }
    }

    class Program
    {
        static void Main()
        {
            var one = new OneDimensionalArray { data = new[] { 5, 2, 8, 1, 9 } };
            one.BubbleSort();
            Console.WriteLine(string.Join(" ", one.data));

            var two = new TwoDimensionalArray { data = new[,] { { 4, 7 }, { 1, 3 } } };
            two.SelectSort();
            for (int i = 0; i < two.data.GetLength(0); i++)
            {
                for (int j = 0; j < two.data.GetLength(1); j++)
                    Console.Write(two.data[i, j] + " ");
                Console.WriteLine();
            }

            var words = new StringArray { data = new[] { "яблоко", "груша", "абрикос" } };
            words.BubbleSort();
            Console.WriteLine(string.Join(" ", words.data));
        }
    }
}
