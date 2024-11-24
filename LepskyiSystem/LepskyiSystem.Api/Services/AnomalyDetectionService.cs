using LepskyiSystem.Dto.AnalyzeCraneDto;
using LepskyiSystem.Dto.RawDataDto;

namespace LepskyiSystem.Api.Services
{
    public class AnomalyDetectionService
    {
        // Граничні значення для параметрів
        private const double MaxVelocity = 5.0; // м/с
        private const double MaxVibrationLevel = 0.5; // вібрації
        private const double MinLoadLevel = 10.0; // мінімальний рівень навантаження (%)
        private const double MaxLoadLevel = 100.0; // максимальний рівень навантаження (%)
        private const double MaxPositionX = 20.0; // обмеження для X (м)
        private const double MaxPositionY = 20.0; // обмеження для Y (м)
        private const double MaxPositionZ = 10.0; // обмеження для Z (м)

        public AnomalyDetectionService()
        {
             
        }

        public AnalyzedCraneDataDto AnalyzeCraneData(CraneSensorRawDataDto rawData)
        {
            return new AnalyzedCraneDataDto()
            {
                SensorId = rawData.SensorId,
                Timestamp = rawData.Timestamp,
                Velocity = AnalyzeVelocity(rawData.Velocity),
                Vibration = AnalyzeVibration(rawData.VibrationLevel),
                LoadLevel = AnalyzeLoad(rawData.LoadLevel),
                Position = AnalyzePosition(rawData.PositionX, rawData.PositionY, rawData.PositionZ)
            };
        }

        private CraneVelocityDto AnalyzeVelocity(double velocity)
        {
            return new CraneVelocityDto()
            {
                Velocity = velocity,
                IsAnomaly = velocity > MaxVelocity
            };
        }

        private CraneVibrationDto AnalyzeVibration(double vibrationLevel)
        {
            return new CraneVibrationDto()
            {
                VibrationLevel = vibrationLevel,
                IsAnomaly = vibrationLevel > MaxVibrationLevel
            };
        }

        private CraneLoadDto AnalyzeLoad(double loadLevel)
        {
            return new CraneLoadDto()
            {
                LoadLevel = loadLevel,
                IsAnomaly = loadLevel < MinLoadLevel || loadLevel > MaxLoadLevel
            };
        }

        private CranePositionDto AnalyzePosition(double x, double y, double z)
        {
            CranePositionDto cranePosition = new CranePositionDto
            {
                PositionX = x,
                PositionY = y,
                PositionZ = z
            };

            cranePosition.IsAnomaly = (x > MaxPositionX || y > MaxPositionY || z > MaxPositionZ);

            return cranePosition;
        }
    }
}
