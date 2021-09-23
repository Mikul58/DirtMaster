using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DirtMaster.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginOrRegisterTabbedPage : TabbedPage
    {
        public LoginOrRegisterTabbedPage()
        {
            InitializeComponent();
        }
    }
}