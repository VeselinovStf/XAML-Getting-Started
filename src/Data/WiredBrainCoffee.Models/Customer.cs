using WiredBrainCoffee.Models.Base;

namespace WiredBrainCoffee.Models
{
    public class Customer : ObservableBase
    {
        private string _firstName;
        private string _lastName;
        private bool _isDeveloper;

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChange();
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChange();
            }
        }

        public bool IsDeveloper
        {
            get => _isDeveloper;
            set
            {
                _isDeveloper = value;
                OnPropertyChange();
            }
        }
    }
}
