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
using XFOneSignalDemo.Droid;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(CloseAppService))]
namespace XFOneSignalDemo.Droid
{
    class CloseAppService : Activity, ICloseAppService
    {
        public void CloseApp()
        {
            (Xamarin.Forms.Forms.Context as Activity).Finish();
        }
    }
}