namespace WPF4.Model
{
    public class UserInfo
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Sex { get; set; }
        public string Birthday { get; set; }
        public string Age { get; set; }
        public string PhoneNo { get; set; }
        public string Note { get; set; }

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
    }
}
