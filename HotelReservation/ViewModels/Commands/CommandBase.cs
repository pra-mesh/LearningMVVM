using System.Windows.Input;

namespace HotelReservation.ViewModels.Commands;
public abstract class CommandBase : ICommand
{
  public virtual bool CanExecute(object? parameter)
  {
    return true;
  }

  public abstract void Execute(object? parameter);
  public void OnCanExecuteChanged()
  {
    CanExecuteChanged?.Invoke(this, new EventArgs());
  }

  public event EventHandler? CanExecuteChanged;
}
