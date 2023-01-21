using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Xamarin.CommunityToolkit;
using System.Runtime.InteropServices.WindowsRuntime;
using Xamarin.CommunityToolkit.Extensions;
using Newtonsoft.Json.Converters;
using Xamarin.CommunityToolkit.UI.Views;

namespace Gra
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class FlashlightPage : ContentPage
    {
        public double wynik;
        public int HealthCount = 3;
        private const int Short = 1000;
        private const int Long = 3000;
        public bool TimeFlag = true;
        int[] BlockCounters = { 0, 0, 0, 0 };
        Random RandomCharCount = new Random();
        readonly int[,] MorseTable =
        {
            {Short,Short,Short,Short},
            {Short,Short,Short,Long},
            {Short,Short,Long,Long},
            {Short,Long,Short,Short},
            {Short,Long,Short,Long},
            {Short,Long,Long,Short},
            {Short,Long,Long,Long},
            {Long,Short,Short,Short},
            {Long,Short,Short,Long},
            {Long,Long,Short,Short},
            {Long,Long,Long,Short},
            {Long,Long,Long,Long}
        };
        readonly string[] MorseTextTable = { "ABBA", "KAWA", "WODA", "AHOJ", "ALBO", "ALFA", "BETA", "ARKA", "BANK", "BIEL", "DOBA", "FLET" };
        // private static System.Timers.Timer ClassTimer;
        public char[,] MorseWordTable =
        {
            {'A','A','A','A'},
            {'A','A','A','A'},
            {'A','A','A','A'},
            {'A','A','A','A'},
            {'A','A','A','A'},
            {'A','A','A','A'},
            {'A','A','A','A'},
            {'A','A','A','A'},
            {'A','A','A','A'},
            {'A','A','A','A'},
            {'A','A','A','A'},
            {'A','A','A','A'}
        };
        public int ChosenWord;
        public int TimeLeft = 60;
        async void SetTime()
        {
            await Navigation.ShowPopupAsync(new GamePopup("Morse"));
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
                        double dalej1 = 1;
                        Navigation.PushModalAsync(new deadPage(dalej1));
                        TimeCount.Text = "";
                        TimeBar.Text = TimeCount.Text;
                        return false;
                    }
                }
                return true;
            });
        }
        protected override bool OnBackButtonPressed()
        {
            GoToMenu();
            return true;
        }
        async void GoToMenu()
        {
            var MenuState = await Navigation.ShowPopupAsync(new GoToMenuPopup());
            if ((string)MenuState == "false")
            {
                TimeFlag = false;
                MediaElement soundtrack = (MediaElement)Application.Current.Resources["sound"];
                soundtrack.Stop();
                await Navigation.PushModalAsync(new MainPage(soundtrack.Volume));
            }
        }
        public FlashlightPage(double dalej1,double wynik1)
        {
            wynik = wynik1;
            InitializeComponent();

        }
        void RandomizeMorseText()
        {
            ChosenWord = RandomCharCount.Next(0, MorseTextTable.Length);
        }
        void setColumns()
        {
            for (int i = 0; i < 4; i++)
            {
                var Name = "Block" + i;
                var Obj = (Label)FindByName(Name);
                Obj.Text = MorseWordTable[ChosenWord, i].ToString();
            }
        }
        void RandomizeWordTable()
        {
            for (int i = 0; i < MorseTextTable.Length; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    var nextChar = RandomCharCount.Next(65, 90);
                    MorseWordTable[i, j] = Convert.ToChar(nextChar);
                }
            }
            char[] chosenWordChars = MorseTextTable[ChosenWord].ToCharArray();
            for (int i = 0; i < 4; i++)
            {
                int random = RandomCharCount.Next(1, MorseTextTable.Length - 1);
                MorseWordTable[random, i] = Convert.ToChar(chosenWordChars[i]);
            }
        }
        async private Task StartLight(int howLong)
        {
            await Task.Delay(2000);
            await Flashlight.TurnOnAsync();
            await Task.Delay(howLong);
            await Flashlight.TurnOffAsync();
        }
        void StartLightShow(object sender, EventArgs e)
        {
            var WordToShow = MorseTextTable[ChosenWord];
            Task.Run(async () =>
            {
                await StartLight(MorseTable[ChosenWord, 0]);
                await StartLight(MorseTable[ChosenWord, 1]);
                await StartLight(MorseTable[ChosenWord, 2]);
                await StartLight(MorseTable[ChosenWord, 3]);
            });
        }

        void setHeartStatus()
        {
            var text = "HealthBar" + HealthCount;
            var bar = (Label)FindByName(text);
            bar.IsVisible = false;
        }
        void LoverHeartCount()
        {
            HealthCount--;
            if(HealthCount <= 0)
            {
                TimeFlag = false;
                double dalej1 = 1;
                Navigation.PushModalAsync(new deadPage(dalej1));
            }
        }
        void ChangeBlockText(Label block, int blockNumber, string where)
        {
            if (where == "up")
            {
                if (BlockCounters[blockNumber] == 0)
                {
                    BlockCounters[blockNumber] = (MorseWordTable.Length / 4) - 1;
                }
                else BlockCounters[blockNumber]--;

            }
            else if (where == "down")
            {
                if (BlockCounters[blockNumber] == (MorseWordTable.Length / 4) - 1)
                {
                    BlockCounters[blockNumber] = 0;
                }
                else BlockCounters[blockNumber]++;
            }
            block.Text = MorseWordTable[BlockCounters[blockNumber], blockNumber].ToString();
        }
        void MoveUp(object sender, EventArgs e)
        {
            var Button = (Button)sender;
            var Name = "Block" + Button.ClassId.ToString();
            var whichBlock = (Label)FindByName(Name);
            int ClassId = Convert.ToInt32(Button.ClassId);
            ChangeBlockText(whichBlock, ClassId, "up");
        }
        void MoveDown(object sender, EventArgs e)
        {
            var Button = (Button)sender;
            var Name = "Block" + Button.ClassId.ToString();
            var whichBlock = (Label)FindByName(Name);
            int ClassId = Convert.ToInt32(Button.ClassId);
            ChangeBlockText(whichBlock, ClassId, "down");
        }
        async void CheckIfWin(object sender, EventArgs e)
        {
            var userGuess = "";
            var WinFlag = false;
            for (int i = 0; i < 4; i++)
            {
                var Name = "Block" + i;
                var Block = (Label)FindByName(Name);
                userGuess += Block.Text;
            }
            for (int i = 0; i < MorseTextTable.Length; i++)
            {
                if (MorseTextTable[i] == userGuess)
                {
                    WinFlag = true;
                }
            }
            if (WinFlag)
            {
               
                TimeFlag = false;
                wynik += TimeLeft;
                double dalej1 = 12;
                await Navigation.PushModalAsync(new Page5(dalej1,wynik));
            }
            else
            {
                setHeartStatus();
                LoverHeartCount();
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            RandomizeMorseText();
            RandomizeWordTable();
            setColumns();
            SetTime();
            DisplayAlert("Hasło", MorseTextTable[ChosenWord], "Dzieki");
        }
    }

}