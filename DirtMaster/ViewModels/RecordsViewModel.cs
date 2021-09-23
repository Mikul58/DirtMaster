using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using DirtMaster.ViewModels.Base;

namespace DirtMaster.ViewModels
{
    class RecordsViewModel : BaseViewModel
    {
        private ObservableCollection<string> collection = new ObservableCollection<string>();

        public ObservableCollection<string> Collection
        {
            get { return collection; }
            set { collection = value; OnPropertyChanged(); }
        }

        private string tag;

        public string Tag
        {
            get { return tag; }
            set { tag = value; OnPropertyChanged(); }
        }


        public RecordsViewModel()
        {
            Collection.Add("Segwit");
            Collection.Add("Cryptocurrency");
            Collection.Add("Proof Of Work");
            Collection.Add("Payments");
            Collection.Add("Sha256");
            Collection.Add("Mining");
            Collection.Add("Lightning Network");
        }
    }
}
