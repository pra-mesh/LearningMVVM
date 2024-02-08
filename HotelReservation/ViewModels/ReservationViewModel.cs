using HotelReservation.Models;
using HotelReservation.ViaewModels;

namespace HotelReservation.ViewModels;

public class ReservationViewModel : ViewModelBase
{
    private readonly Reservation _reservation;

    public string RoomID => _reservation.RoomID?.ToString();
    public string Username => _reservation.Username.ToString();
    public string StartTime => _reservation.StartDate.Date.ToString("d");
    public string EndTime => _reservation.EndDate.Date.ToString("d");
    public ReservationViewModel(Reservation reservation)
    {

        _reservation = reservation;
    }
}
