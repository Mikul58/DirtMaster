using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirtMaster.Models;
using DirtMaster.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DirtMaster.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetRecordTimePage : ContentPage
    {
        public SetRecordTimePage(IRegionModel injectedRegion, ITrackModel injectedTrack)
        {
            InitializeComponent();
            BindingContext = new SetRecordTimeViewModel(Navigation, injectedRegion, injectedTrack);
        }
    }
}