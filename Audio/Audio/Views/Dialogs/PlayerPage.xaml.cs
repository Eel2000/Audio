using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Rg.Plugins.Popup.Pages;
using Audio.ViewModels;

namespace Audio.Views.Dialogs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerPage : PopupPage
    {
        public PlayerPage()
        {
            InitializeComponent();
            BindingContext = new PlayerViewModel(true);
        }
    }
}