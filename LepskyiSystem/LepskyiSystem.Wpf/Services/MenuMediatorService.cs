using LepskyiSystem.Wpf.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LepskyiSystem.Wpf.Services
{
    public class MenuMediatorService : INotifyPropertyChanged
    {
        private AuthorizationViewModel? _authorizationMenu;
        private MonitoringViewModel? _monitoringMenu;
        private ReportsViewModel? _reportsViewModel;

        private BaseViewModel? _selectedMenu;

        public MenuMediatorService()
        {

        }

        public void SetMenus(AuthorizationViewModel authorizationMenu,
               MonitoringViewModel monitoringMenu,
               ReportsViewModel reportsViewModel)
        {
            _authorizationMenu = authorizationMenu;
            _monitoringMenu = monitoringMenu;
            _reportsViewModel = reportsViewModel;
        }

        public BaseViewModel? SelectedMenu
        {
            get => _selectedMenu;
            private set { _selectedMenu = value; MenuChanged(); }
        }

        public void GoToAuthentacationMenu()
        {
            SelectedMenu = _authorizationMenu;
        }

        public void GoToMonitoringMenu()
        {
            SelectedMenu = _monitoringMenu;
            _monitoringMenu?.Connect();
        }

        public void GoToReportsMenu()
        {
            SelectedMenu = _reportsViewModel;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void MenuChanged()
        {
            var eventArgs = new PropertyChangedEventArgs(nameof(SelectedMenu));
            PropertyChanged?.Invoke(this, eventArgs);
        }
    }
}
