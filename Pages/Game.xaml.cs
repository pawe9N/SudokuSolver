using SudokuSolver.Classes;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;

namespace SudokuSolver.Pages
{
    public partial class Game : Page
    {
        private int level;
        private int points;
        private int[] grid;
        private int[] solved;
        private int[] tempGrid;
        GridDrafter gridDrafter;

        public Game(int level)
        {
            InitializeComponent();
            this.level = level;
            points = 0;

            NewSudoku();
        }

        private void NewSudoku()
        {
            myCanvas.Children.Clear();

            GridMaker.AddRandomDigitsToGrid(ref grid, 81-level);
            gridDrafter = new GridDrafter(grid);

            gridDrafter.CreateGridForSudoku(myCanvas);

            solved = new int[81];
            Array.Copy(grid, solved, 81);

            Solver.TrySolveSudoku(solved);

            gridDrafter.AddInputsForUser(myCanvas, grid);

            TextBox[] tbs = gridDrafter.GetInputs();
            foreach (TextBox tb in tbs)
            {
                if (tb != null)
                {
                    tb.KeyDown += Inputs_KeyDown;
                }
            }

            NextSudoku.IsEnabled = false;
            CheckInputs.IsEnabled = true;
            SolveButton.IsEnabled = true;
            PointsText.Content = $"Points: {points}";
        }

        private void SolveButton_Click(object sender, RoutedEventArgs e)
        {
            myCanvas.Children.Clear();
            Solver.TrySolveSudoku(grid);

            gridDrafter = new GridDrafter(grid);

            gridDrafter.CreateGridForSudoku(myCanvas);
            gridDrafter.AddInputsForUser(myCanvas, grid);

            CheckInputs.IsEnabled = false;
            SolveButton.IsEnabled = false;
            NextSudoku.IsEnabled = true;
        }

        private void CheckInputs_Click(object sender, RoutedEventArgs e)
        {
            tempGrid = new int[81];
            Array.Copy(grid, tempGrid, 81);

            TextBox [] tbs = gridDrafter.GetInputs();

            for(int i=0; i<81; i++)
            {
                if(tbs[i] != null && tbs[i].Text.ToString().Length != 0)
                {
                    tempGrid[i] = Int32.Parse(tbs[i].Text.ToString());
                }
            }

            for(int i=0; i<81; i++)
            {
                if(tbs[i] != null)
                {
                    if (solved[i] != tempGrid[i] && tempGrid[i] != 0)
                    {
                        tbs[i].Foreground = new SolidColorBrush(Colors.Red);
                        if (points > 0)
                        {
                            points--;
                            PointsText.Content = $"Points: {points}";
                        }
                    }
                    else if(tempGrid[i] != 0)
                    {
                        tbs[i].Foreground = new SolidColorBrush(Colors.DarkGreen);
                        tbs[i].IsEnabled = false;
                    }
                }
            }

            bool gridsAreEqual = Enumerable.SequenceEqual(tempGrid, solved);
            if(gridsAreEqual)
            {
                points += 10*(level-1)+1;
                if(level<80)
                {
                    level++;
                }
                PointsText.Content = $"Points: {points}";
                NextSudoku.IsEnabled = true;
                NextSudoku.Focus();
                CheckInputs.IsEnabled = false;
            }

        }

        private void NextSudoku_Click(object sender, RoutedEventArgs e)
        {
            NewSudoku();
        }

        private void Inputs_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                CheckInputs.Focus();
            }
        }

        private void BackButtone_Click(object sender, RoutedEventArgs e)
        {
            StartPage startPage = new StartPage();
            NavigationService.Navigate(startPage);
        }
    }
}
