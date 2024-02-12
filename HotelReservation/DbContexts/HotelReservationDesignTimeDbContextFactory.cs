using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HotelReservation.DbContexts;

public class HotelReservationDesignTimeDbContextFactory : IDesignTimeDbContextFactory<HotelReservationDbContext>
{
  public HotelReservationDbContext CreateDbContext(string[] args)
  {
    DbContextOptions options = new DbContextOptionsBuilder().UseSqlite("Data Source = Data.db").Options;

    return new HotelReservationDbContext(options);
  }
}
