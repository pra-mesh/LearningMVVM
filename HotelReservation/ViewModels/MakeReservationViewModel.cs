using HotelReservation.Services;
using HotelReservation.ViewModels.Commands;
using HotelReservation.ViewModels.Stores;
using System.Windows.Input;



namespace HotelReservation.ViewModels;
public class MakeReservationViewModel : ViewModelBase
{

  private string? _username;
  public string UserName
  {
    get
    {
      return _username;
    }
    set
    {
      _username = value;
      OnPropertyChanged(nameof(UserName));
    }
  }

  private int _floorNo;
  public int FloorNo
  {
    get
    {
      return _floorNo;
    }
    set
    {
      _floorNo = value;
      OnPropertyChanged(nameof(FloorNo));
    }
  }

  private int _roomNo;
  public int RoomNo
  {
    get
    {
      return _roomNo;
    }
    set
    {
      _roomNo = value;
      OnPropertyChanged(nameof(RoomNo));
    }
  }

  private DateTime _startdate = DateTime.Now;
  public DateTime StartDate
  {
    get
    {
      return _startdate;
    }
    set
    {
      _startdate = value;
      OnPropertyChanged(nameof(StartDate));
    }
  }
  private DateTime _endDate = DateTime.Now;


  public DateTime EndDate
  {
    get
    {
      return _endDate;
    }
    set
    {
      _endDate = value;
      OnPropertyChanged(nameof(EndDate));
    }
  }

  public ICommand? SubmitCommand { get; }
  public ICommand? CancelCommand { get; }
  public ICommand? PayCommand { get; }

  public MakeReservationViewModel(HotelStore hotelStore, NavigationService navigationService, NavigationService payment)
  {
    SubmitCommand = new MakeReservationCommand(this, hotelStore, navigationService);
    CancelCommand = new NavigateCommand(navigationService);
    PayCommand = new NavigateCommand(payment);


  }

  public void ClearReservation()
  {
    UserName = "";
    FloorNo = 0;
    RoomNo = 0;
    StartDate = DateTime.Today;
    EndDate = DateTime.Today.AddDays(1);
  }

}
