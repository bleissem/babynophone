using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace babynophone.App.Common
{
    public class Settings: ISettings
    {
        public enum CallTypeEnum : int
        {
            SkypeUser = 0
        }


        public Settings(IInitializeSettings initialize)
        {
            m_InitializeSettings = initialize;
            MasterSetting = new MasterSetting(initialize);
            SkypeUser = new SkypeUserSetting(initialize);
        }

        private IInitializeSettings m_InitializeSettings;

        public ISettingsSkypeUser SkypeUser
        {
            get;
            private set;
        }

       public IMasterSetting MasterSetting
        {
            get;
            private set;
        }
    }
}
