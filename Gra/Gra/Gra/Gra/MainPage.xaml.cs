using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gra
{ 
    public partial class MainPage : ContentPage
    {    
        public MainPage(double dalej)
        {
            InitializeComponent();
            DisplayAlert("Notice", dalej.ToString(), "OK");

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            arrow_1 = (Label)FindByName("arrow_1");
            arrow_2 = (Label)FindByName("arrow_2");
            arrow_3 = (Label)FindByName("arrow_3");
            arrow_4 = (Label)FindByName("arrow_4");
            bigRed = (Button)FindByName("bigRed");
            Animate_pulse(arrow_1);
            Animate_pulse(arrow_2);
            Animate_pulse(arrow_3);
            Animate_pulse(arrow_4);
            animate_button(bigRed);
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
        void animate_button (Button obj)
        {
            var Objname = obj.ClassId;
            var a = new Animation {
                {0,0.5, new Animation(v => obj.Opacity = v, 1, 0) },
                {0.5,1, new Animation(v => obj.Opacity = v, 0, 1) }
            };
            a.Commit(this, Objname, 16, 2750, Easing.CubicIn, (v, c) => obj.Opacity = 1, () => true);
        }
        //Przechodzenie do ustawień
        private async void GoToSettings(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage()); 
        }
        private async void Bluetooth(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page1());
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

            var ButtonDalej = (Button)FindByName("ForwardButton");
            var MainGrid = (Grid)FindByName("MainGrid");
            var bulbButton = (ImageButton)FindByName("BulbButton");

            var arrow_1 = (Label)FindByName("arrow_1");
            var arrow_2 = (Label)FindByName("arrow_2");
            var arrow_3 = (Label)FindByName("arrow_3");
            var arrow_4 = (Label)FindByName("arrow_4");
            var bigRed = (Button)FindByName("bigRed");
            var smolRed = (Button)FindByName("bigDarkRed");

            if (bulbButton.ClassId == "0")
            {
                ToBlack(title);
                ToBlack(footer);
                footer.Text = "";
                title.Text = "";
                ButtonDalej.BorderWidth = 3;
                ButtonDalej.BorderColor = Color.White;
                ButtonDalej.TextColor = Color.White;
                MainGrid.BackgroundColor = Color.Black;
                bulbButton.ClassId = "1";
                ButtonDalej.IsVisible = true;
                arrow_1.IsVisible = false;
                arrow_2.IsVisible = false;
                arrow_3.IsVisible = false;
                arrow_4.IsVisible = false;
                bigRed.IsVisible = false;
                smolRed.IsVisible = false;
            }
            else if (bulbButton.ClassId == "1")
            {
                ToWhite(title);
                ToWhite(footer);
                footer.Text = "Stopka";
                title.Text = "Tytuł";
                MainGrid.BackgroundColor = Color.Gray;
                ButtonDalej.IsVisible = false;
                arrow_1.IsVisible = true;
                arrow_2.IsVisible = true;
                arrow_3.IsVisible = true;
                arrow_4.IsVisible = true;
                bigRed.IsVisible = true;
                smolRed.IsVisible = true;  
                bulbButton.ClassId = "0";
            }
        }
        async void WrongButtonClicked(object sender, EventArgs e)
        {
            ChangeLight(sender,e);
            var ButtonDalej = (Button)FindByName("ForwardButton");
            var bulbButton = (ImageButton)FindByName("BulbButton");
            var settingsButton= (Button)FindByName("SettingsButton");
            var deadAnimation = (Image)FindByName("deadAnimation");
            ButtonDalej.IsVisible = false;
            bulbButton.IsVisible = false;
            settingsButton.IsVisible = false;
            deadAnimation.IsVisible = true;
            deadAnimation.IsAnimationPlaying = true;
            await Task.Delay(3500);
            System.Environment.Exit(0);
        }
    }
}
