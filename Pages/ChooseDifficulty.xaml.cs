using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace SudokuSolver.Pages
{
    public partial class ChooseDifficulty : Page
    {
        public ChooseDifficulty()
        {
            InitializeComponent();
        }

        private void VeryEasyButton_Click(object sender, RoutedEventArgs e)
        {
            Game gamePage = new Game(1);
            NavigationService.Navigate(gamePage);
        }

        private void EasyButton_Click(object sender, RoutedEventArgs e)
        {
            Game gamePage = new Game(10);
            NavigationService.Navigate(gamePage);
        }

        private void NormalButton_Click(object sender, RoutedEventArgs e)
        {
            Game gamePage = new Game(20);
            NavigationService.Navigate(gamePage);
        }

        private void HardButton_Click(object sender, RoutedEventArgs e)
        {
            Game gamePage = new Game(30);
            NavigationService.Navigate(gamePage);
        }

        private void VeryHardButton_Click(object sender, RoutedEventArgs e)
        {
            Game gamePage = new Game(40);
            NavigationService.Navigate(gamePage);
        }
    }
}
