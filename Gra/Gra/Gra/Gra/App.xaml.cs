using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using static Gra.Page7;

namespace Gra
{
    public partial class App : Application
    {

        private static Database database;
        public static Database Database
        {
            get
            {

                if (database == null)
                {

                    database = new Database(Path.Combine(Environment.GetFolderPath(

                    Environment.SpecialFolder.LocalApplicationData), "people.db3"));
                }

                return database;

            }

        }

        public App()
        {
            InitializeComponent();
            double dalej=0;
            MainPage = new NavigationPage(new MainPage(dalej));
           
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        
    }
}
