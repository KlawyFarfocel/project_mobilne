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
    public partial class GamePopup : Popup
    {
        public GamePopup(string LevelName)
        {
            InitializeComponent();
            var CodeLabel = (Label)FindByName("CodeName");
            var GameDesc = (Label)FindByName("GameDesc");
            if (LevelName == "Labirynt")
            {
                CodeLabel.Text += "2077";
                GameDesc.Text = "Użyj klawiszy strzałek, aby przemieszczać się po labiryncie. Informacje o trasie uzyskasz od swojego partnera";
            }
            else if (LevelName == "Scrabble")
            {
                CodeLabel.Text += "2137";
                GameDesc.Text = "Współpracujcie, by odzyskać szyfr do zamka. Twój partner posiada listę haseł - więc komunikacja to klucz";
            }
            else if (LevelName == "Morse")
            {
                CodeLabel.Text += "2115";
                GameDesc.Text = "Zawsze marzyłeś o pracy w latarni. Teraz to twoja szansa - wykaż się znajomością kodu Morse-a";
            }
            else if (LevelName == "Kolorki")
            {
                CodeLabel.Text += "6969";
                GameDesc.Text = "Skonstruowałem ten zamek tak, by otworzył się po wciśnięciu kombinacji kolorów. Byłoby mi łatwiej, gdybym nie był daltonistą";
            }
            else if (LevelName == "Przycisk")
            {
                CodeLabel.Text += "2005";
                GameDesc.Text = "Na tym etapie zakładam, że wiesz co masz robić - jeden przycisk, prosta robota, co może pójść nie tak?";
            }
            else CodeLabel.Text += "undefined";
        }
        void DismissPopup(object sender,EventArgs e)
        {
            Dismiss(".");
        }
    }
}