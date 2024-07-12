using System;
using SnakeGame.Data;

namespace SnakeGame.Views.Console
{
    class DrawBoard : IDrawBoard
    {
        private readonly ConsoleColor color;

        public DrawBoard(ConsoleColor boardColor)
        {
            color = boardColor;
        }

        public void Draw(List<List<Coordinates>> borders)
        {
            //top and bottom
            for (int i = 0; i < Math.Min(borders[0].Count, borders[3].Count); i++)
            {
                System.Console.ForegroundColor = color;
                System.Console.SetCursorPosition(borders[0][i].x, borders[0][i].y);
                System.Console.Write('■');
                System.Console.SetCursorPosition(borders[3][i].x, borders[3][i].y);
                System.Console.Write('■');
            }

            // left and right
            for (int i = 0; i < Math.Min(borders[1].Count, borders[2].Count); i++)
            {
                System.Console.ForegroundColor = color;
                System.Console.SetCursorPosition(borders[1][i].x, borders[1][i].y);
                System.Console.Write('■');
                System.Console.SetCursorPosition(borders[2][i].x, borders[2][i].y);
                System.Console.Write('■');
            }
        }
    }
}
