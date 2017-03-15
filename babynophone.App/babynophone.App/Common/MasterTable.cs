using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace babynophone.App.Common
{
    [Table("Master")]
    public class MasterTable
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public Settings.CallTypeEnum CallType { get; set; }
        public int NoiseLevel { get; set; }
        public string NumberToDial { get; set; }
    }
}
