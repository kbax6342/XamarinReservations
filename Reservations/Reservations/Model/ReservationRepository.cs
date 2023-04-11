using System;
using System.Collections.Generic;
using System.Text;

namespace Reservations.Model
{
    public class ReservationRepository
    {
        ReservationDatabaseGeneric ressDatabase = null;

        public ReservationRepository()
        {
            ressDatabase = new ReservationDatabaseGeneric();
        }
            public Reservation GetReservation(int Id)
            {
                return ressDatabase.GetsObjects<Reservation>(Id);
            }


            public IEnumerable<Reservation> GetFirstReservations()
            {
                return ressDatabase.GetAllReservationsObjects<Reservation>();
            }

            public IEnumerable<Reservation> GetReservations()
            {
                return ressDatabase.GetObject<Reservation>();
            }

            public int SaveReservation(Reservation ress)
            {
                return ressDatabase.SaveObject<Reservation>(ress);
            }

            public int DeleteReservation(int Id) { 
                return ressDatabase.DeleteObject<Reservation>(Id);
            }

        public void DeleteAllReservations()
        {
            ressDatabase.DeleteObject<Reservation>();
        }



        }
    }

}
