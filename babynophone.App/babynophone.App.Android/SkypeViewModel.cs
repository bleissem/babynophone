using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using babynophone.App.Common;
using Android.Content.PM;

namespace babynophone.App.Droid
{
    public class SkypeViewModel : ISkypeViewModel
    {
        public SkypeViewModel(IProvidePackageManager packageManagerProvider)
        {
            m_ProvidePackageManager = packageManagerProvider;
        }

        ~SkypeViewModel()
        {
            Dispose(false);
        }

        private IProvidePackageManager m_ProvidePackageManager;

        public bool IsSkypeInstalled
        {
            get
            {
                PackageManager pm = m_ProvidePackageManager.PackageManager;
                try
                {
                    pm.GetPackageInfo("com.skype.raider", PackageInfoFlags.Activities);
                }
                catch (PackageManager.NameNotFoundException ex)
                {
                    return false;
                }
                return true;
            }
        }

        public bool CanCall()
        {
            return true;
        }

        public void Call()
        {
            if (!CanCall()) return;


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