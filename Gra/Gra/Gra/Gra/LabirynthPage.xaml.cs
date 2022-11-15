using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Gra
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LabirynthPage : ContentPage
    {
        public LabirynthPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            for(int i = 0; i < 30; i++)
            {
                var blockName = "Kwadrat" + i;
            }
            for (var i = 0; i < 30; i++)
            {
              //  LabirynthBox name= new LabirynthBox(true, true, true, true, name);

            }
        }
    }
}