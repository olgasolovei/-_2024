using LepskyiSystem.Dto.RawDataDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraneSimulator
{
    public class CraneSensorSimulator
    {
        private readonly Random _random;

        public CraneSensorSimulator()
        {
            _random = new Random();
        }

        public CraneSensorRawDataDto GenerateRandomSensorData(string sensorId)
        {
            return new CraneSensorRawDataDto
            {
                SensorId = sensorId,
                PositionX = Math.Round(_random.NextDouble() * 20.0, 2), // Від 0 до 20
                PositionY = Math.Round(_random.NextDouble() * 20.0, 2), // Від 0 до 20
                PositionZ = Math.Round(_random.NextDouble() * 10.0, 2), // Від 0 до 10
                Velocity = Math.Round(_random.NextDouble() * 10.0, 2), // Від 0 до 10 м/с
                Direction = Math.Round(_random.NextDouble() * 360.0, 2), // Від 0 до 360 градусів
                Timestamp = DateTime.UtcNow,
                VibrationLevel = Math.Round(_random.NextDouble() * 1.0, 2), // Від 0 до 1
                LoadLevel = _random.Next(0, 120) // Від 0 до 120%
            };
        }

        public async Task StartSimulation(string sensorId, Action<CraneSensorRawDataDto> onDataGenerated, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var data = GenerateRandomSensorData(sensorId);
                onDataGenerated?.Invoke(data); // Виклик переданого методу обробки даних
                await Task.Delay(500, cancellationToken); // Затримка 0.5 секунди
            }
        }
    }
}
