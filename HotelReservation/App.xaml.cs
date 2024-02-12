using HotelReservation.DbContexts;
using HotelReservation.Models;
using HotelReservation.Services.ReservationConflictValidators;
using HotelReservation.Services.ReservationCreators;
using HotelReservation.Services.ReservationProviders;
using HotelReservation.ViewModels;
using HotelReservation.ViewModels.Stores;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace HotelReservation;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
  private const string Connection_String = "Data Source = Data.db";
  private readonly Hotel _hotel;
  private readonly NavigationStore _nav;
  private readonly HotelReservationDbContextFactory _hotelReservationDbContextFactory;
  private readonly HotelStore _hotelStore;

  public App()
  {
    _hotelReservationDbContextFactory = new HotelReservationDbContextFactory(Connection_String);
    IReservationProvider reservationProvider = new DatabaseReservationProvider(_hotelReservationDbContextFactory);
    IReservationCreator reservationCreator = new DatabaseReservationCreator(_hotelReservationDbContextFactory);
    IReservationConflictValidators reservationConflictValidators = new DatabaseReservationConflictValidators(_hotelReservationDbContextFactory);
    ReservationBook reservationBook = new ReservationBook(reservationProvider, reservationCreator, reservationConflictValidators);

    _hotel = new Hotel("Learning MVVM", reservationBook);
    _hotelStore = new HotelStore(_hotel);
    _nav = new NavigationStore();
  }
  protected override void OnStartup(StartupEventArgs e)
  {
    DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(Connection_String).Options;

    using (HotelReservationDbContext dbContext = _hotelReservationDbContextFactory.CreateDbContext())
    {
      dbContext.Database.Migrate();
    }

    _nav.CurrentViewModel = CreateReservationViewModel();
    MainWindow = new MainWindow()
    {
      DataContext = new MainViewModel(_nav)
    };

    MainWindow.Show();
    base.OnStartup(e);
  }

  private MakeReservationViewModel CreateMakeReservationViewModel()
  {
    return new MakeReservationViewModel(_hotelStore, new(_nav, CreateReservationViewModel),
      new(_nav, CreatePaymentViewMode));
  }

  private PaymentViewModel CreatePaymentViewMode()
  {
    return new PaymentViewModel();
  }

  private ReservationListingViewModel CreateReservationViewModel()
  {
    return ReservationListingViewModel.LoadViewModel(_hotelStore, new(_nav, CreateMakeReservationViewModel));
  }
}

