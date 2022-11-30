using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;

namespace SeansAvaloniaExamples.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
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
            await Interactions.SubWindow.Handle(Unit.Default);
        }
        
        private async Task PromptDialogAsync()
        {
            var result = await Interactions.PromptDialog.Handle(Unit.Default);
        }
    }
}