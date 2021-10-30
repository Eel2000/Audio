using Audio.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using LiteDB.Async;

namespace Audio.Services
{
    public static class SeedDataService
    {
        public static async void Seed()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("Start Seeding...", "BridgePlayer");
                var albums = new List<Album>()
                {
                    new Album
                    {
                        ID = Guid.NewGuid().ToString(),
                        Label = "Rock&ROll",
                        PublicationDate = DateTime.Now.AddYears(-2).ToString("D"),
                        Singer = "Uknown"
                    },
                    new Album
                    {
                        ID = Guid.NewGuid().ToString(),
                        Label = "Gospel",
                        PublicationDate = DateTime.Now.AddYears(-5).ToString("D"),
                        Singer = "Uknown"
                    },
                    new Album
                    {
                        ID = Guid.NewGuid().ToString(),
                        Label = "Classic",
                        PublicationDate = DateTime.Now.AddYears(-10).ToString("D"),
                        Singer = "Uknown"
                    },
                    new Album
                    {
                        ID = Guid.NewGuid().ToString(),
                        Label = "Pop",
                        PublicationDate = DateTime.Now.AddYears(-9).ToString("D"),
                        Singer = "Uknown"
                    },
                };

                var songs = new List<Song>();
                foreach (var album in albums)
                {
                    var albumSongs = new List<Song>()
                    {
                        new Song
                        {
                            ID = Guid.NewGuid().ToString(),
                            Album = album.Label,
                            AlbumID = album.ID,
                            Author = album.Singer,
                            LastPlayed = DateTime.Now,
                            Title="Call-me ya",
                            Duration = "3:05",
                            IsPlaying = false
                        },new Song
                        {
                            ID = Guid.NewGuid().ToString(),
                            Album = album.Label,
                            AlbumID = album.ID,
                            Author = album.Singer,
                            LastPlayed = DateTime.Now.AddDays(7),
                            Title="Call-me ya",
                            Duration = "2:50",
                            IsPlaying = false
                        },new Song
                        {
                            ID = Guid.NewGuid().ToString(),
                            Album = album.Label,
                            AlbumID = album.ID,
                            Author = album.Singer,
                            LastPlayed = DateTime.Now.AddDays(2),
                            Title="Call-me ya",
                            Duration = "4:00",
                            IsPlaying=false
                        },
                    };

                    songs.AddRange(albumSongs);
                }

                var recent = new RecentPlayed
                {
                    Songs = songs.Where(x => x.LastPlayed.Date <= DateTime.Now.AddDays(-7)).ToList()
                };

                var playLists = new List<PlayList>
                {
                    new PlayList
                    {
                        ID = Guid.NewGuid().ToString(),
                        CreationDate = DateTime.Now.AddDays(-2).ToString("F"),
                        Author = "Eliezer",
                        Name = "Sleep",
                        Songs = songs.Skip(2* 1).Take(2).ToList()
                    },
                    new PlayList
                    {
                        ID = Guid.NewGuid().ToString(),
                        CreationDate = DateTime.Now.AddDays(-3).ToString("F"),
                        Author = "Eliezer",
                        Name = "Ballad",
                        Songs = songs.Skip(2* 2).Take(2).ToList()
                    },
                    new PlayList
                    {
                        ID = Guid.NewGuid().ToString(),
                        CreationDate = DateTime.Now.AddDays(-5).ToString("F"),
                        Author = "Eliezer",
                        Name = "Relaxe",
                        Songs = songs.Skip(2* 3).Take(2).ToList()
                    },
                };

                Context.LiteDbContext.ClearDatabase();//Clean first database to make new insertions
                await Task.Delay(50);
                Context.LiteDbContext.Database.GetCollection<Album>().InsertBulk(albums);
                Context.LiteDbContext.Database.GetCollection<Song>().InsertBulk(songs);
                Context.LiteDbContext.Database.GetCollection<RecentPlayed>().Insert(recent);
                Context.LiteDbContext.Database.GetCollection<PlayList>().InsertBulk(playLists);

                System.Diagnostics.Debug.WriteLine("Seeding completed succefully...", "BridgePlayer");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e, "BridgePlayer");
            }
        }
    }
}
