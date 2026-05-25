namespace ConsoleApp13
{
    enum Month
    {
        January = 1,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }

    enum Season
    {
        Winter,
        Spring,
        Summer,
        Autumn
    }

    static class SeasonHelper
    {
        public static Season GetSeason(Month month) => month switch
        {
            Month.December or Month.January or Month.February => Season.Winter,
            Month.March or Month.April or Month.May => Season.Spring,
            Month.June or Month.July or Month.August => Season.Summer,
            _ => Season.Autumn
        };

        public static Month[] GetMonths(Season season) => season switch
        {
            Season.Winter => new[] { Month.December, Month.January, Month.February },
            Season.Spring => new[] { Month.March, Month.April, Month.May },
            Season.Summer => new[] { Month.June, Month.July, Month.August },
            Season.Autumn => new[] { Month.September, Month.October, Month.November },
            _ => Array.Empty<Month>()
        };

        public static void PrintSeasonInfo(Season season)
        {
            Console.WriteLine($"Сезон: {season}");
            Console.WriteLine("Месяцы: " + string.Join(", ", GetMonths(season)));
        }
    }

    [Flags]
    enum Permissions
    {
        None = 0,
        Read = 1,
        Write = 2,
        Delete = 4,
        Admin = 8
    }

    class User
    {
        public Permissions Role { get; private set; }

        public User(Permissions role = Permissions.None)
        {
            Role = role;
        }

        public bool HasPermission(Permissions permission)
        {
            if (permission == Permissions.None)
                return true;
            return (Role & permission) == permission;
        }

        public void Grant(Permissions permission) => Role |= permission;

        public void Revoke(Permissions permission) => Role &= ~permission;

        public void PrintPermissions()
        {
            if (Role == Permissions.None)
            {
                Console.WriteLine("Права: None");
                return;
            }

            var list = new List<string>();
            foreach (Permissions p in Enum.GetValues<Permissions>())
            {
                if (p != Permissions.None && HasPermission(p))
                    list.Add(p.ToString());
            }

            Console.WriteLine("Права: " + string.Join(", ", list));
        }
    }

    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Месяцы и сезоны ===");
            foreach (Month month in new[] { Month.January, Month.April, Month.July, Month.October })
                Console.WriteLine($"{month} -> {SeasonHelper.GetSeason(month)}");

            Console.WriteLine();
            SeasonHelper.PrintSeasonInfo(Season.Summer);

            Console.WriteLine();
            Console.WriteLine("=== Права доступа ===");
            var user = new User(Permissions.Read);
            user.PrintPermissions();

            user.Grant(Permissions.Write | Permissions.Delete);
            Console.WriteLine($"Has Write: {user.HasPermission(Permissions.Write)}");
            Console.WriteLine($"Has Admin: {user.HasPermission(Permissions.Admin)}");
            user.PrintPermissions();

            user.Revoke(Permissions.Delete);
            user.Grant(Permissions.Admin);
            user.PrintPermissions();
        }
    }
}
