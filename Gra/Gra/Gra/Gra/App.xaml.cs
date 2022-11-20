using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
namespace Gra
{
    public partial class App : Application
    {
        private static databese Database;

        public static databese database
        {
            get
            {
                if (Database == null)
                {
                    Database = new databese(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "settings.db3"));
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
