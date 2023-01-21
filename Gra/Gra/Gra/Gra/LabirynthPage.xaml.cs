using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
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
        public bool TimeFlag = true;
        public int counter = 0;
        public int whereX = 0;
        public int whereY = 0;
        public int HealthCount = 3;
        static Random RandomLabirynthNumber = new Random();
        public string LabirynthChoice = "";
        public readonly int LabirynthNumberChoice = RandomLabirynthNumber.Next(101);
        public int TimeLeft = 90;

        public void end()
        {
            TimeFlag = false;
            double dalej1 = soundtrack.Volume;
            soundtrack.Stop();
            Navigation.PushModalAsync(new deadPage(dalej1));
        }
        async void SetTime()
        {
            await Navigation.ShowPopupAsync(new GamePopup("Labirynt"));
            Label TimeCount = (Label)FindByName("TimerCount");
            Label TimeBar = (Label)FindByName("Timer");
            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                if (TimeFlag == false)
                {
                    return false;
                }
                TimeLeft--;
                TimeCount.Text = TimeLeft.ToString();
                if (TimeLeft < 15)
                {
                    TimeCount.TextColor = Color.Red;
                    if (TimeLeft == 0)
                    {
                        TimeFlag = false;
                        end();
                        TimeCount.Text = "";
                        TimeBar.Text = TimeCount.Text;
                        return false;
                    }
                }
                return true;
            });
        }
        void GenerateLabirynthNumber()
        {
            if (LabirynthNumberChoice > 0 && LabirynthNumberChoice <= 50)
            {
                LabirynthChoice = "Lab1";
            }
            else LabirynthChoice = "Lab2";
        }
        
        public LabirynthPage(double dalej1)
        {
           // soundtrack.Volume = dalej1;
            InitializeComponent();

            soundtrack.Volume = dalej1;
            soundtrack.Play();
        }
        
        readonly bool[,] lab1 = {//gora,lewo,dol,prawo
            {V,V,V,V},
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
        
        readonly bool[,] lab2 = {//gora,lewo,dol,prawo
            {V,V,V,V},
            {V,V,V,V},
            {V,V,V,V},
            {V,V,V,V},
            {V,V,V,V},
            {V,V,V,V},

            {V,V,V,V},
            {V,V,T,T},
            {T,V,T,V},
            {T,V,T,V},
            {T,V,T,T},
            {T,V,V,V},

            {V,V,V,V},
            {V,T,V,T},
            {V,V,V,V},
            {V,V,V,T},
            {V,T,V,V},
            {V,V,V,V},

            {V,V,V,V},
            {V,T,V,T},
            {V,V,V,V},
            {V,T,T,T},
            {T,V,V,V},
            {V,V,V,V},

            {V,V,V,V},
            {V,T,T,V},
            {T,V,T,V},
            {T,T,T,V},
            {T,V,T,V},
            {T,V,T,V},
        };
        readonly int Lab2WinX = 4;
        readonly int Lab2WinY = 1;
        readonly int Lab2StartingX = 2;
        readonly int Lab2StartingY = 4;

      
        async void AmIWinning()
        {
            int LabWinX=0, LabWinY=0;  
            if (LabirynthChoice == "Lab1")
            {
                LabWinX = Lab1WinX;
                LabWinY = Lab1WinY;
            }
            if(LabirynthChoice == "Lab2")
            {
                LabWinX = Lab2WinX;
                LabWinY = Lab2WinY;
            }
            if (whereX == LabWinX)
            {
                if(whereY == LabWinY)
                {
                    TimeFlag = false;
                    double wynik = TimeLeft;
                    double dalej1 = soundtrack.Volume;
                     await Navigation.PushModalAsync(new ScrabblePage(dalej1,wynik)) ;
                   // await Navigation.PushModalAsync(new Page5(dalej1, wynik));
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
            a.IsVisible = T;
            AmIWinning();
        }
        private void GoRight(object sender, EventArgs e)
        {
            bool[,] LabTable= { };
            if(LabirynthChoice == "Lab1")
            {
                LabTable = lab1;
            }
            else if(LabirynthChoice == "Lab2")
            {
                LabTable= lab2;
            }
            if (whereX==4){
                return;
            }
            if (LabTable[counter, 3] == false)
            {
                HealthCount--;
                var text = "";
                for (int i = 0; i < HealthCount; i++)
                {
                   text+= '\u2764';
                }
                var HealthBar=(Label)FindByName("HealthBar");
                HealthBar.Text = text;           
                if(HealthCount <= 0)
                {
                    end();
                }
            }
            else
            {
                whereX++;
                moveBlock(6);
            }
        }
        private void GoLeft(object sender, EventArgs e)
        {
            bool[,] LabTable = { };
            if (LabirynthChoice == "Lab1")
            {
                LabTable = lab1;
            }
            else if (LabirynthChoice == "Lab2")
            {
                LabTable = lab2;
            }
            if (whereX == 0)
            {
                return;
            }
            if (LabTable[counter, 1] == false)
            {
                HealthCount--;
                var text = "";
                for (int i = 0; i < HealthCount; i++)
                {
                    text += '\u2764';
                }
                var HealthBar = (Label)FindByName("HealthBar");
                HealthBar.Text = text;              
                if (HealthCount <= 0)
                {
                    end();
                }
            }
            else
            {
                whereX--;
                moveBlock(-6);
            }
        }
        private void GoUp(object sender, EventArgs e)
        {
            bool[,] LabTable = { };
            if (LabirynthChoice == "Lab1")
            {
                LabTable = lab1;
            }
            else if (LabirynthChoice == "Lab2")
            {
                LabTable = lab2;
            }
            if (whereY == 0)
            {
                HealthCount--;
                var text = "";
                for (int i = 0; i < HealthCount; i++)
                {
                    text += '\u2764';
                }
                var HealthBar = (Label)FindByName("HealthBar");
                HealthBar.Text = text;
                if (HealthCount <= 0)
                {
                    end();
                }
                return;
            }

            if (LabTable[counter, 0] == false)
            {
                HealthCount--;
                var text = "";
                for (int i = 0; i < HealthCount; i++)
                {
                    text += '\u2764';
                }
                var HealthBar = (Label)FindByName("HealthBar");
                HealthBar.Text = text;           
                if (HealthCount <= 0)
                {
                    end();
                }
            }
            else
            {
                whereY--;
                moveBlock(-1);
            }
        }
        private void GoDown(object sender, EventArgs e)
        {
            bool[,] LabTable = { };
            if (LabirynthChoice == "Lab1")
            {
                LabTable = lab1;
            }
            else if (LabirynthChoice == "Lab2")
            {
                LabTable = lab2;
            }
            if (whereY == 5)
            {   
                HealthCount--;
                var text = "";
                for (int i = 0; i < HealthCount; i++)
                {
                    text += '\u2764';
                }
                var HealthBar = (Label)FindByName("HealthBar");
                HealthBar.Text = text;
               
                if (HealthCount <= 0)
                {
                    end();
                }
                return;
            }

            if (LabTable[counter, 2] == false)
            {   
                HealthCount--;
                var text = "";
                for (int i = 0; i < HealthCount; i++)
                {
                    text += '\u2764';
                }
                var HealthBar = (Label)FindByName("HealthBar");
                HealthBar.Text = text;
                if (HealthCount <= 0)
                {
                    end();
                }
            }
            else
            {
                whereY++;
                moveBlock(1);
            }
        }
        protected override bool OnBackButtonPressed()
        {
            GoToMenu();
            return true;
        }
        async void GoToMenu()
        {
            TimeFlag = false;
            var MenuState=await Navigation.ShowPopupAsync(new GoToMenuPopup());
            if ((string)MenuState == "false")
            {
                soundtrack.Stop();
                await Navigation.PushModalAsync(new MainPage(soundtrack.Volume));
            }
        }
        protected override void OnAppearing()
        {
            Application.Current.Resources.Add("sound", soundtrack);
            GenerateLabirynthNumber();
            SetTime();
            if (LabirynthChoice == "Lab1")
            {
                counter = (Lab1StartingX * 6) + Lab1StartingY;
                whereX = Lab1StartingX;
                whereY = Lab1StartingY;
            }
            else if (LabirynthChoice == "Lab2")
            {
                counter = (Lab2StartingX * 6) + Lab2StartingY;
                whereX = Lab2StartingX;
                whereY = Lab2StartingY;
            }
            var StartName = "Kwadrat" + counter;
            var StartBlock=(Label)FindByName(StartName);
            StartBlock.IsVisible= true;
        }
    }
}