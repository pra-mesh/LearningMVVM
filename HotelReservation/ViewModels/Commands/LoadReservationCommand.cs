using HotelReservation.ViewModels.Stores;
using System.Windows;

namespace HotelReservation.ViewModels.Commands;

public class LoadReservationCommand : AsyncCommandBase
{
  private readonly HotelStore _hotelStore;
  private readonly ReservationListingViewModel _reservationListingViewModel;

  public LoadReservationCommand(HotelStore hotelStore, ReservationListingViewModel reservationListingViewModel)
  {
    _hotelStore = hotelStore;
    _reservationListingViewModel = reservationListingViewModel;
  }
  public override async Task ExecuteAsync(object? parameter)
  {
    try
    {
      await _hotelStore.Load();
      _reservationListingViewModel.UpdateReservations(_hotelStore.Reservations);
    }
    catch (Exception)
    {
      MessageBox.Show("Failed to load Reservation.",
         "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    }
  }
}
