using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;

namespace SeansAvaloniaExamples.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public static readonly Interaction<Unit, Unit> SubWindow = new();
        public static readonly Interaction<Unit, Unit> PromptDialog = new();
        public static readonly Interaction<Unit, Unit> CancelButton = new();
        public ReactiveCommand<Unit, Unit> Button_Command { get; }
        public ICommand ShowSubWindow { get; }
        public ICommand ShowPromptDialog { get; }
        public MainWindowViewModel()
        {
            Button_Command = ReactiveCommand.Create(ButtonMethod);
            ShowSubWindow = ReactiveCommand.CreateFromTask(SubWindowAsync);
            ShowPromptDialog = ReactiveCommand.CreateFromTask(PromptDialogAsync);
        }

        void ButtonMethod()
        {
            int x = 5;
        }
        
        private async Task SubWindowAsync()
        {
            await SubWindow.Handle(Unit.Default);
        }
        
        private async Task PromptDialogAsync()
        {
            var result = await PromptDialog.Handle(Unit.Default);
        }
    }
}