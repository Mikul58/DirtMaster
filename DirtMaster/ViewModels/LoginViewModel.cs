using DirtMaster.Models;
using DirtMaster.Service;
using DirtMaster.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace DirtMaster.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        private string _name = null;

        public string Name
        {
            get { return _name; }
            set 
            {
                _name = value; 
                OnPropertyChanged(); 
            }
        }

        private string _password = null;

        public string Password
        {
            get { return _password; }
            set 
            {
                _password = value;
                OnPropertyChanged(); 
            }
        }

        private bool _isUserValid = true;

        public bool IsUserValid
        {
            get { return _isUserValid; }
            set 
            {
                _isUserValid = value;
                OnPropertyChanged();
            }
        }

        public ICommand CheckIsUserValidCommand { get; set; }

        public LoginViewModel(INavigation navigation)
        {
            Navigation = navigation;
            CheckIsUserValidCommand = new AsyncCommand(async () => await CheckIfCorrectUserAndPasswordAsync());
        }

        async Task CheckIfCorrectUserAndPasswordAsync()
        {
            IsUserValid = await UserService.CheckIfUserValidAsync(Name, Password);
            if (IsUserValid == true) await Navigation.PopToRootAsync();
        }
    }
}
