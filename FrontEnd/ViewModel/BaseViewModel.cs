using CommunityToolkit.Mvvm.ComponentModel;
using FrontEnd.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.ViewModel
{
    public partial class BaseViewModel : ObservableObject
    {
        protected readonly INavigationServices NavigationServices;
        public BaseViewModel(INavigationServices navigationServices)
        {
            NavigationServices = navigationServices;
        }
        public BaseViewModel()
        {
            
        }
    }
}
