using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace babynophone.App.Common
{
    [Table("SkypeUserTable")]
    public class SkypeUserSettingTable
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string SkypeUserName { get; set; }
        public bool UseVideo { get; set; }
    }
}
