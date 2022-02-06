using System;
using System.ComponentModel;
using System.Windows;

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

                if (!int.TryParse(_age, out int res) || (0 >= int.Parse(_age) || 130 < int.Parse(_age)))
                {
                    MessageBox.Show("나이를 다시 확인해주세요.", "Warning");
                    return;
                }

                //(10 <= int.Parse(_age) && int.Parse(_age) < 20) ? AgeRange="10대": (20 <= int.Parse(_age) && int.Parse(_age) < 30) ? AgeRange="20대" :
                if (0 <= int.Parse(_age) && int.Parse(_age) < 10)
                {
                    AgeRange = "10대 미만";
                }
                else if (10 <= int.Parse(_age) && int.Parse(_age) < 20)
                {
                    AgeRange = "10대";
                }
                else if (20 <= int.Parse(_age) && int.Parse(_age) < 30)
                {
                    AgeRange = "20대";
                }
                else if (30 <= int.Parse(_age) && int.Parse(_age) < 40)
                {
                    AgeRange = "30대";
                } 
                else if (40 <= int.Parse(_age) && int.Parse(_age) < 50)
                {
                    AgeRange = "40대";
                } 
                else if (50 <= int.Parse(_age) && int.Parse(_age) < 60)
                {
                    AgeRange = "50대";
                }
                else if (60 <= int.Parse(_age) && int.Parse(_age) < 70)
                {
                    AgeRange = "60대";
                }
                else if (70 <= int.Parse(_age) && int.Parse(_age) < 80)
                {
                    AgeRange = "70대";
                }
                else if (80 <= int.Parse(_age) && int.Parse(_age) < 90)
                {
                    AgeRange = "80대";
                }
                else if (90 <= int.Parse(_age) && int.Parse(_age) < 100)
                {
                    AgeRange = "90대";
                }else
                {
                    AgeRange = "90대 이상";
                }
                OnPropertyChanged(nameof(Age));
            }
        }

        private string _ageRange;
        public string AgeRange
        {
            get => _ageRange;
            set 
            {
                _ageRange = value;
                OnPropertyChanged(nameof(AgeRange));
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
                if (_sex != "남" && _sex != "여")
                {
                    MessageBox.Show("성별을 다시 확인해주세요.", "Warning");
                    //throw new Exception("성별오류");
                }
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
