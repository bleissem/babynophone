using babynophone.App.Common;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace babynophone.App.ViewModels
{
    public class ChooseSkypeUserPageViewModel: BindableBase, INavigationAware
    {
        public ChooseSkypeUserPageViewModel(ISettings settings, INavigationService navigationService)
        {
            m_Settings = settings;
            m_NavigationService = navigationService;
            ChooseSkypeUserOKButtonCommand = new DelegateCommand(DoChooseSkypeUserOK, CanChooseSkypeUserOK).ObservesProperty(()=>SkypeUser);
            
            InitializeText();
        }

        private void InitializeText()
        {
            this.ChooseSkypeUserLabel = Resources.Resource.ChooseSkypeUserLabel;
            this.m_ChooseSkypeUserOKButton = Resources.Resource.ChooseSkypeUserOKButton;
            this.SkypeUser = m_Settings.SkypeUser.SkypeUserName;

        }

        private ISettings m_Settings;
        private INavigationService m_NavigationService;

        private string m_ChooseSkypeUserLabel;
        public string ChooseSkypeUserLabel
        {
            get
            {
                return m_ChooseSkypeUserLabel;
            }
            set
            {
                SetProperty(ref m_ChooseSkypeUserLabel, value);
            }
        }

        public string SkypeUser
        {
            get
            {
                return m_Settings.SkypeUser.SkypeUserName;
            }
            set
            {
                m_Settings.SkypeUser.SkypeUserName = value;
                base.OnPropertyChanged(()=>SkypeUser);
            }
        }

        private string m_ChooseSkypeUserOKButton;
        public string ChooseSkypeUserOKButton
        {
            get
            {
                return m_ChooseSkypeUserOKButton;
            }
            set
            {
                SetProperty(ref m_ChooseSkypeUserOKButton, value);
            }
        }

        private void DoChooseSkypeUserOK()
        {
            m_NavigationService.GoBackAsync();
        }

        private bool CanChooseSkypeUserOK()
        {
            return !string.IsNullOrWhiteSpace(SkypeUser);
        }

        public ICommand ChooseSkypeUserOKButtonCommand
        {
            get;
            private set;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }
    }
}
