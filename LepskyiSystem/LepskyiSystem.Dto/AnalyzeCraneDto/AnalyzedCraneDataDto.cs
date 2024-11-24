using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LepskyiSystem.Dto.AnalyzeCraneDto
{
    public class AnalyzedCraneDataDto
    {
        public AnalyzedCraneDataDto()
        {
            SensorId = String.Empty;
        }

        public long MessageId { get; set; }
        public string SensorId { get; set; }
        public DateTime Timestamp { get; set; }

        public CranePositionDto Position { get; set; } = null!;
        public CraneVelocityDto Velocity { get; set; } = null!;
        public CraneVibrationDto Vibration { get; set; } = null!;
        public CraneLoadDto LoadLevel { get; set; } = null!;

        public bool IsAnomaly()
        {
            return Position.IsAnomaly || Velocity.IsAnomaly || Vibration.IsAnomaly || LoadLevel.IsAnomaly;
        }
    }
}
