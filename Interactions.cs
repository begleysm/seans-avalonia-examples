using System.Reactive;
using ReactiveUI;

namespace SeansAvaloniaExamples;

public static class Interactions
{
    public static readonly Interaction<Unit, Unit> SubWindow = new();
    public static readonly Interaction<Unit, Unit> PromptDialog = new();
    public static readonly Interaction<Unit, Unit> CancelButton = new();
}