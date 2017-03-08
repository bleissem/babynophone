using babynophone.App.Common;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace babynophone.App.ViewModels
{
    public class MainViewModel: BindableBase
    {
        public MainViewModel(ISettings settings)
        {
            m_Settings = settings;
        }

        private ISettings m_Settings;

    }
}
