using System;
using System.Linq;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WiredBrainCoffee.Data;
using WiredBrainCoffee.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WiredBrainCoffee.CustomersApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly WiredBrainCoffeeDbContext _dbContext;

        public MainPage()
        {
            this.InitializeComponent();
            _dbContext = new WiredBrainCoffeeDbContext();

            this.Loaded += MainPage_Loaded;

            App.Current.Suspending += App_Suspending;
        }

        private async void App_Suspending(object sender, Windows.ApplicationModel.SuspendingEventArgs e)
        {
            var defferal = e.SuspendingOperation.GetDeferral();
            await _dbContext.SaveClientsAsync(custemersMenuList.Items.OfType<Customer>());
            defferal.Complete();
        }

        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            custemersMenuList.Items.Clear();

            var customers = await this._dbContext.LoadCustomersAsync();

            foreach (var customer in customers)
            {
                custemersMenuList.Items.Add(customer);
            }
        }

        private async void AddCustomerButton_ClickHandler(object sender, RoutedEventArgs e)
        {
            var messageDialog = new MessageDialog("Custommer Added");
            await messageDialog.ShowAsync();
        }

        private void MoveNavigation_Click(object sender, RoutedEventArgs e)
        {
            var currentNavigationColumn = Grid.GetColumn(movableMenuNavigation);

            var newLocation = currentNavigationColumn == 0 ? 2 : 0;

            Grid.SetColumn(movableMenuNavigation,newLocation);

            var buttonSymbol = newLocation == 0 ? Symbol.Forward : Symbol.Back;

            moveButtonIcon.Symbol = buttonSymbol;

        }
        private void CustomerListView_SelctionChange(object sender, SelectionChangedEventArgs e)
        {
            var customer = custemersMenuList.SelectedItem as Customer;

            firstNameText.Text = customer?.FirstName ?? "";
            lastNameText.Text = customer?.LastName ?? "";
            isDeveloperCheckBox.IsChecked = customer?.IsDeveloper;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateCustomer();
        }

        private void CheckBoxIsDeveloper_Handler(object sender, RoutedEventArgs e)
        {
            UpdateCustomer();
        }

       
        private void UpdateCustomer()
        {
            var customer = custemersMenuList.SelectedItem as Customer;

            if (customer != null)
            {
                customer.FirstName = firstNameText.Text;
                customer.LastName = lastNameText.Text;
                customer.IsDeveloper = isDeveloperCheckBox.IsChecked.GetValueOrDefault();
            }
        }

    }
}
