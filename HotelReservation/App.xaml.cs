using HotelReservation.Models;
using HotelReservation.ViewModels;
using System.Windows;

namespace HotelReservation;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly Hotel _hotel;
    public App()
    {
        _hotel = new Hotel("Learning MVVM");
    }
    protected override void OnStartup(StartupEventArgs e)
    {
        MainWindow = new MainWindow()
        {
            DataContext = new MainViewModel(_hotel)
        };

        MainWindow.Show();
        base.OnStartup(e);
    }
}

