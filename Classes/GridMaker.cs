using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Classes
{
    class GridMaker
    {
        public static void AddRandomDigitAtBeginning(ref int [] grid, int howManyRandomDigits)
        {
            int[] tempGrid;
            do
            {
                tempGrid = new int[81];
                for (int i = 0; i < 10; i++)
                {
                    Random rand = new Random();
                    int digit, position;
                    do
                    {
                        position = rand.Next(0, 81);
                    } while (tempGrid[position] != 0);

                    bool NoConflictDigitPosition = false;
                    do
                    {
                        digit = rand.Next(1, 10);
                        if (Solver.CheckNoConflict(tempGrid, (int)(position / 9), (position % 9), digit))
                        {
                            NoConflictDigitPosition = true;
                        }
                    } while (!NoConflictDigitPosition);

                    tempGrid[position] = digit;
                }
            } while (!Solver.TrySolveSudoku(tempGrid));

            grid = new int[81];
            for (int i = 0; i < howManyRandomDigits; i++)
            {
                Random rand = new Random();
                int position;
                do
                {
                    position = rand.Next(0, 81);
                } while (grid[position] != 0);
                grid[position] = tempGrid[position];
            }
        }
    }
}
