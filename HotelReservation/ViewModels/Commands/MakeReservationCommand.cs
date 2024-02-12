using HotelReservation.Exceptions;
using HotelReservation.Models;
using HotelReservation.Services;
using HotelReservation.ViewModels.Stores;
using System.ComponentModel;
using System.Windows;


namespace HotelReservation.ViewModels.Commands;

public class MakeReservationCommand : AsyncCommandBase
{
  private readonly MakeReservationViewModel _makeReservationViewModel;
  private readonly HotelStore _hotelStore;
  private readonly NavigationService _reservationViewNavigationService;

  public MakeReservationCommand(MakeReservationViewModel makeReservationViewModel, HotelStore hotelStore, NavigationService reservationViewNavigationService)
  {
    _makeReservationViewModel = makeReservationViewModel;
    _hotelStore = hotelStore;
    _reservationViewNavigationService = reservationViewNavigationService;
    _makeReservationViewModel.PropertyChanged += OnViewModelPropertyChange;
  }

  private void OnViewModelPropertyChange(object? sender, PropertyChangedEventArgs e)
  {
    if (e.PropertyName == nameof(MakeReservationViewModel.UserName))
    {
      OnCanExecuteChanged();
    }
  }

  public override bool CanExecute(object? parameter)
  {
    return !string.IsNullOrWhiteSpace(_makeReservationViewModel.UserName) && base.CanExecute(parameter);
  }
  public override async Task ExecuteAsync(object? parameter)
  {
    Reservation reservation = new Reservation(new RoomID(_makeReservationViewModel.FloorNo,
        _makeReservationViewModel.RoomNo), _makeReservationViewModel.UserName,
        _makeReservationViewModel.StartDate, _makeReservationViewModel.EndDate);
    try
    {
      await _hotelStore.MakeReservation(reservation);
      MessageBox.Show("Successfully Reserved the room",
         "Success", MessageBoxButton.OK, MessageBoxImage.Information);
      _makeReservationViewModel.ClearReservation();


      //_reservationViewNavigationService.Navigate();


      //_makeReservationViewModel.CancelCommand.Execute(parameter);
      //var p = _hotel.GetReservations();

    }
    catch (ReservationConflictException)
    {
      MessageBox.Show("This room us already taken.",
          "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    }
    catch (Exception)
    {
      MessageBox.Show("Failed to make Reservation.",
          "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    }
  }


}
