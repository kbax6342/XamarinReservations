using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reservations.Model
{
    public interface IDatabase
    {
        SQLiteConnection DBConnect();
    }
}
