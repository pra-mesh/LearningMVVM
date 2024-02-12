using HotelReservation.DbContexts;
using HotelReservation.Models;

namespace HotelReservation.Services.ReservationCreators;

public class DatabaseReservationCreator : IReservationCreator
{
  private readonly HotelReservationDbContextFactory _dbContextFactory;

  public DatabaseReservationCreator(HotelReservationDbContextFactory dbContextFactory)
  {
    _dbContextFactory = dbContextFactory;
  }

  public async Task CreateReservation(Reservation reservation)
  {
    using (HotelReservationDbContext context = _dbContextFactory.CreateDbContext())
    {
      ReservationDTO reservationDTO = ToReservationDTO(reservation);
      await context.Reservations.AddAsync(reservationDTO);
      await context.SaveChangesAsync();
    }
  }

  private ReservationDTO ToReservationDTO(Reservation reservation)
  {
    return new ReservationDTO()
    {
      FloorNumber = reservation.RoomID?.FloorNumber ?? 0,
      RoomNumber = reservation.RoomID?.RoomNumber ?? 0,
      UserName = reservation.Username?.ToString() ?? "",
      StartDate = reservation.StartDate,
      EndData = reservation.EndDate
    };
  }
}
