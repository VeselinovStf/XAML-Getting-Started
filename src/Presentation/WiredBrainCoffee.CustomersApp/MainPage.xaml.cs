using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WiredBrainCoffee.CustomersApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void AddCustomerButton_ClickHandler(object sender, RoutedEventArgs e)
        {
            var messageDialog = new MessageDialog("Custommer Added");
            await messageDialog.ShowAsync();
        }

        private void MoveNavigation_Click(object sender, RoutedEventArgs e)
        {
            var currentNavigationColumn = (int)movableMenuNavigation.GetValue(Grid.ColumnProperty);

            var newLocation = currentNavigationColumn == 0 ? 2 : 0;

            movableMenuNavigation.SetValue(Grid.ColumnProperty, newLocation);

            var buttonSymbol = newLocation == 0 ? Symbol.Forward : Symbol.Back;

            moveButtonIcon.Symbol = buttonSymbol;

        }
    }
}
