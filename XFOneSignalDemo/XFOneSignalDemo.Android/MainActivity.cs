using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Com.OneSignal;
using System.Threading.Tasks;
using Android.Content;
using Xamarin.Forms;

namespace XFOneSignalDemo.Droid
{
    [Activity(Label = "XFOneSignalDemo", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            OneSignal.Current
                .StartInit("app-id-here")
                .InFocusDisplaying(Com.OneSignal.Abstractions.OSInFocusDisplayOption.Notification)
                .EndInit();

            DependencyService.Register<OpenAppService>();
            DependencyService.Register<CloseAppService>();

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());

            
        }
    }
}

