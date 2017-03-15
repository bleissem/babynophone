using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace babynophone.App.Common
{
    public class SkypeUserSetting : DBSettingBase<SkypeUserSettingTable>, ISettingsSkypeUser
    {
        public SkypeUserSetting(IInitializeSettings initialize):base(initialize)
        {
        }


        private string m_SkypeUserName;
        public string SkypeUserName
        {
            get
            {
                base.Load();
                return m_SkypeUserName;
            }
            set
            {
                if (m_SkypeUserName == value) return;
                m_SkypeUserName = value;
                this.Save();
            }
        }

        private bool m_IsSkypeVideoEnabled;
        public bool IsSkypeVideoEnabled
        {
            get
            {
                Load();
                return m_IsSkypeVideoEnabled;
            }
            set
            {
                if (m_IsSkypeVideoEnabled == value) return;
                m_IsSkypeVideoEnabled = value;
                Save();
            }
        }

        protected override void InitializeTable(SkypeUserSettingTable table)
        {
            table.IsSkypeVideoEnabled = false;
            table.SkypeUserName = string.Empty;
        }

        protected override void Load(SkypeUserSettingTable table)
        {
            this.SkypeUserName = table.SkypeUserName;

        }

        protected override void Save(SkypeUserSettingTable table)
        {
            table.SkypeUserName = this.SkypeUserName;
            table.IsSkypeVideoEnabled = this.IsSkypeVideoEnabled;
        }
    }
}
