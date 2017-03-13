using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace babynophone.App.Common
{
    public class SkypeUserSetting : ISettingsSkypeUser
    {
        public SkypeUserSetting(IInitializeSettings initialize)
        {
            m_Initialize = initialize;
            Load();
        }

        private IInitializeSettings m_Initialize;

        private string m_SkypeUserName;
        public string SkypeUserName
        {
            get
            {
                return m_SkypeUserName;
            }
            set
            {
                if (m_SkypeUserName == value) return;
                m_SkypeUserName = value;
                this.Save();
            }
        }

        private void Load()
        {

            using (var db = new SQLite.Net.SQLiteConnection(m_Initialize.Platform, m_Initialize.DBPath))
            {

                db.CreateTable<SkypeUserSettingTable>();
                if (0 == db.Table<SkypeUserSettingTable>().Count())
                {
                    var newSettings = new SkypeUserSettingTable();
                    newSettings.SkypeUserName = string.Empty;

                    db.Insert(newSettings);
                }

                SkypeUserSettingTable table = db.Table<SkypeUserSettingTable>().First();

                SkypeUserName = table.SkypeUserName;
            }
        }

        private void Save()
        {

        }
    }
}
