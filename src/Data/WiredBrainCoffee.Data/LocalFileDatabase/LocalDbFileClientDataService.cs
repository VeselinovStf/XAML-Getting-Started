using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using WiredBrainCoffee.Models;

namespace WiredBrainCoffee.Data.LocalFileDatabase
{
    internal class LocalDbFileClientDataService
    {
        private string _clientsDbFilePath => LocalDbFileConnection.CLIENTS_DB_FILE_LOCATION;

        private StorageFolder _localStorage = ApplicationData.Current.LocalFolder;

        private async Task<StorageFile> GetStorageFile()
        {
            return await _localStorage.TryGetItemAsync(_clientsDbFilePath) as StorageFile;
        }

        internal async Task<List<Customer>> LoadCustomersAsync()
        {
            var storageFile = await GetStorageFile();
            var customersList = new List<Customer>();
            if (storageFile == null)
            {
                customersList = new List<Customer>()
                {
                    new Customer(){ FirstName = "John", LastName = "Dow", IsDeveloper = true},
                    new Customer(){ FirstName = "Jane", LastName = "Dow", IsDeveloper = true},
                    new Customer(){ FirstName = "Tom", LastName = "Mauu", IsDeveloper = true},
                    new Customer(){ FirstName = "Jerry", LastName = "Mouce", IsDeveloper = true},
                    new Customer(){ FirstName = "Ivan", LastName = "Petersom", IsDeveloper = true},
                    new Customer(){ FirstName = "Peter", LastName = "Pesohv", IsDeveloper = true},
                    new Customer(){ FirstName = "Pesho", LastName = "Goshov", IsDeveloper = true},
                    new Customer(){ FirstName = "Maria", LastName = "Asenova", IsDeveloper = true},
                };
            }
            else
            {
                using (var stream = await storageFile.OpenAsync(FileAccessMode.Read))
                {
                    using (var dataReader = new DataReader(stream))
                    {
                        await dataReader.LoadAsync((uint)stream.Size);
                        var json = dataReader.ReadString((uint)stream.Size);
                        customersList = JsonConvert.DeserializeObject<List<Customer>>(json);
                    }
                }
            }


            return customersList;
        }

        internal async Task SaveCustomersAsync(IEnumerable<Customer> clientsToSave)
        {
            var storageFile = await _localStorage.CreateFileAsync(_clientsDbFilePath, CreationCollisionOption.ReplaceExisting);

            using (var stream = await storageFile.OpenAsync(FileAccessMode.ReadWrite))
            {
                using (var dataWriter = new DataWriter(stream))
                {
                    var serializedContent = JsonConvert.SerializeObject(clientsToSave, Formatting.Indented);

                     dataWriter.WriteString(serializedContent);
                    await dataWriter.StoreAsync();
                }
            }
          
        }
    }
}
