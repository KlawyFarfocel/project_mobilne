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
    public partial class NamePopup : Popup
    {
        public NamePopup()
        {
            InitializeComponent();
        }
        void DismissPopUp(object sender, EventArgs e)
        {
            var EntryFrame = (Entry)FindByName("userName");
            if (EntryFrame.Text == "") Dismiss("undefined");
            Dismiss(EntryFrame.Text);
        }
    }
}