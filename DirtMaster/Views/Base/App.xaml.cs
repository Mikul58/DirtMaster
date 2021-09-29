using DirtMaster.Service;
using DirtMaster.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DirtMaster
{
    public partial class App : Application
    {


        public App()
        {
            InitializeComponent();
            Task.Run(async () => await UserService.CreateUserAsync("sebix", "test"));
            MainPage = new NavigationPage(new MainPage());
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
