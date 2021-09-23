using DirtMaster.Service;
using DirtMaster.Views;
using Xamarin.Forms;

namespace DirtMaster
{
    public partial class App : Application
    {


        public App()
        {
            InitializeComponent();
            if (!UserService.isUserLogged) MainPage = new LoginOrRegisterTabbedPage();
            else
            {
                MainPage = new NavigationPage(new MainPage());
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
