using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RedisClient("m.xmbygy.com", 6380);//这两个参数的值要事先在配置文件Redis.conf里有配置的,两个参数分别为host、port
                                                               //安装Redis服务后，最好不要让其在外网环境下面裸奔，可以为其设置一个复杂的访问密码，这样可以防止暴力破解
                                                               //配置文件中设置了访问密码，即加入了requirepass 123456789xdz，123456789xdz表示密码，则需要下面语句。
                                                               //client.Password = "123456789xdz"; 
                                                               //Redis最基本功能——分布式缓存
            client.Password = "redis0820";
            #region 常用数据类型：string
            client.Set<string>("key13", "xdz123");
            //string name = client.Get<string>("name");
            //Console.WriteLine(name);
            #endregion
            #region 常用数据类型：string
            //client.Add<string>("key11", "value11", DateTime.Now.AddMinutes(20));//为Redis缓存增加1条记录
            //string s = client.Get<string>("key11");
            //Console.WriteLine(s);
            #endregion
            #region 常用数据类型：set
            //client.AddItemToSet("HighSchool", "王斌");
            //client.AddItemToSet("HighSchool", "曹浩华");
            //client.AddItemToSet("HighSchool", "彭文将");
            //HashSet<string> hashset1 = client.GetAllItemsFromSet("HighSchool");
            //foreach (var item in hashset1)
            //{
            //    Console.WriteLine(item);//输出为值：王斌、曹浩华、彭文将
            //}
            #endregion
            #region 有序集合 sorted set
            //最后一个参数为我们排序的依据
            //client.AddItemToSortedSet("12", "百度", 400);//第1个参数为key，第2个参数为value，第3个参数为排序依据，自己指定。加入到同一个集合，所以key都相同为12
            //client.AddItemToSortedSet("12", "谷歌", 300);
            //client.AddItemToSortedSet("12", "阿里", 200);
            //client.AddItemToSortedSet("12", "新浪", 100);
            //client.AddItemToSortedSet("12", "人人", 500);

            ////升序获取第一个值: "新浪"
            //var list = client.GetRangeFromSortedSet("12", 0, 0);//第1个参数为key，第2个参数为从第几个，第3个参数为到第几个，表示从0个到0个，即表示第1个
            ////var list = client.GetRangeFromSortedSet("12", 0, 2);//第1个参数为key，第2个参数为从第几个，第3个参数为到第几个，表示从0个到2个，即表示第1、2、3个，下面输出即为新浪、阿里、谷歌
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}

            ////降序获取一个值: "人人"
            //list = client.GetRangeFromSortedSetDesc("12", 0, 0);

            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region 数据结构：队列
            //client.EnqueueItemOnList("LogQueue", "错误1……");//入队，键与下面同为LogQueue，说明进入的是同一个队列
            //client.EnqueueItemOnList("LogQueue", "错误2……");//入队
            ////============输出一条记录方法==========
            //string str1 = client.DequeueItemFromList("LogQueue");//出队
            //Console.WriteLine(str1);//先进先出，所以输出为：错误1
            //                        //============输出全部记录方法==========
            //long length = client.GetListCount("LogQueue");
            //for (int i = 0; i < length; i++)
            //{
            //    Console.WriteLine(client.DequeueItemFromList("LogQueue"));
            //}
            #endregion
            #region 数据结构：栈
            //client.PushItemToList("jinzhan", "入栈值1");
            //client.PushItemToList("jinzhan", "入栈值2");
            ////============输出一条记录方法==========
            //string str2 = client.PopItemFromList("jinzhan");
            //Console.WriteLine(str2);//先进后出，后进先出，所以这里输出为：入栈值2
            ////============输出全部记录方法==========
            //long length1 = client.GetListCount("jinzhan");
            //for (int i = 0; i < length1; i++)
            //{
            //    Console.WriteLine(client.PopItemFromList("jinzhan"));
            //}
            #endregion
            string name = client.Get<string>("key13");
            Console.WriteLine(name);
            Console.ReadKey();
        }
    }
}
