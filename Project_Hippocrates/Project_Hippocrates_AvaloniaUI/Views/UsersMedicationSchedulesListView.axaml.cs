using Avalonia.Controls;

namespace Project_Hippocrates_AvaloniaUI.Views
{
    public partial class UsersMedicationSchedulesListView : UserControl
    {
        public UsersMedicationSchedulesListView()
        {
            InitializeComponent();
        }

        private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            SideMenuTest.IsMenuOpen = !SideMenuTest.IsMenuOpen;
        }
    }
}