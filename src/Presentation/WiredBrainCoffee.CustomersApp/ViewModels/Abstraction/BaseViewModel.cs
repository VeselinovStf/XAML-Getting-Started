using System.Threading.Tasks;

namespace WiredBrainCoffee.CustomersApp.ViewModels.Abstraction
{
    public abstract class BaseViewModel
    {
        public abstract Task LoadAsync();
        public abstract Task SaveAsync();
    }
}
