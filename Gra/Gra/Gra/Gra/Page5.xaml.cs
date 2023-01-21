using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;
// using static Android.Content.ClipData;

namespace Gra
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page5 : ContentPage
    {

        private bool TimeFlag = true;
        int checkCounter = 1;
        int[] table = new int[6];
        int licznik = 0;
        int main = 0;
        public int TimeLeft = 180;
        public double wynik1;
        Random RandomCharCount = new Random();
        public int HealthCount=3;
        void setHeartStatus()
        {

            var text = "HealthBar" + HealthCount;
            var bar = (Label)FindByName(text);
            bar.IsVisible = false;
        }

        void LoverHeartCount()
        {
            HealthCount--;
            if (HealthCount <= 0)
            {
                TimeFlag = false;
                double dalej1 = 1;
                Navigation.PushModalAsync(new deadPage(dalej1));
            }
        }
        async void SetTime()
        {
            Label TimeCount = (Label)FindByName("TimerCount");
            Label TimeBar = (Label)FindByName("Timer");
            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
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
                        return TimeFlag;
                    }
                }
                return TimeFlag;
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
                MediaElement soundtrack = (MediaElement)Xamarin.Forms.Application.Current.Resources["sound"];
                soundtrack.Stop();
                await Navigation.PushModalAsync(new MainPage(soundtrack.Volume));
            }
        }
        async void HandleGameStart()
        {
            await Navigation.ShowPopupAsync(new GamePopup("Kolorki"));
            SetTime();
            long ktory = RandomCharCount.Next(1, 4);
            await Task.Delay(250);
            losowanie(ktory, 1);
        }
        public Page5(double dalej1,double wynik)
        {
            wynik1 = wynik;
            InitializeComponent();          
            double f = dalej1;
            HandleGameStart();
        }
        /*        void resetCheckMarks()
                {
                    string name;
                    Label checkBox;
                    for(int i = 1; i <= 4; i++)
                    {
                        name = "check" + i;
                        checkBox = (Label)FindByName(name);
                        checkBox.Text ="";
                    }
                }*/



        void losowanie(long ktory, long swit)
        {
            var timer = 3;
            switch (ktory)
            {
                case 1:
                    butt1.BackgroundColor = Color.Pink;
                    Device.StartTimer(new TimeSpan(0, 0, 1), () =>
                    {
                        if (TimeFlag == false)
                        {
                            return false;
                        }
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
                        if (TimeFlag == false)
                        {
                            return false;
                        }
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
                        if (TimeFlag == false)
                        {
                            return false;
                        }
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
                        if (TimeFlag == false)
                        {
                            return false;
                        }
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
                if (table[main] == 0)
                {
                    string name = "check" + checkCounter;
                    checkCounter++;
                    var checkMarkBlock = (Label)FindByName(name);
                    checkMarkBlock.Text = "\u2714";
                    if (licznik == 5)
                    {

             //           await DisplayAlert("wygrałem ?", "WYGRAŁES", "dziekuje rodzinie");
                        TimeFlag = false;
                        wynik1 += TimeLeft;
                       double dalej1 = 14;
                        await Navigation.PushModalAsync(new Page6(dalej1,wynik1));
                    }
                    else
                    {
                        /*resetCheckMarks();*/
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
                setHeartStatus();
                LoverHeartCount();
            }
        }

        async private void butt2_Clicked(object sender, EventArgs e)
        {
            if (table[main] == 1)
            {
                main++;
                if (table[main] == 0)
                {
                    string name = "check" + checkCounter;
                    checkCounter++;
                    var checkMarkBlock = (Label)FindByName(name);
                    checkMarkBlock.Text = "\u2714";
                    if (licznik == 5)
                    {
                        wynik1 += TimeLeft;
                        double dalej1 = 14;
                        TimeFlag = false;
                        await Navigation.PushModalAsync(new Page6(dalej1, wynik1));
                        // await DisplayAlert("wygrałem ?", "WYGRAŁES", "dziekuje rodzinie");
                    }
                    else
                    {
                        /* resetCheckMarks();*/
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
                setHeartStatus();
                LoverHeartCount();
                for (int i = 0; i < licznik; i++)
                {
                    await Task.Delay(5000);
                    losowanie(table[i], 0);
                }
            }
        }

        async private void butt3_Clicked(object sender, EventArgs e)
        {
            if (table[main] == 2)
            {
                main++;
                if (table[main] == 0)
                {
                    string name = "check" + checkCounter;
                    checkCounter++;
                    var checkMarkBlock = (Label)FindByName(name);
                    checkMarkBlock.Text = "\u2714";
                    if (licznik == 5)
                    {
                        wynik1 += TimeLeft;
                        double dalej1 = 14;
                        TimeFlag = false;
                        await Navigation.PushModalAsync(new Page6(dalej1, wynik1));
                        //  await DisplayAlert("wygrałem ?", "WYGRAŁES", "dziekuje rodzinie");
                    }
                    else
                    {
                        /*resetCheckMarks();*/
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
                setHeartStatus();
                LoverHeartCount();
            }
        }

        async private void butt4_Clicked(object sender, EventArgs e)
        {
            if (table[main] == 3)
            {
                main++;
                if (table[main] == 0)
                {
                    string name = "check" + checkCounter;
                    checkCounter++;
                    var checkMarkBlock = (Label)FindByName(name);
                    checkMarkBlock.Text = "\u2714";
                    if (licznik == 5)
                    {
                        wynik1 += TimeLeft;
                        double dalej1 = 14;
                        TimeFlag = false;
                        await Navigation.PushModalAsync(new Page6(dalej1, wynik1));
                        // await DisplayAlert("wygrałem ?", "WYGRAŁES", "dziekuje rodzinie");
                    }
                    else
                    {
                        /* resetCheckMarks();*/
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
                setHeartStatus();
                LoverHeartCount();
            }
        }
    }
}