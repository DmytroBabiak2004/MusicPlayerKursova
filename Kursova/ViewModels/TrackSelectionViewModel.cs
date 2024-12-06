using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Kursova.Models;

namespace Kursova.ViewModels
{
    public class TrackSelectionViewModel
    {
        public ObservableCollection<Track> AvailableTracks { get; }
        public Track SelectedTrack { get; set; }
        public ICommand ConfirmTrackSelectionCommand { get; }

        public TrackSelectionViewModel(ObservableCollection<Track> tracks)
        {
            AvailableTracks = tracks;
            ConfirmTrackSelectionCommand = new RelayCommand<object>((param) => ConfirmSelection(param));
        }


        private void ConfirmSelection(object parameter)
        {
            if (parameter is Window window)
            {
                window.DialogResult = true;
                window.Close();
            }
        }
    }
}
