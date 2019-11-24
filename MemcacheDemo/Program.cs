using Memcached.ClientLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemcacheDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            //分布Memcached服务IP:端口
            //string[] servers = { "192.168.1.113:11211", "192.168.202.128:11211" };
            string[] servers = { "127.0.0.1:11211" };
            //初始化池。通俗说pool就是与mm服务器端交换数据的对象，通过它设置连接mm服务器端相关属性
            SockIOPool pool = SockIOPool.GetInstance();
            //设置服务器列表
            pool.SetServers(servers);
            //初始化时创建连接数
            pool.InitConnections = 3;
            //最小连接数
            pool.MinConnections = 3;
            //最大连接数
            pool.MaxConnections = 5;
            //socket连接的超时时间，如果为0表示不超时（单位ms），即一直保持链接状态
            pool.SocketConnectTimeout = 1000;
            //通讯的超时时间，下面设置为3秒（单位ms），
            pool.SocketTimeout = 3000;
            //维护线程的间隔激活时间，下面设置为30秒（单位s），设置为0时表示不启用维护线程
            pool.MaintenanceSleep = 30;
            //设置SocktIO池的故障标志
            pool.Failover = true;
            //是否对TCP/IP通讯使用nalgle算法，
            pool.Nagle = false;
            pool.Initialize();
            //客户端实例
            MemcachedClient mc = new Memcached.ClientLibrary.MemcachedClient();
            //是否启用压缩数据：如果启用了压缩，数据压缩长于门槛的数据将被以压缩的形式存储
            mc.EnableCompression = false;
            //mc.Add("keyxdz", "1ssss");//这个时候数据存储到哪里去了呢（某一台机器缓存）？根据mm客户端集群原理可理解
            //mc.Set("keyxdz3", "2ssss", DateTime.Now.AddDays(1));//表示有效期为1天

            mc.Delete("keyxdz3");//删除键为keyxdz的值，之后通过MM的命令提示符窗口也不到key为keyxdz的值了
            string s = mc.Get("keyxdz3").ToString();
            Console.WriteLine(s);//输出2ssss
        }
    }
}
