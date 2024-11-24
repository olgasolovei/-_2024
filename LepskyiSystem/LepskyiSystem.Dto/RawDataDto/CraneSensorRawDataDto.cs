using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LepskyiSystem.Dto.RawDataDto
{
    public class CraneSensorRawDataDto
    {
        public CraneSensorRawDataDto()
        {
            SensorId = String.Empty;
        }

        // Унікальний ідентифікатор датчика
        public string SensorId { get; set; }

        // Поточна координата крана (X, Y, Z)
        public double PositionX { get; set; }
        public double PositionY { get; set; }
        public double PositionZ { get; set; }

        // Швидкість руху крана
        public double Velocity { get; set; }

        // Напрямок руху (може бути вектор або кут в градусах)
        public double Direction { get; set; }

        // Час отримання даних
        public DateTime Timestamp { get; set; }

        // Додаткові метрики (вібрація, рівень навантаження)
        public double VibrationLevel { get; set; }
        public double LoadLevel { get; set; }
    }
}
