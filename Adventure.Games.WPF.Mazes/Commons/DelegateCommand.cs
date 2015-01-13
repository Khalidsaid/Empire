using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Adventure.Games.WPF.Mazes.Commons
{
    
    public class DelegateCommand : ICommand
    {
        private readonly Func<bool> canExecute;
        private readonly Action<object> execute;

        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action<object> execute,
                       Func<bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public virtual bool CanExecute(object parameter)
        {
            return execute != null && canExecute != null && canExecute();
        }

        public virtual void Execute(object parameter)
        {
            execute(parameter);
        }

        public virtual void OnCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }
    }

    public class DelegateCommand<T> : ICommand
    {
        private readonly Predicate<T> canExecute;
        private readonly Action<T> execute;

        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action<T> execute,
                       Predicate<T> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public virtual bool CanExecute(object parameter)
        {
            if (parameter == null || execute == null || canExecute == null) return false;
            return canExecute((T)parameter);
        }

        public virtual void Execute(object parameter)
        {
            execute((T)parameter);
        }

        public virtual void OnCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }
    }
}
