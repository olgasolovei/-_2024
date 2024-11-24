using LepskyiSystem.Wpf.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LepskyiSystem.Wpf.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MenuMediatorService MenuMediatorService { get; }

        public MainViewModel(MenuMediatorService menuMediatorService)
        {
            MenuMediatorService = menuMediatorService;
        }
    }
}
