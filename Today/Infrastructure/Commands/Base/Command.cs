using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Today.Infrastructure.Commands.Base
{
    internal abstract class Command : ICommand
    {
        // Событие, когда команда меняет состояние. Делегируем контроль за изменениями менеджеру команд
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        // Если возращает ложь, то команду выполнить нельзя. Можно выключить работу с визуальным елементом, но для этого нужно вернуть ложь
        public abstract bool CanExecute(object parameter);

        // Основная логика команды 
        public abstract void Execute(object parameter);
    }
}
