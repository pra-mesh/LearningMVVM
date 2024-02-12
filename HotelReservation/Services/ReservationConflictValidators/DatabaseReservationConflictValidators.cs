using HotelReservation.DbContexts;
using HotelReservation.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.Services.ReservationConflictValidators;

public class DatabaseReservationConflictValidators : IReservationConflictValidators
{
  private readonly HotelReservationDbContextFactory _dbContextFactory;

  public DatabaseReservationConflictValidators(HotelReservationDbContextFactory dbContextFactory)
  {
    _dbContextFactory = dbContextFactory;
  }
  public async Task<Reservation?> DoesReservationConflicts(Reservation reservation)
  {
    using (HotelReservationDbContext context = _dbContextFactory.CreateDbContext())
    {
      var v = from r in context.Reservations
              where r.FloorNumber == reservation.RoomID.FloorNumber && r.RoomNumber == reservation.RoomID.RoomNumber
              && (r.EndData > reservation.StartDate || r.StartDate < reservation.EndDate)
              select r;
      ReservationDTO? reservationDTO = await context.Reservations.Where(r => r.FloorNumber == reservation.RoomID.FloorNumber)
       .Where(r => r.FloorNumber == reservation.RoomID.FloorNumber)
        .Where(r => r.EndData > reservation.StartDate)
         .Where(r => r.StartDate < reservation.EndDate)
       .FirstOrDefaultAsync();
      if (reservationDTO == null)
      {
        return null;
      }
      return ToReservation(reservationDTO);
    }
  }
  private static Reservation ToReservation(ReservationDTO r)
  {
    return new Reservation(new RoomID(r.FloorNumber, r.RoomNumber), r.UserName, r.StartDate, r.EndData);
  }
}
