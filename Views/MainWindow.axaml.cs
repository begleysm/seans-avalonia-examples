using System;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.ReactiveUI;
using Avalonia.Threading;
using ReactiveUI;
using SeansAvaloniaExamples.ViewModels;

namespace SeansAvaloniaExamples.Views
{
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();

            //CHECKBOX
            _checkBoxIndicator = this.Get<CheckBox>("CheckBoxIndicator");
            _checkBoxIndicator.Click += CheckBoxChanged;
            
            //COMBOBOX
            _comboBoxIndicator = this.Get<ComboBox>("ComboBoxIndicator");
            _comboBoxIndicator.SelectionChanged += ComboBoxChanged;
            
            //WINDOWS & PROMPTS
            this.WhenActivated(d =>
            {
                d(Interactions.SubWindow.RegisterHandler(SubWindowAsync));
                d(Interactions.PromptDialog.RegisterHandler(PromptDialogAsync));
            });
            
            //LIVE TIME
            DispatcherTimer LiveTimer = new DispatcherTimer();
            LiveTimer.Interval = TimeSpan.FromSeconds(1);
            LiveTimer.Tick += timer_Tick;
            LiveTimer.Start();
            
            //LIVE DATE
            LiveDateLabel.Text = DateTime.UtcNow.ToString("dd/MMM/yyyy").ToUpper();
        }

        //CHECKBOX
        private CheckBox _checkBoxIndicator;
        
        //COMBOBOX
        private ComboBox _comboBoxIndicator;
        
        //CHECKBOX
        private void CheckBoxChanged(object? sender, RoutedEventArgs e)
        {
            if ((bool)_checkBoxIndicator.IsChecked)
            {
                LabelCheckBoxIndicator.Background = Brushes.Green;
            }
            else
            {
                LabelCheckBoxIndicator.Background = Brushes.Red;
            }
        }
        
        //COMBOBOX
        private void ComboBoxChanged(object? sender, SelectionChangedEventArgs e)
        {
            switch (_comboBoxIndicator.SelectedIndex)
            {
                case 0:
                    LabelComboBoxIndicator.Background = Brushes.Red;
                    break;
                case 1:
                    LabelComboBoxIndicator.Background = Brushes.Green;
                    break;
            }
        }
        
        //VIEW SERVICED BUTTON
        private void Button_OnClick(object? sender, RoutedEventArgs e)
        {
            int x = 5;
        }
        
        //NEW WINDOW
        private async Task SubWindowAsync(InteractionContext<Unit, Unit> interaction)
        {
            // Create a window instance and then, if there is an instance of the same type open, use it
            var window = new SubWindow();
            if (App.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                window = desktop.Windows.OfType<SubWindow>().FirstOrDefault();
            }

            // if we were unable to find an existing instance then create a new window and show it.
            // else bring the existing window to the fore
            if (window == null)
            {
                window = new SubWindow()
                {
                    DataContext = new SubWindowViewModel()
                };
                window.Show(this);
                interaction.SetOutput(Unit.Default);
            }
            else
            {
                window.Activate();
                interaction.SetOutput(Unit.Default);
            }
        }
        
        //NEW PROMPT
        private async Task PromptDialogAsync(InteractionContext<Unit, Unit> interaction)
        {
            var dialog = new PromptDialog()
            {
                DataContext = new PromptDialogViewModel()
            };

            var result = await dialog.ShowDialog<Unit>(this);
            interaction.SetOutput(result);
        }
        
        //LIVE TIME
        void timer_Tick(object sender, EventArgs e)
        {
            LiveTimeLabel.Text = DateTime.UtcNow.ToString("HH:mm:ss \"Z\"");
        }
    }
}