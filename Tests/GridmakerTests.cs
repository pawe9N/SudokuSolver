using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SudokuSolver.Classes;

namespace SudokuSolver.Tests
{
    [TestFixture]
    class GridMakerTests
    {
        [TestCase(0)]
        [TestCase(10)]
        [TestCase(81)]
        public void AddRandomDigitsToGrid_WhenCalled_PutRandomDigitsToGrid(int numberOfDigits)
        {
            int[] grid = new int[81];

            GridMaker.AddRandomDigitsToGrid(ref grid, numberOfDigits);
            int result = grid.Count(g => g != 0);

            Assert.AreEqual(numberOfDigits, result);
        }

        [TestCase(82)]
        public void AddRandomDigitsToGrid_TooManyNumbers_Throws(int numberOfDigits)
        {
            int[] grid = new int[81];

            var ex = Assert.Throws<Exception>(() => GridMaker.AddRandomDigitsToGrid(ref grid, numberOfDigits));

            StringAssert.Contains("too many", ex.Message);
        }

        [TestCase(-1)]
        public void AddRandomDigitsToGrid_TooFewNumbers_Throws(int numberOfDigits)
        {
            int[] grid = new int[81];

            var ex = Assert.Throws<Exception>(() => GridMaker.AddRandomDigitsToGrid(ref grid, numberOfDigits));

            StringAssert.Contains("too few", ex.Message);
        }
    }
}
