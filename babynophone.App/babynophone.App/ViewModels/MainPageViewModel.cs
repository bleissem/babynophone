using babynophone.App.Views;
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
    public class MainPageViewModel: BindableBase, INavigationAware
    {
        public MainPageViewModel(INavigationService navigationService)
        {
            InitializeText();
            m_NavigationService = navigationService;
            ChooseContactCommand = new DelegateCommand(DoChooseContact);
        }

        private void InitializeText()
        {
            this.PleaseChooseLabel = Resources.Resource.PleaseChooseLabel;
            this.ChooseContactButton = Resources.Resource.ChooseContactButton;
            this.YouAreUsingLabel = Resources.Resource.YouAreUsingLabel;
            this.YouAreUsingText = string.Empty;
        }

        private INavigationService m_NavigationService;

        private string m_PleaseChooseLabel;
        public string PleaseChooseLabel
        {
            get
            {
                return m_PleaseChooseLabel;
            }
            set
            {
                SetProperty(ref m_PleaseChooseLabel, value);
            }
        }

        private string m_ChooseContactButton;
        public string ChooseContactButton
        {
            get
            {
                return m_ChooseContactButton;
            }
            set
            {
                SetProperty(ref m_ChooseContactButton, value);
            }
        }

        private string m_YouAreUsingLabel;
        public string YouAreUsingLabel
        {
            get
            {
                return m_YouAreUsingLabel;
            }
            set
            {
                SetProperty(ref m_YouAreUsingLabel, value);
            }
        }

        private string m_YouAreUsingText;
        public string YouAreUsingText
        {
            get
            {
                return m_YouAreUsingText;
            }
            set
            {
                SetProperty(ref m_YouAreUsingText, value);
            }
        }

        private string m_ChooseNoiseLevelButton;
        public string ChooseNoiseLevelButton
        {
            get
            {
                return m_ChooseNoiseLevelButton;
            }
            set
            {
                SetProperty(ref m_ChooseNoiseLevelButton, value);
            }
        }

        private string m_ChooseNoiseLevelLabel;
        public string ChooseNoiseLevelLabel
        {
            get
            {
                return m_ChooseNoiseLevelLabel;
            }
            set
            {
                SetProperty(ref m_ChooseNoiseLevelLabel, value);
            }
        }

        private string m_CurrentNoiseLevel;
        public string CurrentNoiseLevel
        {
            get
            {
                return m_CurrentNoiseLevel;
            }
            set
            {
                SetProperty(ref m_CurrentNoiseLevel, value);
            }
        }

        private string m_StartStopButton;
        public string StartStopButton
        {
            get
            {
                return m_StartStopButton;
            }
            set
            {
                SetProperty(ref m_StartStopButton, value);
            }
        }


        public ICommand ChooseContactCommand
        {
            get;
        }

        private void DoChooseContact()
        {
            m_NavigationService.NavigateAsync(nameof(ChooseSkypeUserPage));
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }
    }
}
