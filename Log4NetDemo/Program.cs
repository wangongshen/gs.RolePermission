using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4NetDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            //从配置文件App.config或web.config中读取log4net的配置，然后进行一个初始化工作（让当前的Log4net起作用）
            log4net.Config.XmlConfigurator.Configure();
            //怎样写日志 需要导入log4net;命名空间
            ILog logWriter = log4net.LogManager.GetLogger("DemoWriter");//获取一个日志记录器（申明一个能实现Ilog接口 的对象, DemoWriter可以自己指定，后日志记录中会记录的）
            logWriter.Info("一般用来反馈系统的当前状态给最终用户的");
            logWriter.Debug("sssss调试级别的消息");
            logWriter.Error("ccccc错误级别的消息");
        }
    }
}
