using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;
using static Xamarin.Essentials.Permissions;

namespace Gra
{ 
    public partial class MainPage : ContentPage
    {
        public MainPage(double dalej=0,bool hasLost=false)
        {
            Application.Current.Resources.Clear();
            InitializeComponent();
            if (dalej == 0)
                dalej = 1;
            soundtrack.Volume = dalej;
            CheckIfLost(hasLost);
        }
        bool CheckIfLost(bool hasLost)
        {
            if(hasLost == true)
            {
                Navigation.ShowPopup(new TryAgainPopup());
                return true;
            }
            return true;
        }
        async protected override void OnAppearing()
        {
            base.OnAppearing();
            var status= await Permissions.CheckStatusAsync<Permissions.Camera>();
            if (status==PermissionStatus.Unknown || status == PermissionStatus.Denied)
            {
                await Permissions.RequestAsync<Permissions.Camera>();
            }
        }
        async void GoToSettings(object sender, EventArgs e)
        {
            soundtrack.Stop();
            double dalej1 = soundtrack.Volume;
            await Navigation.PushAsync(new SettingsPage(dalej1));
        }
        void ChangeLight(object sender, EventArgs e)
        {
            var mainGrid=(Grid)FindByName("MainGrid");
            var lightBulbIcon = (ImageButton)FindByName("BulbButton");
            var settingsIcon = (ImageButton)FindByName("SettingsButton");
            var titleImage = (Image)FindByName("Title");
            var arrow_up = (Image)FindByName("arrow_up");
            var arrow_down = (Image)FindByName("arrow_down");
            var wrongButton = (Image)FindByName("StartButton");
            var TextModeButton = (Button)FindByName("TextModeButton");
            var GameModeButton = (Button)FindByName("GameModeButton");
            
            if (lightBulbIcon.ClassId == "0")
            {
                lightBulbIcon.Source = "lightbulb_light";
                settingsIcon.Source = "cogwheel_light";
                mainGrid.BackgroundColor=Color.Black;
                titleImage.BackgroundColor=Color.Black;
                arrow_down.IsVisible = false;
                arrow_up.IsVisible = false;
                wrongButton.IsVisible = false;

                TextModeButton.IsVisible = true;
                GameModeButton.IsVisible = true;
                TextModeButton.BorderColor = GameModeButton.BorderColor=Color.White;
                TextModeButton.TextColor = GameModeButton.TextColor = Color.White;
                TextModeButton.BorderWidth=GameModeButton.BorderWidth=2;
                lightBulbIcon.ClassId= "1";
            }
            else
            {
                mainGrid.BackgroundColor = Color.Gray;
                titleImage.BackgroundColor= Color.Gray; 
                lightBulbIcon.Source = "lightbulb";
                settingsIcon.Source = "cogwheel";
                lightBulbIcon.ClassId = "0";
                arrow_up.IsVisible = true;
                arrow_down.IsVisible = true;
                wrongButton.IsVisible = true;
                GameModeButton.IsVisible = false;
                TextModeButton.IsVisible = false;
            }
        }
        async void WrongButtonClicked(object sender, EventArgs e)
        {
            soundtrack.Stop();
            var deadAnimation = (Image)FindByName("dead");
            var mainGrid = (Grid)FindByName("MainGrid");
            var lightBulbIcon = (ImageButton)FindByName("BulbButton");
            var settingsIcon = (ImageButton)FindByName("SettingsButton");
            var TextModeButton = (Button)FindByName("TextModeButton");
            var GameModeButton = (Button)FindByName("GameModeButton");
            mainGrid.BackgroundColor = Color.Black;
            lightBulbIcon.ClassId = "0";
            ChangeLight(sender,e);
            lightBulbIcon.IsVisible = false;
            settingsIcon.IsVisible = false;
            TextModeButton.IsVisible = false;
            GameModeButton.IsVisible = false;
            deadAnimation.IsAnimationPlaying= true;
            deadAnimation.IsVisible = true;
            await Task.Delay(3500);
            System.Environment.Exit(0);
        }
        async void GoToTextMode(object sender, EventArgs e)
        {
            soundtrack.Stop();
            var dalej1=soundtrack.Volume;
            await Navigation.PushModalAsync(new Page1(dalej1));
        }
        async void GoToGameMode(object sender, EventArgs e)
        {
            soundtrack.Stop();
            var dalej1 = soundtrack.Volume;
            await Navigation.PushModalAsync(new LabirynthPage(dalej1));
        }
        protected override bool OnBackButtonPressed()
        {
            GoToMenu();
            return true;
        }
        async void GoToMenu()
        {
            var MenuState = await Navigation.ShowPopupAsync(new GoToMenuPopup(true));
            if ((string)MenuState == "exit")
            {
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
        }
    }
}
