using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LepskyiSystem.Dto.AnalyzeCraneDto
{
    public class CranePositionDto
    {
        public double PositionX { get; set; }
        public double PositionY { get; set; }
        public double PositionZ { get; set; }

        public bool IsAnomaly { get; set; }
    }
}
