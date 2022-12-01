using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using SeansAvaloniaExamples.ViewModels;

namespace SeansAvaloniaExamples.Views;

public partial class SubWindow : ReactiveWindow<SubWindowViewModel>
{
    public SubWindow()
    {
        InitializeComponent();
    }
}