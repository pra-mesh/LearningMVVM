using HotelReservation.Models;

namespace HotelReservation.Services.ReservationConflictValidators;

public interface IReservationConflictValidators
{
  Task<Reservation> DoesReservationConflicts(Reservation reservation);
}
