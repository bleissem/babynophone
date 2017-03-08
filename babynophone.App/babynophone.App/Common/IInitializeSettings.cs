using SQLite.Net.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace babynophone.App.Common
{
    public interface IInitializeSettings
    {
        string DBPath { get; set; }
        ISQLitePlatform Platform { get; set; }
    }
}
