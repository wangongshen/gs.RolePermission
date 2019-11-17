using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetDemo
{
    class UserInfo : IUserInfo
    {
        public string Name { get; set; }
        string Age;
        string sex;
        int num;

        public UserInfo(string Sex,int Num) {
            sex = Sex;
            num = Num;
        }
        
        public UserInfoDal userInfoDal { get; set; }
        public void Show()
        {
            userInfoDal.ShowDal();
            Console.WriteLine("Spring.Net,Name:"+Name+",Age:"+Age);
            Console.WriteLine("构造方法赋值，sex：" + sex);
            Console.WriteLine("构造方法赋值，num：" + num);
        }
    }
}
