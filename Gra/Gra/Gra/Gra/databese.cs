using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace Gra
{
    public class databese
    {
        private readonly SQLiteAsyncConnection _database;

        public databese(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Class1>();
        }

        public Task <List<Class1>>GetPeopleAsync()
        {
            return _database.Table<Class1>().ToListAsync();
        }
        public Task<int> SavePersonAsync(Class1 class1)
        {
            return _database.InsertAsync(class1);
        }
    }
}
