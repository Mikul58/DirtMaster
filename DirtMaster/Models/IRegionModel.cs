using System.Collections.ObjectModel;

namespace DirtMaster.Models
{
    public interface IRegionModel
    {
        int Id { get; set; }
        string RegionName { get; set; }
        ObservableCollection<ITrackModel> TrackList { get; set; }
    }
}