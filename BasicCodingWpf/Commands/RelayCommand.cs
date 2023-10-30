using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BasicCodingWpf.Commands;

public class RelayCommand : ICommand
{
    private readonly Action<object?> _Execute;
    private readonly Predicate<object?> _CanExecute;
    
    public RelayCommand(Action<object?> execute) : this(execute, null) { }

    public RelayCommand(Action<object?> execute, Predicate<object?> canExecute)
    {
        _Execute = execute ?? throw new ArgumentNullException("The parameter 'execute' can not be 'null'. Object: " + nameof(execute));
        _CanExecute = canExecute;
    }
    
    public bool CanExecute(object? parameter)
    {
        return _CanExecute == null || _CanExecute(parameter);
    }

    public void Execute(object? parameter)
    {
        _Execute(parameter);
    }

    public event EventHandler? CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }
}
