﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gra
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScrabblePage : ContentPage
    {
        int[] BlockCounters = { 0, 0, 0, 0 };
        readonly string[] TextTable = { "ARAB", "ALGA", "ALFA", "BAZA", "BETA", "BUDA", "BUNT", "GLON", "GONG", "GRAM", "LAWA", "LIRA", "LUFA", "RATA", "ROPA", "RYSY" };
        public char[,] WordTable =
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
            {'A','A','A','A'},
            {'A','A','A','A'},
            {'A','A','A','A'},
            {'A','A','A','A'},
            {'A','A','A','A'},
        };
        public int ChosenWord;
        Random RandomCharCount = new Random();

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
                Obj.Text = WordTable[ChosenWord, i].ToString();
            }
        }
        void RandomizeText()
        {
            ChosenWord = RandomCharCount.Next(0,TextTable.Length);
        }
        void RandomizeWordTable()
        {
            for (int i = 0; i < TextTable.Length; i++)
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
                int random = RandomCharCount.Next(1, TextTable.Length - 1);
                DisplayAlert("Ok", "Ustawiam: " + chosenWordChars[i] + " w miejscu: " + random + "," + i, "Ok");
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
        void CheckIfWin(object sender, EventArgs e)
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
                DisplayAlert("Wygrałeś", "Wygrałeś", "Wygrałem?");
            }
            else DisplayAlert("Nie", "Nie", "Nie");
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            RandomizeText();
            RandomizeWordTable();
            setColumns();
        }
        public ScrabblePage()
        {
            InitializeComponent();
        }
    }
}