using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gra
{ 
    public partial class MainPage : ContentPage
    {    
        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            arrow_1 = (Label)FindByName("arrow_1");
            arrow_2 = (Label)FindByName("arrow_2");
            arrow_3 = (Label)FindByName("arrow_3");
            arrow_4 = (Label)FindByName("arrow_4");
            bigRed = (Button)FindByName("bigRed");
            animate_pulse(arrow_1);
            animate_pulse(arrow_2);
            animate_pulse(arrow_3);
            animate_pulse(arrow_4);
            animate_button(bigRed);
        }
        void animate_pulse(Label obj)
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
      private async void OnButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("True!");
            await Navigation.PushAsync(new Page1());
        }
        

       
    }
}
