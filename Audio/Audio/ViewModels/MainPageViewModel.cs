using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using Rg.Plugins.Popup.Services;
using Audio.Views.Dialogs;
using System.Windows.Input;
using Xamarin.Forms;
using Audio.Services;
using Xamarin.Essentials;

namespace Audio.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private string _playPause;
        private bool _isPlaying = false;

        public string PlayPause
        {
            get => _playPause;
            set => SetProperty(ref _playPause, value);
        }


        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "BridgePlayer";
            PlayPause = "play.png";
            

            //OpenPlayerCommand = ReactiveCommand.CreateFromTask(async () =>
            //{
            //    await PopupNavigation.Instance.PushAsync(new PlayerPage(), true);
            //});
            OpenPlayerCommand = new Command(async () =>
            {
                System.Diagnostics.Debug.WriteLine("player page opened", "Command MainPage");
                await PopupNavigation.Instance.PushAsync(new PlayerPage(), true);
            });

            PlayPauseCommand = new Command(() =>
            {
                _isPlaying = !_isPlaying;
                PlayPause = _isPlaying ? "pause.png" : "play.png";
            });

            OpenListenRecentlyPage = new Command(async () =>
            {
                await NavigationService.NavigateAsync("RecentMusicPage");
                System.Diagnostics.Debug.WriteLine("Navigated to RecentMusicPage", "MainPageViewModel");
            });
        }

        //ReactiveCommand<Unit, Unit> OpenPlayerCommand { get; }
        public ICommand OpenPlayerCommand { get; set; }
        public ICommand PlayPauseCommand { get; set; }
        public ICommand OpenListenRecentlyPage { get; set; }

    }
}
