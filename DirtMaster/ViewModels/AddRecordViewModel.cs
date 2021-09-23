using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DirtMaster.Models;
using DirtMaster.Service;
using DirtMaster.ViewModels.Base;
using DirtMaster.Views;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace DirtMaster.ViewModels
{
    public class AddRecordViewModel : BaseViewModel
    {
        private ObservableCollection<IRegionModel> _regions = new ObservableCollection<IRegionModel>();

        public ObservableCollection<IRegionModel> Regions
        {
            get { return _regions; }
            set
            {
                _regions = value;
                OnPropertyChanged();
            }
        }

        private IRegionModel _currentRegion = null;
        public IRegionModel CurrentRegion 
        {
            get { return _currentRegion; } 
            set
            {
                _currentRegion = value;
                CurrentTrackList = _currentRegion.TrackList;
                OnPropertyChanged();
            }
        }


        private ObservableCollection<ITrackModel> _currentTrackList = new ObservableCollection<ITrackModel>();
        public ObservableCollection <ITrackModel> CurrentTrackList
        {
            get { return _currentTrackList; }
            set
            {
                _currentTrackList = value;
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

        public ICommand ReturnToMainPageCommand { get; set; }
        public ICommand NavigateToSetRecordTimeCommand { get; set; }

        public AddRecordViewModel(INavigation navigation)
        {
            Navigation = navigation;
            ReturnToMainPageCommand = new AsyncCommand(async () => await Navigation.PopToRootAsync());
            NavigateToSetRecordTimeCommand = new AsyncCommand
                (async () => await Navigation.PushAsync(new SetRecordTimePage(CurrentRegion, CurrentTrack)));
            Task.Run(async () => await LoadTracksFromService());
        }

        async Task LoadTracksFromService()
        {
            Regions = await LoadTracksService.InitializeRegionsAndTracks();
        }


    }
}
