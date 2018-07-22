using NUnit.Framework;
using SudokuSolver.Classes;

namespace SudokuSolver.Tests
{
    [TestFixture]
    class SolverTests
    {
        [Test]
        public void TrySolveSudoku_ValidGrid_ReturnsTrue()
        {
            int[] grid = {3, 0, 6, 5, 0, 8, 4, 0, 0,
                           5, 2, 0, 0, 0, 0, 0, 0, 0,
                           0, 8, 7, 0, 0, 0, 0, 3, 1,
                           0, 0, 3, 0, 1, 0, 0, 8, 0,
                           9, 0, 0, 8, 6, 3, 0, 0, 5,
                           0, 5, 0, 0, 9, 0, 6, 0, 0,
                           1, 3, 0, 0, 0, 0, 2, 5, 0,
                           0, 0, 0, 0, 0, 0, 0, 7, 4,
                           0, 0, 5, 2, 0, 6, 3, 0, 0};

            bool result = Solver.TrySolveSudoku(grid);

            Assert.IsTrue(result);
        }

        [Test]
        public void TrySolveSudoku_InvalidGrid_ReturnsFalse()
        {
            int[] grid = {3, 0, 6, 5, 0, 8, 4, 0, 0,
                           3, 2, 0, 0, 0, 0, 0, 0, 0,
                           0, 8, 7, 0, 0, 0, 0, 3, 1,
                           0, 0, 3, 0, 1, 0, 0, 8, 0,
                           9, 0, 0, 8, 6, 3, 0, 0, 5,
                           0, 5, 0, 0, 9, 0, 6, 0, 0,
                           1, 3, 0, 0, 0, 0, 2, 5, 0,
                           0, 0, 0, 0, 0, 0, 0, 7, 4,
                           0, 0, 5, 2, 0, 6, 3, 0, 0};

            bool result = Solver.TrySolveSudoku(grid);

            Assert.IsFalse(result);
        }

        [Test]
        public void TrySolveSudoku_EmptyGrid_ReturnsTrue()
        {
            int[] grid = new int[81];

            bool result = Solver.TrySolveSudoku(grid);

            Assert.IsTrue(result);
        }

        [TestCase(0, 1, 1)]
        [TestCase(0, 4, 2)]
        public void CheckNoConflict_ValidDigitOnThisPosition_ReturnsTrue(int row, int column, int digit)
        {
            int[] grid = {3, 0, 6, 5, 0, 8, 4, 0, 0,
                           5, 2, 0, 0, 0, 0, 0, 0, 0,
                           0, 8, 7, 0, 0, 0, 0, 3, 1,
                           0, 0, 3, 0, 1, 0, 0, 8, 0,
                           9, 0, 0, 8, 6, 3, 0, 0, 5,
                           0, 5, 0, 0, 9, 0, 6, 0, 0,
                           1, 3, 0, 0, 0, 0, 2, 5, 0,
                           0, 0, 0, 0, 0, 0, 0, 7, 4,
                           0, 0, 5, 2, 0, 6, 3, 0, 0};

            bool result = Solver.CheckNoConflict(grid, row, column, digit);

            Assert.IsTrue(result);
        }

        [TestCase(0, 1, 3)]
        [TestCase(0, 0, 1)]
        public void CheckNoConflict_InvalidDigitOnThisPosition_ReturnsFalse(int row, int column, int digit)
        {
            int[] grid = {3, 0, 6, 5, 0, 8, 4, 0, 0,
                           5, 2, 0, 0, 0, 0, 0, 0, 0,
                           0, 8, 7, 0, 0, 0, 0, 3, 1,
                           0, 0, 3, 0, 1, 0, 0, 8, 0,
                           9, 0, 0, 8, 6, 3, 0, 0, 5,
                           0, 5, 0, 0, 9, 0, 6, 0, 0,
                           1, 3, 0, 0, 0, 0, 2, 5, 0,
                           0, 0, 0, 0, 0, 0, 0, 7, 4,
                           0, 0, 5, 2, 0, 6, 3, 0, 0};

            bool result = Solver.CheckNoConflict(grid, row, column, digit);

            Assert.IsFalse(result);
        }
    }
}
