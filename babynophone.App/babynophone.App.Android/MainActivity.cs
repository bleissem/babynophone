using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Prism;
using Prism.Unity;
using Microsoft.Practices.Unity;
using babynophone.App.Common;
using SQLite.Net.Platform.XamarinAndroid;
using babynophone.App.ViewModels;

namespace babynophone.App.Droid
{
    [Activity(Label = "babynophone.App", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, AlwaysRetainTaskState = true, LaunchMode = LaunchMode.SingleInstance)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, IProvidePackageManager
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App.Application(new AndroidInitializer(this)));
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public AndroidInitializer(MainActivity mainActivity)
        {
            m_MainActivity = mainActivity;
        }

        private MainActivity m_MainActivity;

        public void RegisterTypes(IUnityContainer container)
        {
            container.RegisterInstance<IInitializeSettings>(new InitializeSettings(
                System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "BabyNoPhone.Settings.db3"), 
                new SQLitePlatformAndroid()), 
                new ContainerControlledLifetimeManager());

            container.RegisterType<ICreateTimer, MyTimerCreator>(new ContainerControlledLifetimeManager());
            container.RegisterType<IAudioRecorder, AudioRecorder>(new ContainerControlledLifetimeManager());
            container.RegisterInstance<ITurnOnOffScreen>(new TurnOnOffScreen(m_MainActivity.Window), new ContainerControlledLifetimeManager());

            container.RegisterInstance<IProvidePackageManager>(m_MainActivity);


            container.RegisterType<SkypeViewModel>(new ContainerControlledLifetimeManager());
            container.RegisterType<ISkypeViewModel, SkypeViewModel>();

            container.RegisterType<MainViewModel>(new ContainerControlledLifetimeManager());
            container.RegisterType<ICall, MainViewModel>();
            m_MainActivity = null;
        }
    }
}

