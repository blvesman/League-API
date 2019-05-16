using LeagueAPI.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAPI.View.ViewModel
{
    public class ViewModelMain : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void INotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));
        }

        string region;

        public string Region
        {
            get { return region; }
            set { region = value; Constants.Region = value; INotifyPropertyChanged("Region"); }
        }

        string summonerName;

        public string SummonerName
        {
            get { return summonerName; }
            set { summonerName = value; INotifyPropertyChanged("SummonerName"); }
        }
    }
}
