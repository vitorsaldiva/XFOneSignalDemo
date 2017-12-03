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
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(OpenAppService))]
namespace XFOneSignalDemo.Droid
{
    
    class OpenAppService : Activity, IOpenAppService
    {
        public Task<bool> Launch(string uri)
        {
            try
            {
                Intent intent = Android.App.Application.Context.PackageManager.GetLaunchIntentForPackage(uri);

                if (intent != null)
                {
                    intent.AddFlags(ActivityFlags.NewTask);
                    Forms.Context.StartActivity(intent);
                }
                else
                {
                    intent = new Intent(Intent.ActionView);
                    intent.AddFlags(ActivityFlags.NewTask);
                    intent.SetData(Android.Net.Uri.Parse("market://details?id=" + uri));
                    Forms.Context.StartActivity(intent);
                }

                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }
    }
}