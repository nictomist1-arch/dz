Console.WriteLine("Доставка: TransportDelivery");
Console.WriteLine();

TransportDelivery truck = new Truck(modelName: "Volvo FH16", maxAllowedWeightKg: 24000, isAvailableNow: true, transportCount: 3, x: 10, y: 20);
TransportDelivery ship = new Ship(modelName: "Maersk Triple-E", maxAllowedWeightKg: 200_000, isAvailableNow: false, transportCount: 1, x: -50, y: 100);
TransportDelivery drone = new Drone(modelName: "DJI Matrice 300", maxAllowedWeightKg: 5, isAvailableNow: true, transportCount: 12, x: 5, y: -2);
TransportDelivery trail = new Trail(modelName: "Schmitz Cargobull", maxAllowedWeightKg: 28000, isAvailableNow: true, transportCount: 2, x: 30, y: 0);

while (true)
{
    Console.WriteLine();
    Console.WriteLine("Выберите действие:");
    Console.WriteLine("1 - Показать информацию: Truck");
    Console.WriteLine("2 - Показать информацию: Ship");
    Console.WriteLine("3 - Показать информацию: Drone");
    Console.WriteLine("4 - Показать информацию: Trail");
    Console.WriteLine("5 - Показать информацию: все виды транспорта");
    Console.WriteLine("6 - Найти ближайший транспорт к точке (x, y)");
    Console.WriteLine("0 - Выход");
    Console.Write("Ваш выбор: ");

    string action = Console.ReadLine() ?? "";

    switch (action)
    {
        case "1":
            Console.WriteLine(truck.GetFullInfo());
            break;
        case "2":
            Console.WriteLine(ship.GetFullInfo());
            break;
        case "3":
            Console.WriteLine(drone.GetFullInfo());
            break;
        case "4":
            Console.WriteLine(trail.GetFullInfo());
            break;
        case "5":
            Console.WriteLine(truck.GetFullInfo());
            Console.WriteLine();
            Console.WriteLine(ship.GetFullInfo());
            Console.WriteLine();
            Console.WriteLine(drone.GetFullInfo());
            Console.WriteLine();
            Console.WriteLine(trail.GetFullInfo());
            break;
        case "6":
            Console.Write("Введите x : ");
            double placeX = double.Parse(Console.ReadLine()!);
            Console.Write("Введите y : ");
            double placeY = double.Parse(Console.ReadLine()!);

            double dTruck = truck.DistanceTo(placeX, placeY);
            double dShip = ship.DistanceTo(placeX, placeY);
            double dDrone = drone.DistanceTo(placeX, placeY);
            double dTrail = trail.DistanceTo(placeX, placeY);

            TransportDelivery closest = truck;
            double minDistance = dTruck;

            if (dShip < minDistance) { closest = ship; minDistance = dShip; }
            if (dDrone < minDistance) { closest = drone; minDistance = dDrone; }
            if (dTrail < minDistance) { closest = trail; minDistance = dTrail; }

            Console.WriteLine("Ближайший транспорт:");
            Console.WriteLine(closest.GetFullInfo());
            Console.WriteLine($"Расстояние до точки: {minDistance}");
            break;
        case "0":
            Console.WriteLine("Выход.");
            return;
        default:
            Console.WriteLine("Неверный выбор. Попробуйте снова.");
            break;
    }
}

class TransportDelivery
{
    public string ModelName;
    public int MaxAllowedWeightKg;
    public bool IsAvailableNow;
    public int TransportCount;
    public double X;
    public double Y;

    public TransportDelivery(string modelName, int maxAllowedWeightKg, bool isAvailableNow, int transportCount, double x, double y)
    {
        ModelName = modelName;
        MaxAllowedWeightKg = maxAllowedWeightKg;
        IsAvailableNow = isAvailableNow;
        TransportCount = transportCount;
        X = x;
        Y = y;
    }

    public virtual string DeliveryType => "TransportDelivery";

    public string GetFullInfo()
    {
        return
            $"Тип: {DeliveryType}\n" +
            $"Модель: {ModelName}\n" +
            $"Допустимый вес: {MaxAllowedWeightKg}\n" +
            $"Доступен сейчас: {IsAvailableNow}\n" +
            $"Количество транспорта: {TransportCount}\n" +
            $"Координаты транспорта: X={X}, Y={Y}";
    }

    public double DistanceTo(double x, double y)
    {
        double dx = x - X;
        double dy = y - Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }
}

sealed class Truck : TransportDelivery
{
    public Truck(string modelName, int maxAllowedWeightKg, bool isAvailableNow, int transportCount, double x, double y)
        : base(modelName, maxAllowedWeightKg, isAvailableNow, transportCount, x, y)
    {
    }

    public override string DeliveryType => "Truck";
}

sealed class Ship : TransportDelivery
{
    public Ship(string modelName, int maxAllowedWeightKg, bool isAvailableNow, int transportCount, double x, double y)
        : base(modelName, maxAllowedWeightKg, isAvailableNow, transportCount, x, y)
    {
    }

    public override string DeliveryType => "Ship";
}

sealed class Drone : TransportDelivery
{
    public Drone(string modelName, int maxAllowedWeightKg, bool isAvailableNow, int transportCount, double x, double y)
        : base(modelName, maxAllowedWeightKg, isAvailableNow, transportCount, x, y)
    {
    }

    public override string DeliveryType => "Drone";
}

sealed class Trail : TransportDelivery
{
    public Trail(string modelName, int maxAllowedWeightKg, bool isAvailableNow, int transportCount, double x, double y)
        : base(modelName, maxAllowedWeightKg, isAvailableNow, transportCount, x, y)
    {
    }

    public override string DeliveryType => "Trail";
}
