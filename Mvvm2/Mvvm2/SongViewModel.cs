using System.ComponentModel;
using System.Windows.Input;

namespace Mvvm2
{
    public class SongViewModel : INotifyPropertyChanged
    {
        private int _count = 0;

        public SongViewModel()
        {
            Song = new Song { ArtistName = "Unknown", SongTitle = "Unknown" };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string ArtistName
        {
            get { return Song.ArtistName; }
            set
            {
                if (Song.ArtistName != value)
                {
                    Song.ArtistName = value;
                    RaisePropertyChanged("ArtistName");
                }
            }
        }

        public Song Song { get; set; }

        public ICommand UpdateArtistName
        {
            get
            {
                return new RelayCommand(UpdateArtistNameExecute, CanUpdateArtistNameExecute);
            }
        }

        private bool CanUpdateArtistNameExecute()
        {
            return true;
        }

        private void RaisePropertyChanged(string propertyName)
        {
            // take a copy to prevent thread issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void UpdateArtistNameExecute()
        {
            ++_count;
            ArtistName = string.Format("Elvis ({0})", _count);
        }
    }
}