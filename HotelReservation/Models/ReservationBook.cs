using HotelReservation.Exceptions;
using HotelReservation.Services.ReservationConflictValidators;
using HotelReservation.Services.ReservationCreators;
using HotelReservation.Services.ReservationProviders;

namespace HotelReservation.Models;
public class ReservationBook
{
  private readonly IReservationProvider _reservationProvider;
  private readonly IReservationCreator _reservationCreator;
  private readonly IReservationConflictValidators _reservationConflictValidators;

  public ReservationBook(IReservationProvider reservationProvider, IReservationCreator reservationCreator, IReservationConflictValidators reservationConflictValidators)
  {
    _reservationProvider = reservationProvider;
    _reservationCreator = reservationCreator;
    _reservationConflictValidators = reservationConflictValidators;
  }

  public async Task<IEnumerable<Reservation>> GetReservationsForUser(string username)
  {
    //TODO: for SOLID and less load Create a new Service
    IEnumerable<Reservation> reservations = await GetReservations();
    return reservations.Where(x => x.Username == username);
  }
  public async Task<IEnumerable<Reservation>> GetReservations()
  {
    return await _reservationProvider.GetAllReservation();
  }

  public async Task AddReservation(Reservation reservation)
  {
    Reservation conflictingReservation = await _reservationConflictValidators.DoesReservationConflicts(reservation);

    if (conflictingReservation != null)
    {
      throw new ReservationConflictException(conflictingReservation, reservation);
    }
    await _reservationCreator.CreateReservation(reservation);
  }
}
