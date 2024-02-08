using HotelReservation.Models;
using HotelReservation.ViewModels.Commands;
using System.Windows.Input;

namespace HotelReservation.ViaewModels;
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

    public MakeReservationViewModel(Hotel hotel)
    {
        SubmitCommand = new MakeReservationCommand(this, hotel);
        CancelCommand = new CancelMakeReservationCommand();
    }

}
