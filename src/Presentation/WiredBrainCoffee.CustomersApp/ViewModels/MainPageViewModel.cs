﻿using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WiredBrainCoffee.CustomersApp.ViewModels.Abstraction;
using WiredBrainCoffee.Data;
using WiredBrainCoffee.Models;
using WiredBrainCoffee.Models.Base;

namespace WiredBrainCoffee.CustomersApp.ViewModels
{
    public class MainPageViewModel : ObservableBase
    {
        private readonly WiredBrainCoffeeDbContext _dbContext;

        public ObservableCollection<Customer> Customers { get; }

        public MainPageViewModel(
            WiredBrainCoffeeDbContext dbContext)
        {
            _dbContext = dbContext;

            Customers = new ObservableCollection<Customer>();
        }

        private Customer _selectedCustomer;

        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set 
            {
                if (_selectedCustomer != value)
                {
                    _selectedCustomer = value;
                    OnPropertyChange();
                    OnPropertyChange(nameof(IsCustomerSelected));
                }
               
            }
        }

        public bool IsCustomerSelected => SelectedCustomer != null;

        public async Task LoadAsync()
        {
            Customers.Clear();

            var customers = await this._dbContext.LoadCustomersAsync();

            foreach (var customer in customers)
            {
                Customers.Add(customer);
            }
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveClientsAsync(Customers);
        }

        public void AddCustomerButton()
        {
            var newCustomer = new Customer() { FirstName = "New" };
            Customers.Add(newCustomer);
            SelectedCustomer = newCustomer;
        }

        public void DeleteCustomerButton()
        {
            var customer = SelectedCustomer;
            if (customer != null)
            {
                Customers.Remove(customer);
            }
            
        }
    }
}
