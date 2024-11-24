using LepskyiSystem.Wpf.Commands;
using LepskyiSystem.Wpf.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LepskyiSystem.Wpf.ViewModels
{
    public class AuthorizationViewModel : BaseViewModel
    {
        private readonly MenuMediatorService _menuMediator;

        private string _login;
        private string _password;

        public AuthorizationViewModel(MenuMediatorService menuMediator)
        {
            _menuMediator = menuMediator;

            AuthorizationCommand = new RelayCommand(Authorization);
            ChangePasswordCommand = new RelayCommand(ChangePassword);

            _login = "TestLogin";
            _password = "TestPassword";
        }

        public string Login
        {
            get => _login;
            set { _login = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        public RelayCommand AuthorizationCommand { get; }
        public RelayCommand ChangePasswordCommand { get; }

        private void Authorization(object? obj)
        {
            //Authorization Logic
            GoToMonitoringMenu();
        }

        private void ChangePassword(object? obj)
        {
            //Change Password Logic
        }

        private void GoToMonitoringMenu()
        {
            _menuMediator.GoToMonitoringMenu();
        }
    }
}
