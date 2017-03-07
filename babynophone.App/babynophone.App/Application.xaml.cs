using babynophone.App.ViewModels;
using babynophone.App.Views;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace babynophone.App
{
    public partial class Application : PrismApplication
    {
        public Application(IPlatformInitializer initializer):base(initializer)
        {
     
        }        
            
        protected override void RegisterTypes()
        {
            UnityContainer container = base.Container as UnityContainer;
            container.RegisterType<MainViewModel>(new ContainerControlledLifetimeManager());
            Container.RegisterTypeForNavigation<MainPage>();
        }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync(nameof(MainPage));

        }

    }
}
