using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetDemo
{
    class UserInfoDal : IUserInfo
    {
        public void Show()
        {
            Console.WriteLine("Spring.Net666");
        }
    }
}
