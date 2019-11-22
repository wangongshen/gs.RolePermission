using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace gs.RolePermission.Common
{
    public delegate void WriteLogDel(string str);//定义一个接受一个字符串参数的委托
    public class LogHelper
    {
        //接口类型的集合
        public static List<ILogWrite> LogWriterList = new List<ILogWrite>();

        //定义一个静态队列集合Queue<string>，只要出现异常就把异常消息加入到这个队列里来(队列是存放在内存中的)
        public static Queue<string> ExceptionStringQueue = new Queue<string>();

        public static WriteLogDel WriteLogDelFunc;//委托类型变量

        //往文件里写错误消息/日志信息
        public static void WriteLogToFile(string txt)
        { 
        
         } //尚不写实现代码
        //往Mongodb里写错误消息
        public static void WriteLogToMongodb(string txt)
        {
        
         }//尚不写实现代码

        //把错误信息写入到队列里去
        public static void WriteLog(string exceptionText)
        {
            lock (ExceptionStringQueue)
            {
                ExceptionStringQueue.Enqueue(exceptionText);//错误信息入队，即是加入到Queue<string>集合末尾
            }
        }

        static LogHelper()
        {
            // 构造函数的开始就向该集合里面添加想往哪里写的对象实例，需要多个就多次Add方法即可。向集合里面添加不同的观察者
            //LogWriterList.Add(new TextFileWriter());
            //LogWriterList.Add(new SqlServerWriter());
            LogWriterList.Add(new Log4NetWriter());

            //WriteLogDelFunc = new WriteLogDel(WriteLogToFile);//这就是写入到日志文件
            //WriteLogDelFunc += WriteLogToMongodb;//如果还要写入到Mongdb中去，就用多播委托。如果还要写入到数据库里面去，就再加一个方法，然后再加一条多播委托语句就OK了。

            //把从队列里获取的错误消息写到日志文件里面去
            //此处的委托参数o能否省略，即改为（），不能，因为QueueUserWorkItem方法必须有一个参数。
            ThreadPool.QueueUserWorkItem(o =>
            {
                //不断循环队列中的消息
                while (true)
                {
                    if (ExceptionStringQueue.Count > 0)
                    {
                        lock (ExceptionStringQueue)
                        {
                            string str = ExceptionStringQueue.Dequeue();//出队
                                                                        //出队之后，把错误信息写到日志文件里面去。当然以后需求可能发生变化，比如写到数据库里面去，同时写到日志文件和数据库文件里面去等。
                                                                        //我们希望不管怎么变化，我们代码改变最小。——用观察者模式，弄个委托
                                                                        //WriteLogDelFunc(str);

                            //ILogWrite write = new TextFileWriter();
                            ////ILogWrite write = new SqlServerWriter();
                            //write.WriteLogInfo(str);

                            //写入多个地方
                            foreach (var logWriter in LogWriterList)
                            {
                                logWriter.WriteLogInfo(str);
                            }
                        }
                    }
                    else {
                        Thread.Sleep(30);//如果队列中没有消息，让线程睡眠30毫秒
                    }
                       
                }
            });
        }
    }
}
