using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace SudokuSolver.Pages
{
    /// <summary>
    /// Interaction logic for StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            NavigationService navService = NavigationService.GetNavigationService(this);
            navService.Navigate(new System.Uri("/Pages/Game.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Solver_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
