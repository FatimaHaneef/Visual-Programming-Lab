using System.Collections.ObjectModel;
using System.Windows;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<string> players;

        public MainWindow()
        {
            InitializeComponent();
            players = new ObservableCollection<string>();
            PlayersListBox.ItemsSource = players; 
            PlaceholderTextBlock.Visibility = Visibility.Visible; 

        private void PlayerNameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            PlaceholderTextBlock.Visibility = Visibility.Collapsed; // Hide placeholder when focused
        }

        private void PlayerNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(PlayerNameTextBox.Text))
            {
                PlaceholderTextBlock.Visibility = Visibility.Visible; // Show placeholder if no text
            }
        }

        private void PlayerNameTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(PlayerNameTextBox.Text))
            {
                PlaceholderTextBlock.Visibility = Visibility.Collapsed; // Hide placeholder if text is present
            }
        }

        private void AddPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            string playerName = PlayerNameTextBox.Text.Trim();

           
            if (string.IsNullOrEmpty(playerName))
            {
                MessageBox.Show("Player name cannot be empty.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (players.Contains(playerName))
            {
                MessageBox.Show("Player already exists in the roster.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

    
            players.Add(playerName);
            PlayerNameTextBox.Clear(); 
            PlaceholderTextBlock.Visibility = Visibility.Visible; 
        }

        private void RemovePlayerButton_Click(object sender, RoutedEventArgs e)
        {
            if (PlayersListBox.SelectedItem != null)
            {
                players.Remove(PlayersListBox.SelectedItem.ToString()); // Remove selected player
            }
            else
            {
                MessageBox.Show("Please select a player to remove.", "Selection Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}