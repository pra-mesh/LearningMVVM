using HotelReservation.Models;
using HotelReservation.Services;
using HotelReservation.ViewModels.Commands;
using HotelReservation.ViewModels.Stores;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HotelReservation.ViewModels;

public class ReservationListingViewModel : ViewModelBase
{
  private readonly ObservableCollection<ReservationViewModel> _reservation;
  private readonly HotelStore _hotelStore;

  public IEnumerable<ReservationViewModel> Reservations => _reservation;
  public ICommand MakeReservationcommand { get; }
  public ICommand LoadReservationCommand { get; }



  public ReservationListingViewModel(HotelStore hotelStore, NavigationService navigationService)
  {
    _hotelStore = hotelStore;
    _reservation = new ObservableCollection<ReservationViewModel>();
    MakeReservationcommand = new NavigateCommand(navigationService);
    LoadReservationCommand = new LoadReservationCommand(hotelStore, this);
    hotelStore.ReservationMade += OnReservationMade;
    //UpdateReservations();
  }

  public override void Dispose()
  {
    _hotelStore.ReservationMade -= OnReservationMade;
    base.Dispose();
  }
  public static ReservationListingViewModel LoadViewModel(HotelStore hotelStore, NavigationService navigationService)
  {
    ReservationListingViewModel reservationListingViewModel = new ReservationListingViewModel(hotelStore, navigationService);
    reservationListingViewModel.LoadReservationCommand.Execute(null);

    return reservationListingViewModel;
  }

  private void OnReservationMade(Reservation reservation)
  {
    ReservationViewModel reservationViewModel = new ReservationViewModel(reservation);
    _reservation.Add(reservationViewModel);
  }

  public void UpdateReservations(IEnumerable<Reservation> reservations)
  {
    _reservation.Clear();
    foreach (Reservation reservation in reservations)
    {
      ReservationViewModel viewModel = new ReservationViewModel(reservation);
      _reservation.Add(viewModel);
    }
  }
}
