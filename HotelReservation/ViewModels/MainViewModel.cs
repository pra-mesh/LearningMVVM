using HotelReservation.Models;
using HotelReservation.ViaewModels;

namespace HotelReservation.ViewModels;

public class MainViewModel : ViewModelBase
{
    public ViewModelBase CurrentViewModel { get; }

    public MainViewModel(Hotel hotel)
    {
        CurrentViewModel = new ReservationListingViewModel();
    }
}
