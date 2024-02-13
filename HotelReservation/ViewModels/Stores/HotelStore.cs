using HotelReservation.Models;

namespace HotelReservation.ViewModels.Stores;

public class HotelStore
{
  private readonly List<Reservation> _reservations;
  private readonly Hotel _hotel;
  private Lazy<Task> _initializeLazy;

  public event Action<Reservation> ReservationMade;
  public IEnumerable<Reservation> Reservations => _reservations;
  public HotelStore(Hotel hotel)
  {

    _hotel = hotel;
    _initializeLazy = new Lazy<Task>(Initialize);
    _reservations = new List<Reservation>();
  }

  public async Task Load()
  {
    try
    {
      await _initializeLazy.Value;
    }
    catch (Exception)
    {
      _initializeLazy = new Lazy<Task>(Initialize);
      throw;
    }

  }
  public async Task MakeReservation(Reservation reservation)
  {
    await _hotel.MakeReservation(reservation);
    _reservations.Add(reservation);
    OnReservationMade(reservation);
  }

  private void OnReservationMade(Reservation reservation)
  {
    ReservationMade?.Invoke(reservation);
  }

  private async Task Initialize()
  {
    IEnumerable<Reservation> reservations = await _hotel.GetReservations();
    _reservations.Clear();
    _reservations.AddRange(reservations);
    throw new Exception();
  }
}
