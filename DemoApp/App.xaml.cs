using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DemoApp.Styles;
using EventBus;
using DemoAppBackendApi.Events;
using DemoAppBackendApi;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DemoApp
{
    public partial class App : Application
    {
        public static string AppName = "DemoAppMarianHristov";

        public static string AppTheme { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            Gateway.Instance.Start();

            //App Theme Settings
            SetTheme(Application.Current.RequestedTheme);

            Application.Current.RequestedThemeChanged += (s, a) =>
            {
                MessageBus.Instance.Publish(new AppLifecycleEventResume("Resume Event Triggered", false));
                SetTheme(a.RequestedTheme);
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            MessageBus.Instance.Publish(new AppLifecycleEventFinishedLaunching("Finished Launching Triggered", false));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            MessageBus.Instance.Publish(new AppLifecycleEventSleep("Sleep Event Triggered", false));

        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            MessageBus.Instance.Publish(new AppLifecycleEventResume("Resume Event Triggered", false));
        }

        private void SetTheme(OSAppTheme appTheme)
        {
            switch (appTheme)
            {
                case OSAppTheme.Dark:
                    Current.Resources = new DarkTheme();
                    break;
                case OSAppTheme.Light:
                    Current.Resources = new LightTheme();
                    break;
                case OSAppTheme.Unspecified:
                    Current.Resources = new LightTheme();
                    break;
            }
        }
    }
}
