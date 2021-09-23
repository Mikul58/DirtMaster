using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DirtMaster.Models
{
    public class RegionModel : IRegionModel
    {
        [PrimaryKey]
        public int Id { get; set; }
        public ObservableCollection<ITrackModel> TrackList { get; set; }
        public string RegionName { get; set; }
        public RegionModel(string name, int id, ObservableCollection<ITrackModel> list)
        {
            TrackList = list;
            RegionName = name;
            Id = id;
        }
    }
}
