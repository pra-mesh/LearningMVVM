using HotelReservation.Services;
using HotelReservation.ViewModels.Commands;
using HotelReservation.ViewModels.Stores;
using System.Collections;
using System.ComponentModel;
using System.Windows.Input;



namespace HotelReservation.ViewModels;
public class MakeReservationViewModel : ViewModelBase, INotifyDataErrorInfo
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

  private DateTime _startDate = DateTime.Now;
  public DateTime StartDate
  {
    get
    {
      return _startDate;
    }
    set
    {
      _startDate = value;
      OnPropertyChanged(nameof(StartDate));
      ClearErrors(nameof(EndDate));
      ClearErrors(nameof(StartDate));
      if (EndDate <= StartDate)
      {
        AddError("The start date can't be after the end Date", nameof(StartDate));
      }
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
      ClearErrors(nameof(StartDate));
      ClearErrors(nameof(EndDate));
      if (EndDate <= StartDate)
      {
        AddError("The end date can't be before the startDte", nameof(EndDate));
      }

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

    _propertyNameToErrorsDictionary = new Dictionary<string, List<string>>();
  }

  public void ClearReservation()
  {
    UserName = "";
    FloorNo = 0;
    RoomNo = 0;
    StartDate = DateTime.Today;
    EndDate = DateTime.Today.AddDays(1);
  }



  private readonly Dictionary<string, List<string>> _propertyNameToErrorsDictionary;
  public IEnumerable GetErrors(string? propertyName)
  {
    return _propertyNameToErrorsDictionary.GetValueOrDefault(propertyName, new List<string>());
  }
  private void AddError(string errorMessage, string propertyName)
  {
    if (!_propertyNameToErrorsDictionary.ContainsKey(propertyName))
    {
      _propertyNameToErrorsDictionary.Add(propertyName, new List<string>());
    }
    _propertyNameToErrorsDictionary[propertyName].Add(errorMessage);

    OnErrorsChanged(propertyName);
  }

  private void OnErrorsChanged(string propertyName)
  {
    ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
  }

  private void ClearErrors(string propertyName)
  {
    _propertyNameToErrorsDictionary.Remove(propertyName);
    OnErrorsChanged(propertyName);
  }
  public bool HasErrors => _propertyNameToErrorsDictionary.Any();

  public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;
}
