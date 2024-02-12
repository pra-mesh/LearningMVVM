namespace HotelReservation.Models;
public class Hotel
{
  private readonly ReservationBook _reservationBook;

  public string Name { get; }

  public Hotel(string name, ReservationBook reservationBook)
  {
    Name = name;
    _reservationBook = reservationBook;
  }

  public async Task<IEnumerable<Reservation>> GetReservationsForUser(string username)
  {
    return await _reservationBook.GetReservationsForUser(username);
  }

  public async Task<IEnumerable<Reservation>> GetReservations()
  {
    return await _reservationBook.GetReservations();
  }

  public async Task MakeReservation(Reservation reservation)
  {
    await _reservationBook.AddReservation(reservation);
  }
}
