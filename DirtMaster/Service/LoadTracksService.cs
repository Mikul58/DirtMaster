using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DirtMaster.Models;
using DirtMaster.ViewModels.Base;

namespace DirtMaster.Service
{
    public static class LoadTracksService
    {
        public static async Task<ObservableCollection<IRegionModel>> InitializeRegionsAndTracks()
        {
            ObservableCollection<IRegionModel> regionModels = new ObservableCollection<IRegionModel>();

            string trackLine = null;
            string regionLine = null;
            int counter = 0;

            var rmAssembly = IntrospectionExtensions.GetTypeInfo(typeof(RegionModel)).Assembly;
            Stream regionStream = rmAssembly.GetManifestResourceStream("DirtMaster.Regions.txt");

            var tmAssembly = IntrospectionExtensions.GetTypeInfo(typeof(TrackModel)).Assembly;
            Stream trackStream = tmAssembly.GetManifestResourceStream("DirtMaster.Tracks.txt");

               using ( var regionReader = new StreamReader(regionStream))
               {
                    while ((regionLine = await regionReader.ReadLineAsync()) != null)
                    {
                    counter++;
                    regionModels.Add(new RegionModel(regionLine, counter, new ObservableCollection<ITrackModel>()));

                    }
               }

               counter = 0;
           
               using (var trackReader = new StreamReader(trackStream))
               {
                   while ((trackLine = await trackReader.ReadLineAsync()) != null)
                   {
                       if (trackLine == "#")
                       {
                           counter++;
                       }
                       else
                       {
                           string[] splittedTrack = trackLine.Split(',');
                           regionModels[counter].TrackList.Add(new TrackModel(splittedTrack[0], splittedTrack[1]));
                       }
                   }
               }
               return regionModels;
        }
    }
}
