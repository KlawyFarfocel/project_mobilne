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
    public partial class GoToMenuPopup :  Popup
    {
        public MediaElement track;
        public bool ExitStatus;
        public GoToMenuPopup(bool ExitStatus=false)
        {
            InitializeComponent();
            this.ExitStatus= ExitStatus;
            if(ExitStatus == true) 
            {
                var PopupHeader = (Label)FindByName("PopupHeader");
                var PopupBody = (Label)FindByName("PopupBody");
                var LeaveButton = (Button)FindByName("LeaveButton");
                var StayButton = (Button)FindByName("StayButton");

                PopupHeader.Text = "Na pewno chcesz wyjść?";
                PopupBody.Text = "Będziemy tęsknić";
                PopupBody.TextColor = Color.Black;
                LeaveButton.Text = "Wychodzę!";
                StayButton.Text = "Zostaję!";
            }
        }
        async void GoToMenu(object sender, EventArgs e)
        {
            if (ExitStatus == false)
            {
                Dismiss("false");
            }
            else
            {
                Dismiss("exit");
            }
            
        } 
        async void DismissPopup(object sender, EventArgs e)
        {
            Dismiss("true");
        }
    }
}