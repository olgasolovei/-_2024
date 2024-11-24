using LepskyiSystem.Wpf.Services;
using LepskyiSystem.Wpf.ViewModels;
using Microsoft.AspNetCore.SignalR.Client;
using System.Configuration;
using System.Data;
using System.Windows;

namespace LepskyiSystem.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            string baseUrl = "https://localhost:7073";
            //string baseUrl = "http://localhost:5000";
            //string baseUrl = "";

            if (baseUrl == "")
                throw new Exception();

            HubConnection connection = new HubConnectionBuilder()
                .WithUrl($"{baseUrl}/crane-data")
                .Build();

            PdfGenerationService pdfGenerationService = new PdfGenerationService();
            AnomaliesAccountingService anomaliesAccounting = new AnomaliesAccountingService();
            MenuMediatorService menuMediator = new MenuMediatorService();
            HubConnectionService connectionService = new HubConnectionService(connection);

            AuthorizationViewModel authorizationVM = new AuthorizationViewModel(menuMediator);
            MonitoringViewModel monitoringVM = new MonitoringViewModel(menuMediator, connectionService, anomaliesAccounting);
            ReportsViewModel reportsVM = new ReportsViewModel(menuMediator, anomaliesAccounting, pdfGenerationService);
            
            menuMediator.SetMenus(authorizationVM, monitoringVM, reportsVM);
            menuMediator.GoToAuthentacationMenu();

            MainViewModel mainViewModel = new MainViewModel(menuMediator);

            MainWindow = new MainWindow();
            MainWindow.DataContext = mainViewModel;
            MainWindow.Show();

            base.OnStartup(e);
        }
    }

}
