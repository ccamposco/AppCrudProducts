using AppCrudProducts.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCrudProducts.Data
{
    public class DBFirebase
    {
        public FirebaseClient client;

        public DBFirebase()
        {
            client = new FirebaseClient(
                "https://myproducts-72a5f-default-rtdb.firebaseio.com/");
        }

        public async Task AddProduct(string name, double price)
        {
            await client
              .Child("Products")
              .PostAsync(new Products() { Name = name, Price = price });
        }

    }
}
