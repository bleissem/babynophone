using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace babynophone.App.Common
{
    public class MasterSetting: DBSettingBase<MasterTable>, IMasterSetting
    {
        public MasterSetting(IInitializeSettings initialize):base(initialize)
        {

        }

        protected override void InitializeTable(MasterTable table)
        {
            table.CallType = Settings.CallTypeEnum.SkypeUser;
        }

        protected override void Load(MasterTable table)
        {
            this.CallType = table.CallType;
        }

        protected override void Save(MasterTable table)
        {
            table.CallType = this.CallType;
        }

        private Settings.CallTypeEnum m_CallType;
        public Settings.CallTypeEnum CallType
        {
            get
            {
                Load();
                return m_CallType;
            }
            set
            {
                if (m_CallType == value) return;
                m_CallType = value;
                Save();
            }
        }

    }
}
