using SudokuSolver.Classes;
using System;
using System.Windows;
using System.Windows.Controls;

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
    }
}
