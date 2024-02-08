﻿namespace HotelReservation.Models;
public class RoomID
{


    private int FloorNumber { get; }
    public int RoomNumber { get; }
    public RoomID(int floorNumber, int roomNumber)
    {
        FloorNumber = floorNumber;
        RoomNumber = roomNumber;
    }
    public override string ToString()
    {
        return $"{FloorNumber}{RoomNumber}";
    }
    public override bool Equals(object? obj)
    {
        bool a = obj is RoomID roomID && FloorNumber == roomID.FloorNumber &&
            RoomNumber == roomID.RoomNumber;
        return a;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(FloorNumber, RoomNumber);
    }

    public static bool operator ==(RoomID roomID1, RoomID roomID2)
    {
        if (roomID1 is null && roomID2 is null)
        {
            return true;
        }
        return roomID1 is not null && roomID1.Equals(roomID2);
    }
    public static bool operator !=(RoomID roomID1, RoomID roomID2)
    {

        return !(roomID1 == roomID2);
    }
}
