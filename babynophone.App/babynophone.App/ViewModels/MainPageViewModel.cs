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
        public MainPageViewModel(MainViewModel mvm)
        {
            this.Title = "Hello Title";
        }

        private string m_Title;
        public string Title
        {
            get
            {
                return m_Title;
            }
            set
            {
                m_Title = value;
                base.OnPropertyChanged(() => Title);
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
