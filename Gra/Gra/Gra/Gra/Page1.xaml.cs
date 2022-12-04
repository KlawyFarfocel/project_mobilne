using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            
            /*
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

            if (passwd == "2137")
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
            */
            switch (passwd)
            {
                case "2077":
                    double dalej1 = 12;
                    Navigation.PushAsync(new Page2(dalej1));
                    break;
                case "2137":
                    double dalej2 = 12;
                    Navigation.PushAsync(new Page3(dalej2));
                    break;


                case "2115":
                    double dalej3 = 12;
                    Navigation.PushAsync(new Page4(dalej3));
                    break;

                default:
                    DisplayAlert("Notice", "Błędny kod", "OK");
                    break;
            }

        }
    }
}