using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CurrencyChange.ViewModel.Commands
{
    public class AddCurrencyCommand : ICommand
    {
        public CurrencyChangeVM VM { get; set; }
        public AddCurrencyCommand(CurrencyChangeVM vm)
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
            VM.AddCurrency();
        }
    }
}
