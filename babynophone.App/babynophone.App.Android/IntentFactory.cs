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

namespace babynophone.App.Droid
{
    public class IntentFactory
    {
        public static Intent GetSkypeUserIntent(string user, bool enableVideo)
        {
            StringBuilder sbUri = new StringBuilder("skype:" + user + "?call");
            if (enableVideo)
            {
                sbUri.Append("&video=true");
            }
            Intent skypeintent = new Intent("android.intent.action.VIEW");
            skypeintent.SetData(Android.Net.Uri.Parse(sbUri.ToString()));
            return skypeintent;
        }

        public static Intent GetSkypeOutIntent(string tel)
        {
            Intent skypeintent = new Intent(Intent.ActionCall);
            skypeintent.SetClassName("com.skype.raider", "com.skype.raider.Main");
            skypeintent.SetData(Android.Net.Uri.Parse("tel:" + tel));
            return skypeintent;
        }
    }
}