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
        public MainPage(double dalej)
        {
            InitializeComponent();
            if (dalej == 0)
                dalej = 1;
            soundtrack.Volume = dalej;
        }
        async protected override void OnAppearing()
        {
            base.OnAppearing();
            arrow_1 = (Label)FindByName("arrow_1");
            arrow_2 = (Label)FindByName("arrow_2");
            arrow_3 = (Label)FindByName("arrow_3");
            arrow_4 = (Label)FindByName("arrow_4");
      //      bigRed = (Button)FindByName("bigRed");
      //      BulbButton = (ImageButton)FindByName("BulbButton");
            Animate_pulse(arrow_1);
            Animate_pulse(arrow_2);
            Animate_pulse(arrow_3);
            Animate_pulse(arrow_4);
           // animate_button(bigRed);
            var status= await Permissions.CheckStatusAsync<Permissions.Camera>();
            if (status==PermissionStatus.Unknown || status == PermissionStatus.Denied)
            {
                await Permissions.RequestAsync<Permissions.Camera>();
            }
        }
        void Animate_pulse(Label obj)
        {
            var Objname = obj.ClassId;
            var a = new Animation {
                {0,0.5, new Animation(v => obj.Scale = v, 1, 1.2) },
                {0.5,1, new Animation(v => obj.Scale = v, 1.2, 1) }               
            };
            a.Commit(this,Objname,16,950,Easing.Linear, (v, c) => obj.Scale = 1,()=> true);
        }
        void WersjaTestowa(object sender,EventArgs e)
        {
            DisplayAlert("Dziala","Ok","Ok");
        }
     /*  void animate_button (Button obj)
        {
            var Objname = obj.ClassId;
            var a = new Animation {
                {0,0.5, new Animation(v => obj.Opacity = v, 1, 0) },
                {0.5,1, new Animation(v => obj.Opacity = v, 0, 1) }
            };
            a.Commit(this, Objname, 16, 2750, Easing.CubicIn, (v, c) => obj.Opacity = 1, () => true);
        } */
        //Przechodzenie do ustawień
        private async void GoToSettings(object sender, EventArgs e)
        {
            soundtrack.Stop();
            double dalej1 = soundtrack.Volume;
             await Navigation.PushAsync(new SettingsPage(dalej1));

        }
        private async void GoToFlashlight(object sender, EventArgs e)
        {
            soundtrack.Stop();
            double dalej1 = soundtrack.Volume;
            await Navigation.PushAsync(new FlashlightPage());

        }

        private async void FirstTask(object sender, EventArgs e)
        {
            soundtrack.Stop();
            double dalej1 = soundtrack.Volume;
            await Navigation.PushAsync(new LabirynthPage(dalej1));
        }

        private async void MorseTask(object sender, EventArgs e)
        {
            soundtrack.Stop();
            double dalej1 = soundtrack.Volume;
            await Navigation.PushAsync(new Page5());
        }

        void ToBlack(Label obj)
        {
            obj.ColorTo(Color.Black);
            obj.TextColor=Color.White;
        }
        void ToWhite(Label obj)
        {
            obj.ColorTo(Color.White);
            obj.TextColor = Color.Black;
        }
        void ChangeLight(object sender, EventArgs e)
        {
            var title = (Label)FindByName("Tit");
            var footer=(Label)FindByName("Footer");

       //     var ButtonDalej = (Button)FindByName("LabirynthButton");
            var ButtonLatarka = (Button)FindByName("FlashlightButton");
     //       var ButtonMorse = (Button)FindByName("ButtonMorse");
            var ButtonTekstowy = (Button)FindByName("TextModeButton");
            var MainGrid = (Grid)FindByName("MainGrid");
            var bulbButton = (ImageButton)FindByName("BulbButton");
            var StartButton = (Image)FindByName("StartButton");

            var arrow_1 = (Label)FindByName("arrow_1");
            var arrow_2 = (Label)FindByName("arrow_2");
            var arrow_3 = (Label)FindByName("arrow_3");
            var arrow_4 = (Label)FindByName("arrow_4");

            if (bulbButton.ClassId == "0")
            {
                ToBlack(title);
                ToBlack(footer);
                footer.Text = "";
                title.Text = "";

     //           ButtonDalej.BorderWidth = 3;
      //          ButtonDalej.BorderColor = Color.White;
      //          ButtonDalej.TextColor = Color.White;

                ButtonLatarka.BorderWidth = 3;
                ButtonLatarka.BorderColor = Color.White;
                ButtonLatarka.TextColor = Color.White;

                ButtonTekstowy.BorderWidth = 3;
                ButtonTekstowy.BorderColor = Color.White;
                ButtonTekstowy.TextColor = Color.White;

     //           ButtonMorse.BorderWidth = 3;
     //           ButtonMorse.BorderColor = Color.White;
      //          ButtonMorse.TextColor = Color.White;

                MainGrid.BackgroundColor = Color.Black;
                bulbButton.ClassId = "1";
    //            ButtonDalej.IsVisible = true;
                ButtonTekstowy.IsVisible= true;
                ButtonLatarka.IsVisible = true;
   //             ButtonMorse.IsVisible = true;
                StartButton.IsVisible = false;   
                arrow_1.IsVisible = false;
                arrow_2.IsVisible = false;
                arrow_3.IsVisible = false;
                arrow_4.IsVisible = false;
            }
            else if (bulbButton.ClassId == "1")
            {
                ToWhite(title);
                ToWhite(footer);
                footer.Text = "Stopka";
                title.Text = "Tytuł";
                MainGrid.BackgroundColor = Color.Gray;
    //            ButtonDalej.IsVisible = false;
                ButtonTekstowy.IsVisible= false;
                ButtonLatarka.IsVisible = false;
   //             ButtonMorse.IsVisible = false;
                StartButton.IsVisible = true;
                arrow_1.IsVisible = true;
                arrow_2.IsVisible = true;
                arrow_3.IsVisible = true;
                arrow_4.IsVisible = true;
                bulbButton.ClassId = "0";
                bulbButton.IsVisible = true;
            }
        }
        async void WrongButtonClicked(object sender, EventArgs e)
        {
            ChangeLight(sender,e);
   //         var ButtonDalej = (Button)FindByName("LabirynthButton");
            var settingsButton= (Button)FindByName("SettingsButton");
            var BulbButton = (ImageButton)FindByName("BulbButton");
            var ButtonLatarka = (Button)FindByName("FlashlightButton");
            var ButtonTekstowy = (Button)FindByName("TextModeButton");
 //           var ButtonMorse = (Button)FindByName("ButtonMorse");
 //           ButtonDalej.IsVisible = false;
            ButtonTekstowy.IsVisible = false;
            ButtonLatarka.IsVisible = false;
            ButtonMorse.IsVisible = false;
            settingsButton.IsVisible = false;
            BulbButton.IsVisible = false;
            var deadAnimation = (Image)FindByName("deadAnimation");
            deadAnimation.IsVisible = true;
            deadAnimation.IsAnimationPlaying = true;
            await Task.Delay(3500);
            System.Environment.Exit(0);
        }

        private async void TextModeButton_Clicked(object sender, EventArgs e)
        {
            soundtrack.Stop();
            double dalej1 = soundtrack.Volume;
            await Navigation.PushAsync(new Page1(dalej1));
        }
    }
}
