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
        public enum CallTypeEnum : int
        {
            SkypeUser = 0,
            SkypeOut = 1
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public CallTypeEnum CallType { get; set; }
        public int NoiseLevel { get; set; }
        public string NumberToDial { get; set; }
    }
}
