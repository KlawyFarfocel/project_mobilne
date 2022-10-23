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
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
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