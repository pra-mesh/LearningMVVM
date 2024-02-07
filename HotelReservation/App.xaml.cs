using HotelReservation.Exceptions;
using HotelReservation.Models;
using System.Configuration;
using System.Data;
using System.Windows;

namespace HotelReservation;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        Hotel hotel = new Hotel("Learning MVVM");
        try
        {
            hotel.MakeReservation(new Reservation(
                new RoomID(1, 3),
                "userName",
                new DateTime(2024, 1, 1),
                new DateTime(2024, 1, 2)
                ));
            hotel.MakeReservation(new Reservation(
               new RoomID(2, 3),
               "userName",
               new DateTime(2024, 1, 1),
               new DateTime(2024, 1, 2)
               ));

            hotel.MakeReservation(new Reservation(
                new RoomID(2, 3),
                "userName",
                new DateTime(2024, 1, 1),
                new DateTime(2024, 1, 2)
                ));
        }
        catch(ReservationConflictException ex)
        {

        }
        IEnumerable<Reservation> reservations = hotel.GetReservationsForUser("userName");
        base.OnStartup(e);
    }
}

