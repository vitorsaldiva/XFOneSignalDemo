using Com.OneSignal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace XFOneSignalDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new XFOneSignalDemo.MainPage();

            OneSignal.Current.
                // Conta teste
                StartInit("app-id-here")
                .InFocusDisplaying(Com.OneSignal.Abstractions.OSInFocusDisplayOption.Notification)
                .HandleNotificationOpened((result) =>
                {
                    try
                    {
                        DependencyService.Get<IOpenAppService>().Launch("app-uri");
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Launch error: {ex}");
                    }
                })
                .EndInit();

            OneSignal.Current.SendTag("city", "segment-filter here");

            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            DependencyService.Get<ICloseAppService>().CloseApp();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            DependencyService.Get<ICloseAppService>().CloseApp();
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
