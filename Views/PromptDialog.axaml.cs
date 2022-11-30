using System.Reactive;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using SeansAvaloniaExamples.ViewModels;

namespace SeansAvaloniaExamples.Views;

public partial class PromptDialog : ReactiveWindow<PromptDialogViewModel>
{
    public PromptDialog()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}