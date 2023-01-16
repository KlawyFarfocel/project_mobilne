using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;
using Xamarin.CommunityToolkit.Extensions;

namespace Gra
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScrabblePage : ContentPage
    {
        public int HealthCount = 3;
        int[] BlockCounters = { 0, 0, 0, 0 };
        readonly string[] TextTable = { "ARAB", "ALGA", "ALFA", "BAZA", "BETA", "BUDA", "BUNT", "GLON", "GONG", "GRAM", "LAWA", "LIRA", "LUFA", "RATA", "ROPA", "RYSY" };
        public char[,] WordTable =
        {
            {'A','A','A','A'},
            {'A','A','A','A'},
            {'A','A','A','A'},
            {'A','A','A','A'},
        };
        public int ChosenWord;
        public double wynik1=12;
        public int TimeLeft = 60;
        public bool TimeFlag = true;
        Random RandomCharCount = new Random();

        async void SetTime()
        {
            await Navigation.ShowPopupAsync(new GamePopup("Scrabble"));
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
                        double dalej1 = soundtrack.Volume;
                        Navigation.PushModalAsync(new deadPage(dalej1));
                        TimeCount.Text = "";
                        TimeBar.Text = TimeCount.Text;
                        return false;
                    }
                }
                return true;
            });
        }
        void MorseText()
        {
            ChosenWord = RandomCharCount.Next(0, TextTable.Length);
        }
        void setColumns()
        {
            for (int i = 0; i < 4; i++)
            {
                var Name = "Block" + i;
                var Obj = (Label)FindByName(Name);
                var Los = RandomCharCount.Next(0, (WordTable.Length / 4) - 1);
                Obj.Text = WordTable[Los, i].ToString();
            }
        }
        void RandomizeText()
        {
            ChosenWord = RandomCharCount.Next(0,TextTable.Length);
        }
        void RandomizeWordTable()
        {
            for (int i = 0; i < (WordTable.Length/4); i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    var nextChar = RandomCharCount.Next(65, 90);
                    WordTable[i, j] = Convert.ToChar(nextChar);
                }
            }
            char[] chosenWordChars = TextTable[ChosenWord].ToCharArray();
            for (int i = 0; i < 4; i++)
            {
                int random = RandomCharCount.Next(1, (TextTable.Length/4) - 1);
                WordTable[random, i] = Convert.ToChar(chosenWordChars[i]);
            }
        }
        void ChangeBlockText(Label block, int blockNumber, string where)
        {
            if (where == "up")
            {
                if (BlockCounters[blockNumber] == 0)
                {
                    BlockCounters[blockNumber] = (WordTable.Length / 4) - 1;
                }
                else BlockCounters[blockNumber]--;

            }
            else if (where == "down")
            {
                if (BlockCounters[blockNumber] == (WordTable.Length / 4) - 1)
                {
                    BlockCounters[blockNumber] = 0;
                }
                else BlockCounters[blockNumber]++;
            }
            block.Text = WordTable[BlockCounters[blockNumber], blockNumber].ToString();
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
            for (int i = 0; i < TextTable.Length; i++)
            {
                if (TextTable[i] == userGuess)
                {
                    WinFlag = true;
                }
            }
            if (WinFlag)
            {

                wynik1 += TimeLeft;
                double dalej1 = 13;
                 await Navigation.PushModalAsync(new FlashlightPage( dalej1, wynik1));
                TimeFlag= false;
            }
            else
            {
                setHeartStatus();
                LoverHeartCount();
            }
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
            if(HealthCount <=0 )
            {
                TimeFlag = false;
                double dalej1 = soundtrack.Volume;
                Navigation.PushModalAsync(new deadPage(dalej1));
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            RandomizeText();
            RandomizeWordTable();
            setColumns();
            SetTime();
            DisplayAlert("Hasło", TextTable[ChosenWord], "Dzieki");
        }
        public ScrabblePage(double dalej,double wynik)
        {
           
           
            //  soundtrack.Volume = dalej;
            //  soundtrack.Play();
            wynik1 = wynik;
            InitializeComponent();
        }
    }
}