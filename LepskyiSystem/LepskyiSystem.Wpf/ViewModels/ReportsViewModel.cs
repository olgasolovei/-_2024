using LepskyiSystem.Wpf.Commands;
using LepskyiSystem.Wpf.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LepskyiSystem.Wpf.ViewModels
{
    public class ReportsViewModel : BaseViewModel
    {
        private readonly MenuMediatorService _menuMediator;
        private readonly AnomaliesAccountingService _accountingService;
        private readonly PdfGenerationService _pdfGenerationService;

        public ReportsViewModel(MenuMediatorService menuMediator, AnomaliesAccountingService anomaliesAccountingService,
               PdfGenerationService pdfGenerationService)
        {
            _menuMediator = menuMediator;
            _accountingService = anomaliesAccountingService;
            _pdfGenerationService = pdfGenerationService;

            GoToMonitoringMenuCommand = new RelayCommand(GoToMonitoringMenu);
            ExportToPdfCommand = new RelayCommand(ExportToPdf);
        }

        public RelayCommand GoToMonitoringMenuCommand { get; }
        public RelayCommand ExportToPdfCommand { get; }

        private void GoToMonitoringMenu(object? obj)
        {
            _menuMediator.GoToMonitoringMenu();
        }

        private void ExportToPdf(object? obj)
        {
            _pdfGenerationService.GenerateFile(_accountingService.Collection);
        }
    }
}
