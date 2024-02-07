using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Models;
public class Reservation
{
    public RoomID RoomID { get; }
    public string Username { get; }
    public DateTime StartTime { get; }
    public DateTime EndTime { get; }
    public TimeSpan Length() => EndTime.Subtract(StartTime);

    public bool Conflicts(Reservation reservation)
    {
        reservation.RoomID.Equals(RoomID);
       if(reservation.RoomID !=RoomID)
            return false;
       return reservation.StartTime <EndTime && reservation.EndTime > StartTime;
    }

    public Reservation(RoomID roomID, string username, DateTime startTime, DateTime endTime)
    {
        Username = username;
        RoomID = roomID;
        StartTime = startTime;
        EndTime = endTime;
    }
}
