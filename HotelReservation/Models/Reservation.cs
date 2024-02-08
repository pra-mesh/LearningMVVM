namespace HotelReservation.Models;
public class Reservation
{
    public RoomID RoomID { get; }
    public string Username { get; }
    public DateTime StartDate { get; }
    public DateTime EndDate { get; }
    public TimeSpan Length() => EndDate.Subtract(StartDate);

    public bool Conflicts(Reservation reservation)
    {
        reservation.RoomID.Equals(RoomID);
        if (reservation.RoomID != RoomID)
            return false;
        return reservation.StartDate < EndDate && reservation.EndDate > StartDate;
    }

    public Reservation(RoomID roomID, string username, DateTime startDate, DateTime endDate)
    {
        Username = username;
        RoomID = roomID;
        StartDate = startDate;
        EndDate = endDate;
    }
}
