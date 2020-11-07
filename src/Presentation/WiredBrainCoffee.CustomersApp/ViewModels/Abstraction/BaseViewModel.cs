using System.Threading.Tasks;
using WiredBrainCoffee.Models.Base;

namespace WiredBrainCoffee.CustomersApp.ViewModels.Abstraction
{
    public abstract class BaseViewModel : ObservableBase
    {
        public abstract Task LoadAsync();
        public abstract Task SaveAsync();
    }
}
