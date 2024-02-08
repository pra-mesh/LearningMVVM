using HotelReservation.Exceptions;
using HotelReservation.Models;
using HotelReservation.ViaewModels;
using HotelReservation.ViewModels.Command;
using System.ComponentModel;
using System.Windows;

namespace HotelReservation.ViewModels.Commands;

public class MakeReservationCommand : CommandBase
{
    private readonly MakeReservationViewModel _makeReservationViewModel;
    private readonly Hotel _hotel;

    public MakeReservationCommand(MakeReservationViewModel makeReservationViewModel, Hotel hotel)
    {
        _makeReservationViewModel = makeReservationViewModel;
        _hotel = hotel;
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
    public override void Execute(object? parameter)
    {
        Reservation reservation = new Reservation(new RoomID(_makeReservationViewModel.FloorNo,
            _makeReservationViewModel.RoomNo), _makeReservationViewModel.UserName,
            _makeReservationViewModel.StartDate, _makeReservationViewModel.EndDate);
        try
        {
            _hotel.MakeReservation(reservation);
            MessageBox.Show("Successfully Reserved the room",
               "Success", MessageBoxButton.OK, MessageBoxImage.Information);

        }
        catch (ReservationConflictException)
        {
            MessageBox.Show("This room us already taken.",
                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

    }
}
