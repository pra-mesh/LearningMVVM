using HotelReservation.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Models;
public class ReservationBook
{
    private readonly List<Reservation> _reservations;

    public ReservationBook()
    {
        _reservations = new  List<Reservation>();
    }

    public IEnumerable<Reservation> GetReservationsForUser(string username)
    {
        return _reservations.Where(r => r.Username == username);
    }
    public IEnumerable<Reservation> GetReservations()
    {
        return _reservations;
    }

    public void AddReservation(Reservation reservation)
    {
        foreach(Reservation existingReservation in _reservations)
        {
            if (existingReservation.Conflicts(reservation))
            {
                throw new ReservationConflictException(existingReservation,reservation);
            }
        }
        _reservations.Add(reservation);
    }
}
