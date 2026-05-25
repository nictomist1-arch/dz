namespace ConsoleApp10
{
    class Stack<T>
    {
        private readonly List<T> items = new();

        public int Count => items.Count;

        public bool IsEmpty => items.Count == 0;

        public void Push(T item) => items.Add(item);

        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Стак пуст");

            T item = items[^1];
            items.RemoveAt(items.Count - 1);
            return item;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Стак пуст");

            return items[^1];
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            Console.WriteLine($"Пуст? {stack.IsEmpty}, Count: {stack.Count}");

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            Console.WriteLine($"После Push: Count = {stack.Count}, Peek = {stack.Peek()}");

            Console.WriteLine($"Pop: {stack.Pop()}");
            Console.WriteLine($"Pop: {stack.Pop()}");
            Console.WriteLine($"Осталось: Count = {stack.Count}, Peek = {stack.Peek()}");
        }
    }
}
