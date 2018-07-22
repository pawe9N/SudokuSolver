using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace SudokuSolver.Pages
{
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            ChooseDifficulty chooseDifficultyPage = new ChooseDifficulty();
            NavigationService.Navigate(chooseDifficultyPage);
        }

        private void Solver_Click(object sender, RoutedEventArgs e)
        {
            SolverPage solverPage = new SolverPage();
            NavigationService.Navigate(solverPage);
        }
    }
}
