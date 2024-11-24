using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LepskyiSystem.Dto.AnalyzeCraneDto
{
    public class CraneLoadDto
    {
        public double LoadLevel { get; set; }
        public bool IsAnomaly { get; set; }
    }
}
