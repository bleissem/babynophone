using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Interop;

namespace babynophone.App.Common
{
    public class InitializeSettings : IInitializeSettings
    {
        public InitializeSettings(string dbPath, ISQLitePlatform platform)
        {
            DBPath = dbPath;
            Platform = platform;
        }
        public string DBPath
        {
            get;
            set;
        }

        public ISQLitePlatform Platform
        {
            get;
            set;
        }
    }
}
