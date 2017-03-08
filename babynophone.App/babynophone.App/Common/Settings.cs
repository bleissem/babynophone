using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace babynophone.App.Common
{
    public class Settings: ISettings
    {
        public Settings(IInitializeSettings initialize)
        {
            m_InitializeSettings = initialize;
        }

        private IInitializeSettings m_InitializeSettings;

    }
}
