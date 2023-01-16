using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gra
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TryAgainPopup : Popup
    {
        public TryAgainPopup()
        {
            InitializeComponent();
        }
        void DismissPopup(object sender, EventArgs e)
        {
            Dismiss("");
        }
    }

}