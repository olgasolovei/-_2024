using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LepskyiSystem.Dto.AnalyzeCraneDto
{
    public class CraneVibrationDto
    {
        public double VibrationLevel { get; set; }
        public bool IsAnomaly { get; set; }
    }
}
