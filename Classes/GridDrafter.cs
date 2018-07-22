using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SudokuSolver.Classes
{
    class GridDrafter
    {
        private int [] grid;
        private TextBox[] inputs;
        private TextBlock[] digits;

        public GridDrafter(int [] grid)
        {
            this.grid = grid;
            inputs = new TextBox[81];
            digits = new TextBlock[81];
        }

        public void CreateGridForSudoku(Canvas canvas)
        {
            for (int i = 0; i < 10; i++)
            {
                Line line = new Line();
                if (i % 3 == 0)
                {
                    line.Stroke = new SolidColorBrush(Colors.Black);
                }
                else
                {
                    line.Stroke = new SolidColorBrush(Colors.DarkGray);
                }
                line.StrokeThickness = 2;
                line.X1 = line.X2 = 270 + 30 * i;
                line.Y1 = 50;
                line.Y2 = 320;
                canvas.Children.Add(line);
            }

            for (int i = 0; i < 10; i++)
            {
                Line line = new Line();
                if (i % 3 == 0)
                {
                    line.Stroke = new SolidColorBrush(Colors.Black);
                }
                else
                {
                    line.Stroke = new SolidColorBrush(Colors.DarkGray);
                }
                line.StrokeThickness = 2;
                line.Y1 = line.Y2 = 50 + 30 * i;
                line.X1 = 270;
                line.X2 = 540;
                canvas.Children.Add(line);
            }
        }

        public void AddInputsForUser(Canvas canvas, int [] grid)
        {
            for (int j = 0; j < 9; j++)
            {
                int top = 53 + 30 * j;
                for (int i = 0; i < 9; i++)
                {
                    if (grid[j * 9 + i] != 0)
                    {
                        TextBlock digit = new TextBlock
                        {
                            Margin = new Thickness(280 + 30 * i, top, 0, 0),
                            Width = 24,
                            Height = 24,
                            FontSize = 18,
                            FontWeight = FontWeights.Bold,
                            Text = grid[j * 9 + i].ToString()
                        };
                        digits[j * 9 + i] = digit;
                        canvas.Children.Add(digit);
                    }
                    else
                    {
                        TextBox input = new TextBox
                        {
                            Margin = new Thickness(273 + 30 * i, top, 0, 0),
                            Width = 24,
                            Height = 24,
                            FontSize = 18,
                            FontWeight = FontWeights.Bold,
                            HorizontalContentAlignment = HorizontalAlignment.Center,
                            VerticalContentAlignment = VerticalAlignment.Top
                        };
                        input.PreviewTextInput += PreviewTextInputHandler;
                        inputs[j * 9 + i] = input;
                        canvas.Children.Add(input);
                    }
                }
            }
        }

        public TextBox[] GetInputs()
        {
            return inputs;
        }

        public TextBlock[] GetDigits()
        {
            return digits;
        }

        private void PreviewTextInputHandler(Object sender, TextCompositionEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text.Length > 0)
            {
                tb.Text = "";
                e.Handled = !IsTextAllowed(e.Text);
            }
            else
            {
                e.Handled = !IsTextAllowed(e.Text);
            }

        }

        private static bool IsTextAllowed(string text)
        {
            Regex _regex = new Regex("[1-9]");

            return _regex.IsMatch(text);
        }
    }
}
