using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Threading.Tasks;
using MobileApp.Models;

namespace MobileApp.Data
{
    public class ShoeProductDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public ShoeProductDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ShoeProduct>().Wait();
        }
        public Task<List<ShoeProduct>> GetShoeShopsAsync()
        {
            return _database.Table<ShoeProduct>().ToListAsync();
        }
        public Task<ShoeProduct> GetShoeShopsAsync(int id)
        {
            return _database.Table<ShoeProduct>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveShopListAsync(ShoeProduct slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteShopListAsync(ShoeProduct slist)
        {
            return _database.DeleteAsync(slist);
        }

    }
}
