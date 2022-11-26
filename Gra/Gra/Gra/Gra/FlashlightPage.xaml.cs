using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Gra
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FlashlightPage : ContentPage
	{
        private const int Short = 2000;
        private const int Long = 6000;
        int[] BlockCounters = { 0, 0, 0, 0 };
        Random RandomCharCount = new Random();
        public bool a=false;
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
        readonly string[] MorseTextTable = {"ABBA","KAWA","WODA","AHOJ","ALBO","ALFA","BETA","ARKA","BANK","BIEL","DOBA","FLET"};
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
        public FlashlightPage()
		{
			InitializeComponent();

        }
        void RandomizeMorseText()
        {
            ChosenWord=RandomCharCount.Next(0, MorseTextTable.Length);
        }
        void setColumns()
        {
            for(int i = 0; i < 4; i++)
            {
                var Name = "Block" + i;
                var Obj = (Label)FindByName(Name);
                Obj.Text = MorseWordTable[ChosenWord,i].ToString();
            }
        }
        void RandomizeWordTable()
        {
            for(int i=0;i<MorseTextTable.Length;i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    var nextChar=RandomCharCount.Next(65, 90);
                    MorseWordTable[i,j]=Convert.ToChar(nextChar);
                }
            }
            char[] chosenWordChars = MorseTextTable[ChosenWord].ToCharArray();
            for(int i = 0; i < 4; i++)
            {
                int random = RandomCharCount.Next(1, MorseTextTable.Length-1);
                DisplayAlert("Ok", "Ustawiam: "+ chosenWordChars[i]+" w miejscu: "+random+","+i, "Ok");
                MorseWordTable[random, i] =Convert.ToChar(chosenWordChars[i]);
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
        void ChangeBlockText(Label block,int blockNumber, string where)
        {
            if(where == "up")
            {
                if (BlockCounters[blockNumber] == 0)
                {
                    BlockCounters[blockNumber] = (MorseWordTable.Length/4)-1;
                }
                else BlockCounters[blockNumber]--;

            }
            else if(where == "down")
            {
                if (BlockCounters[blockNumber] == (MorseWordTable.Length / 4) - 1)
                {
                    BlockCounters[blockNumber] = 0;
                }
                else BlockCounters[blockNumber]++;
            }
         //   DisplayAlert("Ok", "Numer w kolumnie: " + BlockCounters[blockNumber]+" w rzedzie"+ blockNumber, "Ok");
            block.Text = MorseWordTable[BlockCounters[blockNumber],blockNumber].ToString();

        }
        void MoveUp(object sender, EventArgs e)
        {
            var Button = (Button)sender;
            var Name = "Block" + Button.ClassId.ToString();
            var whichBlock = (Label)FindByName(Name);
            int ClassId= Convert.ToInt32(Button.ClassId);
           ChangeBlockText(whichBlock,ClassId, "up");
        }
        void MoveDown(object sender, EventArgs e)
        {
            var Button = (Button)sender;
            var Name = "Block" + Button.ClassId.ToString();
            var whichBlock = (Label)FindByName(Name);
            int ClassId = Convert.ToInt32(Button.ClassId);
            ChangeBlockText(whichBlock, ClassId, "down");
        }
        void CheckIfWin(object sender, EventArgs e)
        {
            var userGuess = "";
            var WinFlag = false;
            for(int i=0;i<4;i++)
            {
                var Name = "Block" + i;
                var Block = (Label)FindByName(Name);
                userGuess += Block.Text;
            }
            for(int i = 0; i < MorseTextTable.Length; i++)
            {
                if (MorseTextTable[i]==userGuess)
                {
                    WinFlag = true;
                }
            }
            if (WinFlag)
            {
                DisplayAlert("Wygrałeś", "Wygrałeś", "Wygrałem?");
            }
            else DisplayAlert("Nie", "Nie", "Nie");
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            RandomizeMorseText();
            RandomizeWordTable();
            setColumns();
            DisplayAlert("Ok", MorseTextTable[ChosenWord], "ok");
        }
    }

}