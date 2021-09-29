using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using DirtMaster.ViewModels.Base;
using DirtMaster.Views;
using System.Reflection;
using System.IO;
using DirtMaster.Models;
using System.Collections.ObjectModel;
using DirtMaster.Service;

namespace DirtMaster.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Commands
        public ICommand NavigateToAddRecordCommand { get; set; }
        public ICommand NavigateToMyTimesCommand { get; set; }
        public ICommand NavigateToRecordsCommand { get; set; }
        #endregion

        #region Constructor
        public MainPageViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            if (UserService.IsUserLogged == false) Task.Run(async () => await navigation.PushAsync(new LoginPage()));
            NavigateToAddRecordCommand = new Command(async () => await Navigation.PushAsync(new AddRecordPage()));
            NavigateToMyTimesCommand = new Command(async () => await Navigation.PushAsync(new MyTimesPage()));
            NavigateToRecordsCommand = new Command(async () => await Navigation.PushAsync(new RecordsPage()));
        }
        #endregion

        #region Helpers
        #endregion


    }
}
