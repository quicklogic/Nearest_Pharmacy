using Nearest_Pharmacy.Droid;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Nearest_Pharmacy.Models
{
    public class ProductRepository
    {
        SQLiteConnection database;
        public ProductRepository(string filename)
        {
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Product>();
        }
        public IEnumerable<Product> GetProducts()
        {
            return (from i in database.Table<Product>() select i).ToList();
        }
        public IEnumerable<Basket> GetBasket()
        {
            return (from i in database.Table<Basket>() select i).ToList();
        }
        public Product GetItem(int id)
        {
            return database.Get<Product>(id);
        }
        public void AddProduct(Product item)
        {
            database.Insert(item);
        }

        public void AddBasket(Basket item)
        {
            database.Insert(item);
        }
        public void DeleteAll()
        {
            database.DeleteAll<Product>();
        }
        public int SaveItem(Product item)
        {
            if (item.ID != 0)
            {
                database.Update(item);
                return item.ID;
            }
            else
            {
                return database.Insert(item);
            }
        }

        public int Count()
        {
            return database.Table<Product>().Count();
        }
    }
}