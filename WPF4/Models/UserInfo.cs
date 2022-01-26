using System.ComponentModel;

namespace WPF4.Models
{
    public class UserInfo : INotifyPropertyChanged
    {
        private string _name;
        public string Name 
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _age;
        public string Age
        {
            get => _age;
            set
            {
                _age = value;
                OnPropertyChanged(nameof(Age));
            }
        }

        private string _phoneNo;
        public string PhoneNo
        {
            get => _phoneNo;
            set
            {
                _phoneNo = value;
                OnPropertyChanged(PhoneNo);
            }
        }

        private string _note;
        public string Note
        {
            get => _note;
            set
            {
                _note = value;
                OnPropertyChanged(Note);
            }
        }

        private string _address;
        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                OnPropertyChanged(Address);
            }
        }

        private string _sex;
        public string Sex
        {
            get => _sex;
            set
            {
                _sex = value;
                OnPropertyChanged(Sex);
            }
        }

        private string _bday;
        public string Birthday
        {
            get => _bday;
            set
            {
                _bday = value;
                OnPropertyChanged(Birthday);
            }
        }

        public UserInfo()
        {
        }

        public UserInfo(string name, string addr, string sex, string bday, string age, string phoneNo, string note)
        {
            Name = name;
            Address = addr;
            Sex = sex;
            Birthday = bday;
            Age = age;
            PhoneNo = phoneNo;
            Note = note;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
