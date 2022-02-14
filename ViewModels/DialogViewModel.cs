using Services;
using Services.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModels
{
    public class DialogViewModel : IDialogRequestClose
    {
        public string Message { get; }
        public ICommand OkCommand { get; }
        public ICommand CancelCommand { get; }
        public event EventHandler<DialogCloseRequestedEventArgs> CloseRequested;
        public DialogViewModel(string message)
        {
            Message = message;
            OkCommand = new RelayCommand(p => CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(true)));
            CancelCommand = new RelayCommand(p => CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(false)));
        }
    }
}
