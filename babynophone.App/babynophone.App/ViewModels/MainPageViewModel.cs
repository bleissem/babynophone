using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace babynophone.App.ViewModels
{
    public class MainPageViewModel: BindableBase, INavigationAware
    {
        public MainPageViewModel()
        {
            InitializeText();
        }

        private void InitializeText()
        {
            this.PleaseChooseLabel = Resources.Resource.PleaseChooseLabel;
            this.ChooseContactButton = Resources.Resource.ChooseContactButton;
        }

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
                base.SetProperty(ref m_ChooseContactButton, value);
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
