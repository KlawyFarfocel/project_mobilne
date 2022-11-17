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
        private const bool V = false;
        private const bool T = true;
        public int counter = 0;
        public int whereX = 0;
        public int whereY = 0;
        public string LabirynthChoice = "lab1";
        public LabirynthPage()
        {
            InitializeComponent();
        }
        readonly bool[,] lab1 = {//gora,lewo,dol,prawo
            {V,V,T,T},
            {V,V,V,V},
            {V,V,V,V},
            {V,V,V,V},
            {V,V,V,V},
            {V,V,V,V},

            {V,V,T,V},
            {T,V,V,T},
            {V,V,T,T},
            {T,V,T,V},
            {T,V,V,T},
            {V,V,V,V},

            {V,V,V,V},
            {V,T,T,V},
            {T,T,V,T},
            {V,V,V,V},
            {V,T,T,T},
            {T,V,V,V},

            {V,V,V,V},
            {V,V,V,V},
            {V,T,V,T},
            {V,V,V,V},
            {V,T,V,V},
            {V,V,V,V},

            {V,V,V,V},
            {V,V,V,V},
            {V,T,V,V},
            {V,V,V,V},
            {V,V,V,V},
            {V,V,V,V},
        };
        readonly int Lab1WinX = 3;
        readonly int Lab1WinY = 4;
        readonly int Lab1StartingX = 1;
        readonly int Lab1StartingY = 0;

        void AmIWinning()
        {
            if (whereX == Lab1WinX)
            {
                if(whereY== Lab1WinY)
                {
                    DisplayAlert("Notice", "Win", "Ok");
                    return;
                }
                return;
            }
        }
        private void moveBlock(int HowMuch)
        {
            var blockName = "Kwadrat" + counter;
            var a = (Label)FindByName(blockName);
            a.IsVisible = V;
            counter += HowMuch;
            blockName = "Kwadrat" + counter;
            a = (Label)FindByName(blockName);
            a.IsVisible = true;
            AmIWinning();
        }
        private void GoRight(object sender, EventArgs e)
        {
            if (whereX==4){
                return;
            }
            if (lab1[counter, 3] == false)
            {
                DisplayAlert("Notice", "Ściana", "Ok");
            }
            else
            {
                whereX++;
                moveBlock(6);
            }
        }
        private void GoLeft(object sender, EventArgs e)
        {
            if (whereX == 0)
            {
                return;
            }
            if (lab1[counter, 1] == false)
            {
                DisplayAlert("Notice", "Ściana", "Ok");
            }
            else
            {
                whereX--;
                moveBlock(-6);
            }
        }
        private void GoUp(object sender, EventArgs e)
        {
            if (whereY == 0)
            {
                return;
            }

            if (lab1[counter, 0] == false)
            {
                DisplayAlert("Notice", "Ściana", "Ok");
            }
            else
            {
                whereY--;
                moveBlock(-1);
            }
        }
        private void GoDown(object sender, EventArgs e)
        {
            if (whereY == 5)
            {
                DisplayAlert("Notice", "Za duzo", "Ok");
                return;
            }

            if (lab1[counter, 2] == false)
            {
                DisplayAlert("Notice", "GoDown", "Ok");
            }
            else
            {
                whereY++;
                moveBlock(1);
            }
        }
        protected override void OnAppearing()
        {
            DisplayAlert("Notice", LabirynthChoice, "Ok");
            counter = (Lab1StartingX * 6) + Lab1StartingY;
            var StartName = "Kwadrat" + counter;
            whereX = Lab1StartingX;
            whereY = Lab1StartingY;
            var StartBlock=(Label)FindByName(StartName);
            StartBlock.IsVisible= true;
        }
    }
}