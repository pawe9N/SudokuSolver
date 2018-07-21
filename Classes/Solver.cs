namespace SudokuSolver.Classes
{
    class Solver
    {
        private static readonly int dimension = 9;

        public static bool TrySolveSudoku(int [] grid)
        {
            int column;
            int row = column = 0;

            if (!FindEmptyPosition(grid, ref row, ref column))
            {
                return true;
            }

            for (int digit = 1; digit <= 9; digit++)
            {
                if (CheckNoConflict(grid, row, column, digit))
                {
                    grid[row * dimension + column] = digit;

                    if (TrySolveSudoku(grid))
                    {
                        return true;
                    }

                    grid[row * dimension + column] = 0;
                }
            }
            return false;
        }

        private static bool FindEmptyPosition(int [] grid, ref int row, ref int column)
        {
            for (row = 0; row < dimension; row++)
            {
                for (column = 0; column < dimension; column++)
                {
                    if (grid[row * dimension + column] == 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool CheckConflictInRow(int [] grid, int row, int digit)
        {
            for (int column = 0; column < dimension; column++)
            {
                if (grid[row * dimension + column] == digit)
                {
                    return true;
                }
            }      
            
            return false;
        }

        private static bool CheckConflictInColumn(int [] grid, int column, int digit)
        {
            for (int row = 0; row < dimension; row++)
            {
                if (grid[row * dimension + column] == digit)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool CheckConflictInInset(int [] grid, int insetRowPosition, int insetColumnPosition, int digit)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    if (grid[(row + insetRowPosition) * dimension + column + insetColumnPosition] == digit)
                    {
                        return true;
                    }
                }
            }             
                    
            return false;
        }

        public static bool CheckNoConflict(int [] grid, int row, int column, int digit)
        {
            return !CheckConflictInRow(grid, row, digit) &&
                   !CheckConflictInColumn(grid, column, digit) &&
                   !CheckConflictInInset(grid, row - row % 3, column - column % 3, digit);
        }


    }
}
