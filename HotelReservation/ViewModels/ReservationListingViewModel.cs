using HotelReservation.Models;
using HotelReservation.ViaewModels;
using HotelReservation.ViewModels.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HotelReservation.ViewModels;

public class ReservationListingViewModel : ViewModelBase
{
    private readonly ObservableCollection<ReservationViewModel> _reservation;

    public IEnumerable<ReservationViewModel> Reservations => _reservation;
    public ICommand MakeReservationcommand { get; }



    public ReservationListingViewModel()
    {
        MakeReservationcommand = new NavigateCommand();
        _reservation = new ObservableCollection<ReservationViewModel>();
        _reservation.Add(
            new ReservationViewModel(new Reservation(
                new RoomID(1, 3),
                "userName",
                new DateTime(2024, 1, 1),
                new DateTime(2024, 1, 2))));
        _reservation.Add(
           new ReservationViewModel(new Reservation(
               new RoomID(2, 3),
               "userName2",
               new DateTime(2024, 1, 1),
               new DateTime(2024, 1, 2))));
        _reservation.Add(
           new ReservationViewModel(new Reservation(
               new RoomID(1, 3),
               "userName3",
               new DateTime(2024, 1, 3),
               new DateTime(2024, 1, 4))));
    }
}
