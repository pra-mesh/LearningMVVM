using HotelReservation.ViewModels.Stores;

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
    _reservationListingViewModel.ErrorMessage = string.Empty;
    _reservationListingViewModel.IsLoading = true;
    try
    {

      await _hotelStore.Load();
      _reservationListingViewModel.UpdateReservations(_hotelStore.Reservations);
    }
    catch (Exception)
    {
      _reservationListingViewModel.ErrorMessage = "Failed to load Reservation.";
    }
    _reservationListingViewModel.IsLoading = false;
  }
}
