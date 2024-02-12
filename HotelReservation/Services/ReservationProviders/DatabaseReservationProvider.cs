using HotelReservation.DbContexts;
using HotelReservation.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.Services.ReservationProviders;

public class DatabaseReservationProvider : IReservationProvider
{
  private readonly HotelReservationDbContextFactory _dbContextFactory;

  public DatabaseReservationProvider(HotelReservationDbContextFactory dbContextFactory)
  {
    _dbContextFactory = dbContextFactory;
  }
  public async Task<IEnumerable<Reservation>> GetAllReservation()
  {
    using (HotelReservationDbContext context = _dbContextFactory.CreateDbContext())
    {
      IEnumerable<ReservationDTO> reservationDTOs = await context.Reservations.ToListAsync();
      await Task.Delay(2000);
      return reservationDTOs.Select(r => ToReservation(r));
    }
  }

  private static Reservation ToReservation(ReservationDTO r)
  {
    return new Reservation(new RoomID(r.FloorNumber, r.RoomNumber), r.UserName, r.StartDate, r.EndData);
  }
}
