using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using SQLite;


using Xamarin.Forms;

namespace Reservations.Model
{
    public class ReservationDatabaseGeneric
    {
        static object locker = new object();

        SQLiteConnection database;


        public ReservationDatabaseGeneric()
        {
            database = DependencyService.Get<IDatabase>().DBConnect();
            database.CreateTable<Reservation>();
        }

        public IEnumerable<T> GetObjects<T>() where T: IObject, new()
        {
            lock (locker)
            {
                return(from i in database.Table<T>() select i).ToList();
            }
        }

        public IEnumerable<T> GetAllReservationsObjects<T>() where T : IObject, new()
        {
            lock (locker)
            {
                return database.Query<T>("SELECT * FROM Reservation ");
            }
        }

        public IEnumerable<T> GetNonApprovedObjects<T>() where T : IObject, new()
        {
            lock (locker)
            {
                return database.Query<T>("SELECT * FROM Reservation WHERE isApproved = 'None' ");
            }
        }

        public IEnumerable<T> GetAcceptedObjects<T>() where T : IObject, new()
        {
            lock (locker)
            {
                return database.Query<T>("SELECT * FROM Reservation WHERE isApproved = 'Accepted' ");
            }
        }

        public IEnumerable<T> GetRejectedObjects<T>() where T : IObject, new()
        {
            lock (locker)
            {
                return database.Query<T>("SELECT * FROM Reservation WHERE isApproved = 'Rejected' ");
            }

        }


        public T GetObject<T>(int id) where T : IObject, new()
        {
            lock (locker)
            {
                return database.Table<T>().FirstOrDefault(i => i.Id == id);
            }

        }

    }
}
