using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetDemo
{
    class UserInfo : IUserInfo
    {
        public void Show()
        {
            Console.WriteLine("Spring.Net");
        }
    }
}
