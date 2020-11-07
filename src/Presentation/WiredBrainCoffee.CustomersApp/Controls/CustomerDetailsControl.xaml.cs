using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WiredBrainCoffee.Models;

namespace WiredBrainCoffee.CustomersApp.Controls
{
    public sealed partial class CustomerDetailsControl : UserControl
    {
        public CustomerDetailsControl()
        {
            this.InitializeComponent();
        }

        public Customer Customer
        {
            get { return (Customer)GetValue(CustomerProperty); }
            set { SetValue(CustomerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Customer.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CustomerProperty =
            DependencyProperty.Register("Customer", typeof(Customer), 
                typeof(CustomerDetailsControl), new PropertyMetadata(null, CustomerChangeCallback));

        private static void CustomerChangeCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is CustomerDetailsControl customerDetailsControl)
            {
                var customer = e.NewValue as Customer;
                customerDetailsControl.firstNameText.Text = customer?.FirstName ?? "";
                customerDetailsControl.lastNameText.Text = customer?.LastName ?? "";
                customerDetailsControl.isDeveloperCheckBox.IsChecked = customer?.IsDeveloper;
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
