using babynophone.App.Common;
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
        public MainPageViewModel(INavigationService navigationService, ICall call)
        {
            m_NavigationService = navigationService;
            m_Call = call;

            InitializeText();
            
            ChooseContactCommand = new DelegateCommand(DoChooseContact);
            StartStopCommand = new DelegateCommand(DoStartStop, CanStartStop).ObservesCanExecute((obj)=>CanStartStop());            
        }

        private void InitializeText()
        {
            this.PleaseChooseLabel = Resources.Resource.PleaseChooseLabel;
            this.ChooseContactButton = Resources.Resource.ChooseContactButton;
            this.YouAreUsingLabel = Resources.Resource.YouAreUsingLabel;
            this.YouAreUsingText = string.Empty;
        }

        private ICall m_Call;
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

        public ICommand StartStopCommand
        {
            get;
            private set;
        }

        private bool CanStartStop()
        {
            return m_Call.CanCall();
        }

        public void DoStartStop()
        {
            m_Call.Call();
        }


        public ICommand ChooseContactCommand
        {
            get;
        }

        private void DoChooseContact()
        {
            m_NavigationService.NavigateAsync(nameof(ChooseSkypeUserPage));
        }

        private string m_StatusText;
        public string StatusText
        {
            get
            {
                return m_StatusText;
            }
            set
            {
                SetProperty(ref m_StatusText, value);
            }
        }


        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }
    }
}
