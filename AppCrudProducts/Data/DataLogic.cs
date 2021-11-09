using AppCrudProducts.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace AppCrudProducts.Data
{
    public class DataLogic
    {
        private SQLiteConnection conn;
        private Products product;

        public DataLogic()
        {
            conn = DependencyService.Get<ISQLite>().GetConnection();
            conn.CreateTable<Products>();
        }

        public bool SavetoDB(string name, double price, int quantity)
        {
            product = new Products
            {
                Name = name,
                Price = price,
                Quantity = quantity
            };

            try
            {
                conn.Insert(product);
                conn.Close();
                return true;
            }
            catch (SQLiteException) { }
            catch (Exception) { }
            return false;
        }

        public IEnumerable<Products> ShowData()
        {
            var lstStudent = from product in conn.Table<Products>() select product;
            return lstStudent;
        }

    }
}
