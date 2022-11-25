using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gra
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1(double dalej1)
        {
            InitializeComponent();
        }

        private void ForwardButton_Clicked(object sender, EventArgs e)
        {
            string passwd = entry.Text;
            

            if (passwd == "2077")
            {
                //soundtrack.Stop();
                //double dalej1 = soundtrack.Volume;
                double dalej1 = 12;
                Navigation.PushAsync(new Page2(dalej1));
            }
            else
            {
                DisplayAlert("Notice", "Błędny kod", "OK");
            }
        }
    }
}