using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirtMaster.Models
{
    class Record
    {
        [PrimaryKey, AutoIncrement]
        public int RecordID { get; set; }
        [Indexed]
        public int UserID { get; private set; }
        [Indexed]
        public int RegionModelID { get; private set; }
        [Indexed]
        public int TrackModelId { get; private set; }
        public string Time { get; private set; }

        public Record(int userID, int RMID, int TMID, string time)
        {
            UserID = userID;
            RegionModelID = RMID;
            TrackModelId = TMID;
            Time = time;
        }

    }
}
