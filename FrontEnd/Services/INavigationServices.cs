using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.Services
{
    public interface INavigationServices
    {
        IDictionary<string, object> Get_Parameters();
        Task NavigateToAsync(string route, IDictionary<string, object> parameters = null);

        T GetPageViewModel<T>() where T: new();
    }

}
