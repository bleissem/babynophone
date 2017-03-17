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
        public ChooseSkypeUserPageViewModel(ISettings settings, INavigationService navigationService, ISkypeViewModel skypeViewModel)
        {
            m_Settings = settings;
            m_NavigationService = navigationService;
            m_SkypeViewModel = skypeViewModel;
            ChooseSkypeUserOKButtonCommand = new DelegateCommand(DoChooseSkypeUserOK, CanChooseSkypeUserOK).ObservesProperty(()=>SkypeUser);
            
            InitializeText();
        }

        private void InitializeText()
        {
            this.ChooseSkypeUserLabel = Resources.Resource.ChooseSkypeUserLabel;
            this.m_ChooseSkypeUserOKButton = Resources.Resource.ChooseSkypeUserOKButton;
            this.SkypeUser = m_Settings.SkypeUser.SkypeUserName;
            this.UseVideoLabel = Resources.Resource.UseVideoLabel;
            this.SetSkypeInstalledText();
        }

        private void SetSkypeInstalledText()
        {
            this.SkypeIsInstalledText = m_SkypeViewModel.IsSkypeInstalled ? string.Empty : Resources.Resource.SkypeIsNotInstalledText1;
        }

        private ISettings m_Settings;
        private INavigationService m_NavigationService;
        private ISkypeViewModel m_SkypeViewModel;

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

        public string UseVideoLabel
        {
            get;
            private set;
        }

        public bool UseVideo
        {
            get
            {
                return m_Settings.SkypeUser.UseVideo;
            }
            set

            {
                m_Settings.SkypeUser.UseVideo = value;
                base.OnPropertyChanged(()=>UseVideo);
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

        private string m_SkypeIsInstalledText;
        public string SkypeIsInstalledText
        {
            get
            {
                return m_SkypeIsInstalledText;
            }
            set
            {
                SetProperty(ref m_SkypeIsInstalledText, value);
            }
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            this.SetSkypeInstalledText();
        }
    }
}
