using CraneSimulator;

class Program
{
    public static async Task Main(string[] args)
    {
        string sensorId = "Sensor123";

        var apiService = new ApiService("https://localhost:7073");
        var simulator = new CraneSensorSimulator();
        var cancellationTokenSource = new CancellationTokenSource();

        Console.WriteLine("Натисніть Enter для зупинки симуляції...");

        // Запуск симуляції
        var simulationTask = simulator.StartSimulation(sensorId, data =>
        {
            Console.WriteLine($"SensorId: {data.SensorId}, " +
                              $"Position: ({data.PositionX:F2}, {data.PositionY:F2}, {data.PositionZ:F2}), " +
                              $"Velocity: {data.Velocity:F2} м/с, " +
                              $"Direction: {data.Direction:F2}°, " +
                              $"Timestamp: {data.Timestamp}, " +
                              $"VibrationLevel: {data.VibrationLevel:F2}, " +
                              $"LoadLevel: {data.LoadLevel:F2}%");

            apiService.SendData(data);

        }, cancellationTokenSource.Token);

        // Очікування натискання Enter для зупинки
        Console.ReadLine();
        cancellationTokenSource.Cancel();

        try
        {
            await simulationTask;
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Симуляція зупинена.");
        }
    }
}