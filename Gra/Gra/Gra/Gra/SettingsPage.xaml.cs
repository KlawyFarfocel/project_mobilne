using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gra
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage(double dalej1)
        {
            InitializeComponent();
            soundtrack.Volume = dalej1;
            slid.Value = dalej1*100;

        }
        double dalej = 0;

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            
            double value = e.NewValue / 100;
            double valtext = e.NewValue;
            soundtrack.Volume = value;
            sliderval.Text = valtext.ToString();
            dalej = value;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            // double dalej = 12;
            soundtrack.Stop();
            await Navigation.PushAsync(new MainPage(dalej));
        }
        /* async void OnButtonClicked(object sender, EventArgs e)
{
    await App.database.SavePersonAsync(new Class1
         {

        Vol = int.Parse(sliderval.Text)
    });
}
*/
    }
}