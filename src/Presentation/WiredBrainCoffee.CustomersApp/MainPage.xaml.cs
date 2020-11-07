using System;
using System.Linq;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WiredBrainCoffee.CustomersApp.Controls;
using WiredBrainCoffee.CustomersApp.ViewModels;
using WiredBrainCoffee.CustomersApp.ViewModels.Abstraction;
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
        public MainPageViewModel ViewModel { get; }

        public MainPage()
        {
            this.InitializeComponent();

            ViewModel = new MainPageViewModel(new WiredBrainCoffeeDbContext());
            
            //Works for {Binding } in WPF and UWP {Binding }
            //DataContext = ViewModels;

            this.Loaded += MainPage_Loaded;

            App.Current.Suspending += App_Suspending;

            this.RequestedTheme = App.Current.RequestedTheme == ApplicationTheme.Dark ? ElementTheme.Dark : ElementTheme.Light;
        }

        private async void App_Suspending(object sender, Windows.ApplicationModel.SuspendingEventArgs e)
        {
            var defferal = e.SuspendingOperation.GetDeferral();
            await ViewModel.SaveAsync();
            defferal.Complete();        
        }

        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadAsync();
        }

        private void AddCustomerButton_ClickHandler(object sender, RoutedEventArgs e)
        {
            var newCustomer = new Customer() { FirstName = "New" };
            custemersMenuList.Items.Add(newCustomer);
            custemersMenuList.SelectedItem = newCustomer;
        }

        private void DeleteCustomerButton_ClickHandler(object sender, RoutedEventArgs e)
        {
            var cutomer = custemersMenuList.SelectedItem as Customer;

            custemersMenuList.Items.Remove(cutomer);
        }

        private void MoveNavigation_Click(object sender, RoutedEventArgs e)
        {
            var currentNavigationColumn = Grid.GetColumn(movableMenuNavigation);

            var newLocation = currentNavigationColumn == 0 ? 2 : 0;

            Grid.SetColumn(movableMenuNavigation,newLocation);

            var buttonSymbol = newLocation == 0 ? Symbol.Forward : Symbol.Back;

            moveButtonIcon.Symbol = buttonSymbol;

        }

        private void ButtonToggleTheme_Click(object sender, RoutedEventArgs e)
        {
            this.RequestedTheme = RequestedTheme == ElementTheme.Dark ?
                ElementTheme.Light : ElementTheme.Dark;
        }
    }
}
