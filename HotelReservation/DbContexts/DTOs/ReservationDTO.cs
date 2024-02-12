using System.ComponentModel.DataAnnotations;

namespace HotelReservation.DbContexts;

public class ReservationDTO
{
  [Key]
  public Guid Id { get; set; }
  public int FloorNumber { get; set; }
  public int RoomNumber { get; set; }
  public string? UserName { get; set; }
  public DateTime StartDate { get; set; }
  public DateTime EndData { get; set; }
}