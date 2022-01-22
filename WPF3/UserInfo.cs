using System;
using System.Collections.Generic;
using System.Linq;
namespace WPF3
{
    // 바인딩할 리스트 반환
    public class UserInfo
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }

        public UserInfo(string name, string age, string addr, string phoneNo)
        {
            Name = name;
            Age = age;
            Address = addr;
            PhoneNo = phoneNo;
        }
    }
}
