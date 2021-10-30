using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Rg.Plugins.Popup.Services;

namespace Audio.ViewModels
{
    public class PlayerViewModel : ReactiveObject
    {
        private string _songTitle;
        private string _songAlbum;
        private string _songArtist;
        private string _playPause;
        private bool _isPlaying;

        public string PlayPause
        {
            get => _playPause;
            set => this.RaiseAndSetIfChanged(ref _playPause, value);
        }

        public PlayerViewModel(bool play)
        {
            _isPlaying = play;
            PlayPause = "play.png";
            PlayPauseCommand = new Command(() =>
            {
                _isPlaying = !_isPlaying;
                PlayPause = _isPlaying ? "pause.png" : "play.png";
            });

            CloseCommand = new Command(async () =>
            {
                await PopupNavigation.Instance.PopAsync();
                System.Diagnostics.Debug.WriteLine("player closed", "PlayerViewModel");
            });
        }
        public ICommand PlayPauseCommand { get;  }
        public ICommand CloseCommand { get;  }
    }
}
