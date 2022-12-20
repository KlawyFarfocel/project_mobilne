using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
// using static Android.Content.ClipData;

namespace Gra
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page5 : ContentPage
    {
        public Page5()
        {
            InitializeComponent();

            Random RandomCharCount = new Random();
            long ktory=RandomCharCount.Next(0,4);
            
            
           losowanie(ktory,1);
            
        }
        

        int[] table = new int[5];
        int licznik = 0;
        
        void losowanie(long ktory,long swit)
        {
            var timer = 2;
            switch (ktory)
            {
                case 1:
                   butt1.BackgroundColor = Color.LightPink;
                    Device.StartTimer(new TimeSpan(0, 0, 1), () =>
                    {
                        timer--;
                        if (timer == 0)
                        {
                            butt1.BackgroundColor = Color.Pink;
                            if (swit == 1)
                            {
                                table[licznik] = 1;
                                licznik++;
                            }
                            
                            return false;

                        }
                        return true;
                    });

                    break;
                case 2:
                    butt2.BackgroundColor = Color.LightYellow;
                    Device.StartTimer(new TimeSpan(0, 0, 1), () =>
                    {
                        timer--;
                        if (timer == 0)
                        {
                            butt2.BackgroundColor = Color.Yellow;

                            if (swit == 1)
                            {
                                table[licznik] = 2;
                                licznik++;
                            }
                            return false;
                        }
                        return true;
                    });
                    break;


                case 3:
                    butt3.BackgroundColor = Color.LightBlue;
                    Device.StartTimer(new TimeSpan(0, 0, 1), () =>
                    {
                        timer--;
                        if (timer == 0)
                        {
                            butt3.BackgroundColor = Color.Blue;
                            if (swit == 1)
                            {
                                table[licznik] = 3;
                                licznik++;
                            }
                            return false;
                        }
                        return true;
                    });
                    break;

                case 4:
                    butt4.BackgroundColor = Color.LightGreen;
                    Device.StartTimer(new TimeSpan(0, 0, 1), () =>
                    {
                        timer--;
                        if (timer == 0)
                        {
                            butt4.BackgroundColor = Color.Green;
                            if (swit == 1)
                            {
                                table[licznik] = 4;
                                licznik++;
                            }
                            return false;
                        }
                        return true;
                    });
                    break;
            }
        }
    }
}