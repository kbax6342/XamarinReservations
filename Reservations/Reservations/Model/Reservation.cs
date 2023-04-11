using System;
using System.Collections.Generic;
using System.Text;

using SQLite;


namespace Reservations.Model
{
    public enum ApprovalStatus { None, Approved, Rejected}
    public class Reservation : IObject
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Date { get; set; }
        public string StartTime { get; set; }
        public int Duration { get; set; }
        public bool Virtual { get; set; }
        public string Location { get; set; }
        public ApprovalStatus IsApproved { get; set; }
        public int Reason { get; set; }

        public Reservation(string date, string time, int dur, bool virt, string loc, ApprovalStatus approved, int reason)
        {
            Date = date;
            StartTime = time;
            Duration = dur;
            Virtual = virt;
            Location = loc;
            IsApproved = approved;
            /*Id = DateTime.Now.Ticks;*/
            Reason = reason;

        }

        // res.equals(res2)
        public override bool Equals(object obj)
        {
            //checking to see if its an object
            if (obj == null)
            {
                return false;
            }
            if (obj == this)
            {
                return true;
            }
            Reservation r = obj as Reservation;
            //checking to see if reservation object
            if (r == null)
            {
                return false;
            }

            return r.Id == Id;
        }

        public override string ToString()
        {
            return $"{Date} {StartTime} {Location}";
        }


    }
}
