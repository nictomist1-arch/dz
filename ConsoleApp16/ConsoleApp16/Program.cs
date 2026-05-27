namespace ConsoleApp16
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Сборка мусора (GC)\n");

            Console.WriteLine("1. Что такое сборка мусора и зачем она нужна?");
            Console.WriteLine(
                "   Сборка мусора (Garbage Collection) — автоматическое освобождение памяти, " +
                "занятой объектами, на которые больше нет ссылок. Нужна, чтобы программист " +
                "не управлял памятью вручную и не допускал утечек.");

            Console.WriteLine();
            Console.WriteLine("2. Чем отличается управляемая память от неуправляемой?");
            Console.WriteLine(
                "   Управляемая память выделяется CLR и освобождается GC (объекты в куче). " +
                "Неуправляемая — ресурсы вне CLR (файлы, сокеты, WinAPI), за ними следит " +
                "программист или IDisposable/Finalizer.");

            Console.WriteLine();
            Console.WriteLine("3. Какие поколения есть в GC, опишите каждую:");
            Console.WriteLine("   Gen 0 — новые короткоживущие объекты, сборка частая и быстрая.");
            Console.WriteLine("   Gen 1 — буфер между 0 и 2, объекты пережившие сборку Gen 0.");
            Console.WriteLine("   Gen 2 — долгоживущие объекты, сборка редкая и дорогая.");
            Console.WriteLine("   LOH (Large Object Heap) — объекты >= 85 000 байт, собирается с Gen 2.");

            Console.WriteLine();
            Console.WriteLine("4. Когда объект считается мусором?");
            Console.WriteLine(
                "   Когда на него нет достижимых ссылок из корней (стек, статика, регистры, " +
                "GC handles). Тогда GC может удалить объект при следующей сборке.");

            Console.WriteLine();
            Console.WriteLine("Демонстрация GC");
            for (int i = 0; i < 10000; i++)
                _ = new byte[1000];

            Console.WriteLine($"Память до сборки: {GC.GetTotalMemory(false)} байт");
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine($"Память после GC.Collect(): {GC.GetTotalMemory(true)} байт");
            Console.WriteLine($"Поколение последней сборки: {GC.MaxGeneration}");
        }
    }
}
