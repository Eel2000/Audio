using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views.Options;
using Xamarin.Forms;

namespace Audio.Customs
{
    public static class Notification
    {
        public static SnackBarOptions DisplaySnackBarAsync( string message, int duration = 3000)
        {
            var messageOptions = new MessageOptions
            {
                Foreground = Color.White,
                Font = Font.SystemFontOfSize(17),
                Message = message
            };

            var snackBarActionOption = new SnackBarActionOptions
            {
                BackgroundColor = Color.FromHex("#000"),
                Font = Font.SystemFontOfSize(17),
            };

            var options = new SnackBarOptions
            {
                MessageOptions = messageOptions,
                Duration = TimeSpan.FromMilliseconds(duration),
                CornerRadius = new Thickness(5),
                IsRtl = false,
                Actions = new List<SnackBarActionOptions>() { snackBarActionOption }
            };

            return options;
        }
    }
}
