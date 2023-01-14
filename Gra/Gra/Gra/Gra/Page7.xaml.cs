using SQLite;

using System;

using System.Collections.Generic;

using System.IO;

using System.Linq;

using System.Text;

using System.Threading.Tasks; // odpowiedzialny za tworzenie zadań
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

using Xamarin.Forms.Xaml;

namespace Gra
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page7 : ContentPage
    {
        public double score;
        public class Person

        {

            [PrimaryKey, AutoIncrement]

            public int Id { get; set; }

            public string Name { get; set; }

            public double wynik { get; set; }

        }

        public class Database

        {

            private readonly SQLiteAsyncConnection _database;

            public Database(string dbPath)

            {

                _database = new SQLiteAsyncConnection(dbPath);

                _database.CreateTableAsync<Person>();

            }
            public Task<List<Person>> GetPeopleAsync()

            {

                return _database.Table<Person>().OrderByDescending(x => x.wynik).ToListAsync();

            }

            public Task<int> SavePersonAsync(Person person)

            {

                return _database.InsertAsync(person);

            }
        }

        protected override async void OnAppearing()

        {

            base.OnAppearing(); // wymusza odświeżenie kolekcji
            var userName = await Navigation.ShowPopupAsync(new NamePopup());
            InsertIntoDatabase(userName.ToString(), score);
            collectionView.ItemsSource = await App.Database.GetPeopleAsync();

        }
        void InsertIntoDatabase(string userName,double wynik)
        {
            App.Database.SavePersonAsync(new Person
            {
                Name = userName,
                wynik = wynik
            }) ;
        }
        public readonly SQLiteAsyncConnection _database; // obiekt odpowiedzialny za połączenie z bazą danych
        public Page7(double dalej1,double wynik)
        {
            InitializeComponent();
            score = wynik;
        }
    }
}