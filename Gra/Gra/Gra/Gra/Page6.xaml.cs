using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gra
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page6 : ContentPage
    {
        public int TimeLeft = 60;
        public int Timebutt = 10;
        public string timeL = "";
        public int jeden = 0;
        public string timeR = "";
        public double wynik;
        public int HealthCount = 3;
        public bool TimeFlag=true;
        Random RandomCharCount = new Random();
        async void SetTime()
        {
            await DisplayAlert("Rozpocznij zagadkę", "Wciśnij OK, aby rozpocząć", "OK");
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
        bool prawda = false;
            private void click_Clicked(object sender, EventArgs e)
                 {

           
            if (prawda == true)
            {
                text.Text = timeL;
                
                if (TimeLeft+jeden==Int32.Parse(text.Text))
                {
                    DisplayAlert("kozacko2", "):", "dales rade");
                    Timebutt = 10;
                    wynik += TimeLeft;
                    double dalej1 = 14;
                    TimeFlag= false;
                    Navigation.PushModalAsync(new Page7(dalej1, wynik));

                }
                else
                {
                    setHeartStatus();
                    LoverHeartCount();
                    Timebutt = 10;
                    prawda = false; 

                }
            }
            

        }
        
            private void click_Clicked_1(object sender, EventArgs e)
                    {

            Label TimeCount = (Label)FindByName("TimerCount");
            timeL = TimeCount.Text;
            text.Text = timeL;
            string timestring = TimeLeft.ToString();
           
            if (timestring.EndsWith(timeR))
                                {
                                         prawda = true;  
                                }else
            {
                setHeartStatus();
                LoverHeartCount();
                prawda = false;
            }
                    }
            private void click_Pressed(object sender, EventArgs e)
                 {

            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                Timebutt--;
                
                    
                
                return true;
            });

        }
        void losowanie(long ktory)
        {
             switch (ktory)
                        {

                            case 1:
                                click.Source = "pink_button";
                                jeden = 5;
                                timeR = "1";
                                break;
                            case 2:
                                click.Source = "blue_button";
                                jeden = 3;
                                timeR = "3";
                                break;
                    
                            case 3:
                                click.Source = "yellow_button";
                                jeden = 4;
                                timeR = "2";
                                break;

                            case 4:
                                click.Source = "green_button";
                                jeden = 2;
                                timeR = "4";
                                break;


                        }
        }
        public Page6(double dalej1,double wynik1)
        {
            SetTime();
            wynik = wynik1;
            double f = dalej1;
            InitializeComponent();
            long ktory = RandomCharCount.Next(1, 4);
            losowanie(ktory);
        }

        
    }
}