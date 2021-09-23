using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirtMaster.Service;
using DirtMaster.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DirtMaster.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddRecordPage : ContentPage
    {
        public AddRecordPage()
        {
            InitializeComponent();
            BindingContext = new AddRecordViewModel(Navigation);
        }
    }
}