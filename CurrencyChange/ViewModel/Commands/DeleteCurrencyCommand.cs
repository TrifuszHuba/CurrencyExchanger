using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CurrencyChange.ViewModel.Commands
{
    public class DeleteCurrencyCommand : ICommand
    {
        public CurrencyChangeVM VM { get; set; }
        public DeleteCurrencyCommand(CurrencyChangeVM vm)
        {
            VM = vm;
        }

        event EventHandler? ICommand.CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        bool ICommand.CanExecute(object? parameter)
        {
            return true;

        }

        void ICommand.Execute(object? parameter)
        {
            VM.DeleteCurrency(parameter as string);
        }
    }
}
