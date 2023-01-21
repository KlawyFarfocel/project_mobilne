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
    public partial class Page3 : ContentPage
    {
        readonly double dalej1 = 13;
        public Page3(double dalej2)
        {
            InitializeComponent();
        }
        void GoBack(object sender, EventArgs e)
        {

            Navigation.PushModalAsync(new Page1(dalej1));
        }
        protected override bool OnBackButtonPressed()
        {
            Navigation.PushModalAsync(new Page1(dalej1));
            return true;
        }
    }
}