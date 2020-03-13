using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.HelpMethods
{
    public static class Logging
    {
        public static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
    }
}
