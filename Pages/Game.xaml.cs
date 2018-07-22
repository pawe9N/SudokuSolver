using SudokuSolver.Classes;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SudokuSolver.Pages
{
    public partial class Game : Page
    {
        private int[] grid;
        GridDrafter gd;

        public Game()
        {
            InitializeComponent();

            GridMaker.AddRandomDigitAtBeginning(ref grid, 30);
            gd = new GridDrafter(grid);

            gd.CreateGridForSudoku(myCanvas); 
            gd.AddInputsForUser(myCanvas);
        }   

        private void SolveButton_Click(object sender, RoutedEventArgs e)
        {
            myCanvas.Children.Clear();
            Solver.TrySolveSudoku(grid);

            gd = new GridDrafter(grid);

            gd.CreateGridForSudoku(myCanvas);
            gd.AddInputsForUser(myCanvas);
        }

        private void CheckInputs_Click(object sender, RoutedEventArgs e)
        {
            int[] solved = new int[81];
            Array.Copy(grid, solved, 81);

            Solver.TrySolveSudoku(solved);

            myCanvas.Children.Clear();

            TextBox [] tbs = gd.getInputs();

            for(int i=0; i<81; i++)
            {
                if(tbs[i] != null && tbs[i].Text.ToString().Length != 0)
                {
                    grid[i] = Int32.Parse(tbs[i].Text.ToString());
                }
            }

            gd.CreateGridForSudoku(myCanvas);
            gd.AddInputsForUser(myCanvas);

            TextBlock [] tbks = gd.getDigits();

            for(int i=0; i<81; i++)
            {
                if(tbks[i] != null && tbs[i] != null)
                {
                    if (solved[i] != grid[i])
                    {
                        tbks[i].Foreground = new SolidColorBrush(Colors.Red);
                    }
                    else
                    {
                        tbks[i].Foreground = new SolidColorBrush(Colors.Green);
                    }
                }
            }

        }
    }
}
