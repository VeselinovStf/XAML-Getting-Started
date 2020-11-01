using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WiredBrainCoffee.Data.Exceptions;
using WiredBrainCoffee.Data.LocalFileDatabase;
using WiredBrainCoffee.Models;

namespace WiredBrainCoffee.Data
{
    public class WiredBrainCoffeeDbContext
    {
        private readonly LocalDbFileClientDataService _dataService;


        public WiredBrainCoffeeDbContext()
        {
            _dataService = new LocalDbFileClientDataService();              
        }

        public async Task<IEnumerable<Customer>> LoadCustomersAsync()
        {
            return await this._dataService.LoadCustomersAsync();
        }

        public async Task SaveClientsAsync(IEnumerable<Customer> clientsToSave)
        {
            await _dataService.SaveCustomersAsync(clientsToSave);

        }
    }
}
