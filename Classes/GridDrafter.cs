﻿using System;
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

        public GridDrafter(int [] grid)
        {
            this.grid = grid;
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
                line.X1 = line.X2 = 250 + 30 * i;
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
                line.X1 = 250;
                line.X2 = 520;
                canvas.Children.Add(line);
            }
        }

        public void AddInputsForUser(Canvas canvas)
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
                            Margin = new Thickness(260 + 30 * i, top, 0, 0),
                            Width = 24,
                            Height = 24,
                            FontSize = 18,
                            FontWeight = FontWeights.Bold,
                            Text = grid[j * 9 + i].ToString()
                        };
                        canvas.Children.Add(digit);
                    }
                    else
                    {
                        TextBox input = new TextBox
                        {
                            Margin = new Thickness(253 + 30 * i, top, 0, 0),
                            Width = 24,
                            Height = 24,
                            FontSize = 18,
                            FontWeight = FontWeights.Bold,
                            HorizontalContentAlignment = HorizontalAlignment.Center,
                            VerticalContentAlignment = VerticalAlignment.Top
                        };
                        input.PreviewTextInput += PreviewTextInputHandler;
                        canvas.Children.Add(input);
                    }
                }
            }
        }

        private void PreviewTextInputHandler(Object sender, TextCompositionEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text.Length > 0)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = !IsTextAllowed(e.Text);
            }
        }

        private static bool IsTextAllowed(string text)
        {
            Regex _regex = new Regex("[0-9]");

            return _regex.IsMatch(text);
        }
    }
}