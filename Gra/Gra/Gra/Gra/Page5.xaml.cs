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
        
        
        int[] table = new int[6];
        int licznik = 0;
        int main = 0;
        Random RandomCharCount = new Random();
       
        public Page5()
        {
            InitializeComponent();

            
            
            long ktory = RandomCharCount.Next(1, 4); 
           losowanie(ktory,1);
           
        }
        

        
        
        void losowanie(long ktory,long swit)
        {
            var timer = 3;
         switch (ktory)
            {
                 case 1:
                  butt1.BackgroundColor = Color.Pink;
                    Device.StartTimer(new TimeSpan(0, 0, 1), () =>
                    {
                        timer--;
                        if (timer == 0)
                        {
                            butt1.BackgroundColor = Color.Red;
                            if (swit == 1)
                            {
                                table[licznik] = 1;
                                licznik++;
                                main = 0;
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
                                main = 0;
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
                                main = 0;
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
                                main = 0;
                            }
                            return false;
                        }
                        return true;
                    });
                    break;
            }
        }

       async private void butt1_Clicked(object sender, EventArgs e)
        {

            if (table[main] == 4)
            {
                main++;
                if (table[main]==0)
                {
                    if (licznik == 5)
                    {
                        await DisplayAlert("wygrałem ?", "WYGRAŁES", "dziekuje rodzinie");

                    }
                    else
                    {
                        for (int i = 0; i < licznik; i++)
                        {
                            await Task.Delay(5000);
                            losowanie(table[i], 0);
                        }

                        long ktor = RandomCharCount.Next(1, 4);

                        await Task.Delay(5000);
                        losowanie(ktor, 1);
                    }
                }
            }
            else
            {
                await DisplayAlert("HAHAHAHHAHAHAH", "przegrales", "przepraszam rodzine");
            }
        }

        async private void butt2_Clicked(object sender, EventArgs e)
        {

            if (table[main] == 1)
            {
                main++;
                if (table[main] == 0)
                {

                    if (licznik == 5)
                    {
                        await DisplayAlert("wygrałem ?", "WYGRAŁES", "dziekuje rodzinie");

                    }
                    else
                    {
                        for (int i = 0; i < licznik; i++)
                        {
                            await Task.Delay(5000);
                            losowanie(table[i], 0);
                        }

                        long ktor = RandomCharCount.Next(1, 4);

                        await Task.Delay(5000);
                        losowanie(ktor, 1);
                    }
                }
            }
            else
            {
                await DisplayAlert("HAHAHAHHAHAHAH", "przegrales", "przepraszam rodzine");
            }
        }

        async private void butt3_Clicked(object sender, EventArgs e)
        {

            if (table[main] == 2)
            {
                main++;
                if (table[main] == 0)
                {

                    if (licznik == 5)
                    {
                        await DisplayAlert("wygrałem ?", "WYGRAŁES", "dziekuje rodzinie");

                    }
                    else
                    {
                        for (int i = 0; i < licznik; i++)
                        {
                            await Task.Delay(5000);
                            losowanie(table[i], 0);
                        }

                        long ktor = RandomCharCount.Next(1, 4);

                        await Task.Delay(5000);
                        losowanie(ktor, 1);
                    }
                }
            }
            else
            {
               await DisplayAlert("HAHAHAHHAHAHAH", "przegrales", "przepraszam rodzine");
            }
        }

        async private void butt4_Clicked(object sender, EventArgs e)
        {

            if (table[main] == 3)
            {
                main++;
                if (table[main] == 0)
                {

                    if (licznik == 5)
                    {
                        await DisplayAlert("wygrałem ?", "WYGRAŁES", "dziekuje rodzinie");

                    }
                    else
                    {
                        for (int i = 0; i < licznik; i++)
                        {
                            await Task.Delay(5000);
                            losowanie(table[i], 0);
                        }

                        long ktor = RandomCharCount.Next(1, 4);

                        await Task.Delay(5000);
                        losowanie(ktor, 1);
                    }
                }
            }
            else
            {
                await DisplayAlert("HAHAHAHHAHAHAH", "przegrales", "przepraszam rodzine");
            }
        }

        private void butt5_Clicked(object sender, EventArgs e)
        {

           
                esa.Text = table[0].ToString();
            esa1.Text = table[1].ToString();
            esa2.Text = table[2].ToString();
            esa3.Text = table[3].ToString();
            esa4.Text = table[4].ToString();


        }

    }
}