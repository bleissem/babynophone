using babynophone.App.Common;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace babynophone.App.ViewModels
{
    public class MainViewModel: BindableBase, ICall
    {
        public MainViewModel(ISettings settings, ISkypeViewModel skypeViewModel)
        {
            m_SkypeViewModel = skypeViewModel;
            m_Settings = settings;
        }

        ~MainViewModel()
        {
            Dispose(false);
        }

        private ISkypeViewModel m_SkypeViewModel;
        private ISettings m_Settings;


        public bool CanCall()
        {
            var settingsCallType = m_Settings.MasterSetting.CallType;
            switch (settingsCallType)
            {
                case Settings.CallTypeEnum.SkypeUser:
                    {
                        return m_SkypeViewModel.CanCall();
                    }
                default:
                    {
                        throw new Exception($"unknown call type: {settingsCallType.ToString()}");
                    }
            }
        }

        public void Call()
        {
            var settingsCallType = m_Settings.MasterSetting.CallType;
            switch (settingsCallType)
            {
                case Settings.CallTypeEnum.SkypeUser:
                    {
                        m_SkypeViewModel.Call();
                        break;
                    }
                default:
                    {
                        throw new Exception($"unknown call type: {settingsCallType.ToString()}");
                    }
            }
        }

        private void Dispose(bool disposing)
        {

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
