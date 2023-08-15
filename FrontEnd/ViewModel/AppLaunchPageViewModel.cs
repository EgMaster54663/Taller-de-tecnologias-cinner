using CommunityToolkit.Mvvm.Input;
using FrontEnd.Services;
using FrontEnd.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.ViewModel
{
    public partial class AppLaunchPageViewModel : BaseViewModel
    {
        public AppLaunchPageViewModel(INavigationServices navigationServices) : base(navigationServices)
        {

        }



        [RelayCommand]
        public void NavigateToIndexPage()
        {
            NavigationServices.NavigateToAsync(nameof(IndexPage));
        }
    }
}
