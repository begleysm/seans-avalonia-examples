using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SeansAvaloniaExamples.Views;

public partial class SubWindow : Window
{
    public SubWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}