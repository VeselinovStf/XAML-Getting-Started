using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WiredBrainCoffee.Models;

namespace WiredBrainCoffee.CustomersApp.ViewModels.Abstraction
{
    public interface IMainPageViewModel
    {
        ObservableCollection<Customer> Customers { get; }
        Customer SelectedCustomer { get; set; }
        Task LoadAsync();

        Task SaveAsync();
    }
}
