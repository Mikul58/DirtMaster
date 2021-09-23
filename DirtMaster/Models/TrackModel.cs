using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using DirtMaster.ViewModels.Base;

namespace DirtMaster.Models
{
    public class TrackModel : ITrackModel
    {
        [PrimaryKey]
        public int Id { get; set; }

        public string TrackName { get; set; }

        public string Length { get; set; }


        public TrackModel(string name, string length)
        {
            TrackName = name;
            Length = length;
        }

    }
}
