using System;
using System.Windows.Input;

namespace PaginationWPF.pg
{
    public class ChangePageCommand : ICommand
    {
        Action<object> _method_to_execute;
        Func<object, bool> _if_can_execute;

        public ChangePageCommand(Action<object> method_to_execute, Func<object, bool> if_can_execute = null)
        {
            _method_to_execute = method_to_execute;
            _if_can_execute = if_can_execute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (_if_can_execute ==null)
            {
                return true;
            } else
            {
                return _if_can_execute.Invoke(parameter);
            }
           
        }

        public void Execute(object parameter)
        {
            _method_to_execute?.Invoke(parameter);
        }
    }
}
