using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gra
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class deadPage : ContentPage
    {
        public deadPage(double soundtrackVolume)
        {
            InitializeComponent();
            var obj = (MediaElement)Application.Current.Resources["sound"];
            obj.Stop();
            Animation(soundtrackVolume);
            

        }
        async void Animation(double soundtrackVolume)
        {
            var deadAnimation = (Image)FindByName("dead");
            soundtrack.Volume = 1;
            deadAnimation.IsAnimationPlaying = true;
            await Task.Delay(3500);
            await Navigation.PushModalAsync(new MainPage(soundtrackVolume, true));
        }
    }
}