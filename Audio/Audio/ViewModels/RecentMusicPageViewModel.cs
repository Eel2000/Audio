using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using ReactiveUI;
using System.Collections.ObjectModel;
using Audio.Models;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Audio.Customs;
using System.Linq;
using Audio.Context;

namespace Audio.ViewModels
{
    public class RecentMusicPageViewModel : BindableBase
    {

        private ObservableCollection<Song> songs;


        public ObservableCollection<Song> RecentPlayed
        {
            get => songs;
            set => SetProperty(ref songs, value);
        }

        public string Title => "Listen recently";
        public RecentMusicPageViewModel()
        {
            LoadingData();
        }

        protected async void LoadingData()
        {
            try
            {
                var recently = LiteDbContext.Database.GetCollection<Song>().Query().ToList().Take(10);
                if (!recently.Any())
                {
                    await App.Current.MainPage.DisplaySnackBarAsync(Notification.DisplaySnackBarAsync("There is no recent songs."));
                    return;
                }
                RecentPlayed = new ObservableCollection<Song>(recently);
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplaySnackBarAsync(Notification.DisplaySnackBarAsync(e.Message));
            }
        }
    }
}
