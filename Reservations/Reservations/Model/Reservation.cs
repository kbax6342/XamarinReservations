using System;
using System.Collections.Generic;
using System.Text;

using SQLite;


namespace Reservations.Model
{
    public enum ApprovalStatus { None, Approved, Rejected}
    public class Reservation
    {

        public long Id;
        public string Date { get; set; }
        public string StartTime;
        public int Duration;
        public bool Virtual;
        public string Location;
        public ApprovalStatus IsApproved;
        public int Reason;

        public Reservation(string date, string time, int dur, bool virt, string loc, ApprovalStatus approved, int reason)
        {
            Date = date;
            StartTime = time;
            Duration = dur;
            Virtual = virt;
            Location = loc;
            IsApproved = approved;
            Id = DateTime.Now.Ticks;
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
