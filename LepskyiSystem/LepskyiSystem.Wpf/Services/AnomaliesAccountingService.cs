using LepskyiSystem.Dto.AnalyzeCraneDto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LepskyiSystem.Wpf.Services
{
    public class AnomaliesAccountingService
    {
        public AnomaliesAccountingService()
        {
            Collection = new ObservableCollection<AnalyzedCraneDataDto>();
        }

        public ObservableCollection<AnalyzedCraneDataDto> Collection { get; }
    }
}
