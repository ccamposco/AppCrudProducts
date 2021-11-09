using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCrudProducts.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
