using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gs.RolePermission.Common
{
    public class Log4NetWriter : ILogWrite
    {
        public void WriteLogInfo(string txt)
        {
            ILog logWriter = log4net.LogManager.GetLogger("Writer");
            logWriter.Error(txt);
        }
    }
}
