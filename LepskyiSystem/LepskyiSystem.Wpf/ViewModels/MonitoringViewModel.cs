using LepskyiSystem.Dto.AnalyzeCraneDto;
using LepskyiSystem.Wpf.Commands;
using LepskyiSystem.Wpf.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LepskyiSystem.Wpf.ViewModels
{
    public class MonitoringViewModel : BaseViewModel
    {
        private readonly MenuMediatorService _menuMediator;
        private readonly HubConnectionService _hubConnectionService;

        private AnalyzedCraneDataDto? _currentData;

        public MonitoringViewModel(MenuMediatorService menuMediator, HubConnectionService hubConnectionService, 
               AnomaliesAccountingService anomaliesAccountingService)
        {
            _menuMediator = menuMediator;
            _hubConnectionService = hubConnectionService;

            GoToReportsMenuCommand = new RelayCommand(GoToReportsMenu);
            Anomalies = anomaliesAccountingService;

            _hubConnectionService.AnalyzedCraneDataRecived += OnCraneDataRecived;
        }

        public AnomaliesAccountingService Anomalies { get; }

        public RelayCommand GoToReportsMenuCommand { get; }

        public AnalyzedCraneDataDto? CurrentData
        {
            get => _currentData;
            set { _currentData = value; OnPropertyChanged(); }
        }

        public void Connect()
        {
            if (_hubConnectionService.Connected == false)
            {
                _hubConnectionService.Connect().ContinueWith(task =>
                {
                    if (task.Exception != null)
                    {
                        Console.WriteLine("OOOPs");
                    }
                });
            }
        }

        private void OnCraneDataRecived(AnalyzedCraneDataDto data)
        {
            CurrentData = data;

            if (CurrentData.IsAnomaly())
                Anomalies.Collection.Add(CurrentData);
        }

        private void GoToReportsMenu(object? obj)
        {
            _menuMediator.GoToReportsMenu();
        }
    }
}
