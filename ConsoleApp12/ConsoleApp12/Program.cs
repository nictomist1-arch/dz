namespace ConsoleApp12
{
    class HistogramArray
    {
        private readonly double[] sortedData;
        private readonly int intervalCount;
        private readonly double min;
        private readonly double max;

        public HistogramArray(double[] numbers, int intervals)
        {
            if (numbers == null || numbers.Length == 0)
                throw new ArgumentException("Массив не может быть пустым");
            if (intervals <= 0)
                throw new ArgumentException("Количество интервалов должно быть больше 0");

            sortedData = (double[])numbers.Clone();
            Array.Sort(sortedData);
            intervalCount = intervals;
            min = sortedData[0];
            max = sortedData[^1];
        }

        public int Get(double value)
        {
            if (intervalCount == 1 || min == max)
                return 0;

            double width = (max - min) / intervalCount;
            int index = (int)((value - min) / width);

            if (index < 0)
                return 0;
            if (index >= intervalCount)
                return intervalCount - 1;

            return index;
        }

        public double GetPercentile(double percentile)
        {
            if (percentile < 0 || percentile > 100)
                throw new ArgumentOutOfRangeException(nameof(percentile), "Процентиль должен быть от 0 до 100");

            if (sortedData.Length == 1)
                return sortedData[0];

            double rank = (percentile / 100.0) * (sortedData.Length - 1);
            int lower = (int)Math.Floor(rank);
            int upper = (int)Math.Ceiling(rank);

            if (lower == upper)
                return sortedData[lower];

            double fraction = rank - lower;
            return sortedData[lower] + fraction * (sortedData[upper] - sortedData[lower]);
        }
    }

    internal class Program
    {
        static void Main()
        {
            double[] data = { 2, 5, 8, 12, 15, 18, 22, 25, 30, 35 };
            var histogram = new HistogramArray(data, 5);

            Console.WriteLine("Данные: " + string.Join(", ", data));
            Console.WriteLine("Интервалов: 5, min = 2, max = 35");
            Console.WriteLine();

            Console.WriteLine("Индекс интервала (Get):");
            foreach (double value in new[] { 2.0, 10.0, 20.0, 35.0 })
                Console.WriteLine($"  значение {value} -> интервал {histogram.Get(value)}");

            Console.WriteLine();
            Console.WriteLine("Значение по процентилю (GetPercentile):");
            foreach (double p in new[] { 0.0, 25.0, 50.0, 75.0, 100.0 })
                Console.WriteLine($"  {p}% -> {histogram.GetPercentile(p)}");
        }
    }
}
