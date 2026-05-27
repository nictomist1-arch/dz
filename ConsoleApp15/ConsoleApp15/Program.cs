namespace ConsoleApp15
{
    static class TimerHelper
    {
        public static void DoAfter(Action action, int seconds)
        {
            Task.Run(async () =>
            {
                await Task.Delay(TimeSpan.FromSeconds(seconds));
                action();
            });
        }
    }

    class AlarmClock
    {
        private readonly System.Timers.Timer timer = new(1000);
        private TimeSpan alarmTime;
        private bool isRunning;

        public event Action? AlarmRang;

        public AlarmClock()
        {
            timer.Elapsed += (_, _) => CheckAlarm();
        }

        public void SetAlarm(TimeSpan time)
        {
            alarmTime = time;
            Console.WriteLine($"Будильник установлен на {alarmTime:hh\\:mm\\:ss}");
        }

        public void Start()
        {
            if (isRunning)
                return;

            isRunning = true;
            timer.Start();
            Console.WriteLine("Будильник запущен (проверка каждую секунду)");
        }

        public void Stop()
        {
            isRunning = false;
            timer.Stop();
        }

        private void CheckAlarm()
        {
            TimeSpan now = DateTime.Now.TimeOfDay;

            if (now.Hours == alarmTime.Hours &&
                now.Minutes == alarmTime.Minutes &&
                now.Seconds == alarmTime.Seconds)
            {
                AlarmRang?.Invoke();
            }
        }
    }

    internal class Program
    {
        static async Task Main()
        {
            Console.WriteLine("DoAfter");
            TimerHelper.DoAfter(() => Console.WriteLine("Действие выполнено через 2 секунды!"), 2);
            await Task.Delay(2500);

            Console.WriteLine();
            Console.WriteLine("AlarmClock");
            var clock = new AlarmClock();
            clock.AlarmRang += () =>
            {
                Console.WriteLine("БУДИЛЬНИК СРАБОТАЛ!");
                clock.Stop();
            };

            TimeSpan alarm = DateTime.Now.AddSeconds(5).TimeOfDay;
            clock.SetAlarm(alarm);
            clock.Start();

            Console.WriteLine("Ожидание срабатывания (5 сек)...");
            await Task.Delay(7000);
        }
    }
}
