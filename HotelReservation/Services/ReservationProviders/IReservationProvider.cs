using HotelReservation.Models;

namespace HotelReservation.Services.ReservationProviders;

public interface IReservationProvider
{
  Task<IEnumerable<Reservation>> GetAllReservation();
}
