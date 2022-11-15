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
        public int counter = 0;
        public LabirynthPage()
        {
            InitializeComponent();
        }
        private void GoRight(object sender, EventArgs e)
        {
            var blockName = "Kwadrat" + counter;
            var a = (Label)FindByName(blockName);
            a.IsVisible = false;
            counter += 6;
            blockName = "Kwadrat" + counter;
            a = (Label)FindByName(blockName);
            a.IsVisible = true;
        }
    }
}