namespace WPF3.Model
{
    public class UserInfo
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public UserInfo()
        {
        }

        public UserInfo(string name, string age, string addr, string phoneNo)
        {
            Name = name;
            Age = age;
            Address = addr;
            PhoneNo = phoneNo;
        }
    }
}
