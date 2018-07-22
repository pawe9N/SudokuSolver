using SudokuSolver.Classes;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace SudokuSolver.Pages
{
    public partial class SolverPage : Page
    {
        private int [] grid;
        private GridDrafter gridDrafter;

        public SolverPage()
        {
            InitializeComponent();

            MakeEmptySudoku();
        }

        private void SolveButton_Click(object sender, RoutedEventArgs e)
        {
            if(!SolveGrid())
            {
                ErrorText.Text = "This sudoku can't be solved";
            }
        }

        private bool SolveGrid()
        {
            TextBox[] tbs = gridDrafter.GetInputs();

            for (int i = 0; i < 81; i++)
            {
                if (tbs[i] != null && tbs[i].Text.ToString().Length != 0)
                {
                    if (Solver.CheckNoConflict(grid, (int)(i / 9), (i % 9), Int32.Parse(tbs[i].Text.ToString())))
                    {
                        grid[i] = Int32.Parse(tbs[i].Text.ToString());
                    }
                    else
                    {
                        return false;
                    }

                }
            }

            myCanvas.Children.Clear();

            if (Solver.TrySolveSudoku(grid))
            {
                gridDrafter = new GridDrafter(grid);

                gridDrafter.CreateGridForSudoku(myCanvas);
                gridDrafter.AddInputsForUser(myCanvas, grid);
            }
            else
            {
                return false;
            }

            return true;
        }

        private void MakeEmptySudoku()
        {
            ErrorText.Text = "";
            GridMaker.AddRandomDigitsToGrid(ref grid, 0);
            gridDrafter = new GridDrafter(grid);
            gridDrafter.CreateGridForSudoku(myCanvas);
            gridDrafter.AddInputsForUser(myCanvas, grid);
        }

        private void NewEmptySudokuButton_Click(object sender, RoutedEventArgs e)
        {
            MakeEmptySudoku();
        }

        private void BackButtone_Click(object sender, RoutedEventArgs e)
        {
            StartPage startPage = new StartPage();
            NavigationService.Navigate(startPage);
        }
    }
}
