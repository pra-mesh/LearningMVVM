using Microsoft.EntityFrameworkCore;

namespace HotelReservation.DbContexts;

public class HotelReservationDbContext : DbContext
{
  public HotelReservationDbContext(DbContextOptions options) : base(options)
  {
  }

  public DbSet<ReservationDTO> Reservations { get; set; }
}
