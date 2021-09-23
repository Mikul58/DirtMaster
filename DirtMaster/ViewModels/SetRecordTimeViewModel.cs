using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DirtMaster.Models;
using DirtMaster.ViewModels.Base;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace DirtMaster.ViewModels
{
    public class SetRecordTimeViewModel : BaseViewModel
    {
        private IRegionModel _currentRegion = null;
        public IRegionModel CurrentRegion
        {
            get { return _currentRegion; }
            set
            {
                _currentRegion = value;
                OnPropertyChanged();
            }
        }
        private ITrackModel _currentTrack = null;
        public ITrackModel CurrentTrack
        {
            get { return _currentTrack; }
            set
            {
                _currentTrack = value;
                OnPropertyChanged();
            }
        }
        private string _time = null;

        public string Time
        {
            get { return _time; }
            set
            {
                _time = value;
                OnPropertyChanged();
            }
        }

        private bool _isValid;
        public bool IsValid
        {
            get { return _isValid; }
            set
            {
                _isValid = value;
                OnPropertyChanged();
            }
        }

        public ICommand PopNavigationCommand { get; set; }
        public ICommand SetSubmitButtonCommand { get; set; }

        public SetRecordTimeViewModel(INavigation navigation, IRegionModel InjectedRegion, ITrackModel InjectedTrack)
        {
            Navigation = navigation;
            CurrentRegion = InjectedRegion;
            CurrentTrack = InjectedTrack;

            PopNavigationCommand = new AsyncCommand(async () => await Navigation.PopAsync());
            SetSubmitButtonCommand = new AsyncCommand(async () => await CheckAndValidateTime());
        }

        async Task CheckAndValidateTime()
        {
            string minutes = null, seconds = null;
            int numbersToCheck = 5;

            var tasks = new List<Task>();

            if (_time.Length < 9 || _time[0] == '-')
            {
                IsValid = false;
                return;
            }
            tasks.Add(Task.Run (() => 
                {
                for (int i = 0; i < numbersToCheck; i++)
                {
                    if (i < 2) minutes += _time[i];
                    else if (i == 2) continue;
                    else
                        seconds += _time[i];
                }
            }));
            await Task.WhenAll(tasks);
            if (Convert.ToInt32(minutes) < 60 && Convert.ToInt32(seconds) < 60)
            {
                IsValid = true;
            }
            else
            {
                IsValid = false;
            }
        }
    }
}
