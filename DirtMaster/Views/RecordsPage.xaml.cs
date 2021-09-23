using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirtMaster.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DirtMaster
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecordsPage : ContentPage
    {
        public RecordsPage()
        {
            InitializeComponent();
            BindingContext = new RecordsViewModel();
        }
    }
}