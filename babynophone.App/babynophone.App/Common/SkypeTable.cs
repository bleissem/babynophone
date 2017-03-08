using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace babynophone.App.Common
{
    [Table("SkypeTable")]
    public class SkypeTable
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public bool IsSkypeVideoEnabled { get; set; }
    }
}
