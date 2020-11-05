using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WiredBrainCoffee.Models;

namespace WiredBrainCoffee.CustomersApp.Controls
{
    public sealed partial class CustomerDetailsControl : UserControl
    {
        private Customer _custome;

        public CustomerDetailsControl()
        {
            this.InitializeComponent();
        }


        public Customer Customer
        {
            get { return _custome; }
            set
            {
                _custome = value;

                firstNameText.Text = _custome?.FirstName ?? "";
                lastNameText.Text = _custome?.LastName ?? "";
                isDeveloperCheckBox.IsChecked = _custome?.IsDeveloper;
            }
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
            if (Customer != null)
            {
                Customer.FirstName = firstNameText.Text;
                Customer.LastName = lastNameText.Text;
                Customer.IsDeveloper = isDeveloperCheckBox.IsChecked.GetValueOrDefault();
            }
        }
    }
}
