using System;
using System.Windows;

namespace SudokuSolver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            CloseWindowWhileRunningTests();
            MainFrame.Navigate(new Uri("Pages/StartPage.xaml", UriKind.Relative)); 
        }

        public void CloseWindowWhileRunningTests()
        {
            #if TEST
                App.Current.MainWindow.Close();
            #endif
        }
    }
}
