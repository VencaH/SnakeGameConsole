using System;
using SnakeGame.Data;

namespace SnakeGame.Views.Console
{
    class DrawFood : IDrawFood
    {
        private readonly ConsoleColor color;
        private Coordinates? OnScreenPostion;

        public DrawFood(ConsoleColor food_color)
        {
            color = food_color;
        }

        public void Draw(Coordinates coords)
        {
            if (this.OnScreenPostion != null)
            {
                if (coords.y != this.OnScreenPostion.y || coords.x != this.OnScreenPostion.x)
                {
                    // Console.SetCursorPosition(this.OnScreenPostion.x, this.OnScreenPostion.y);
                    // Console.Write(' ');
                    System.Console.SetCursorPosition(coords.x, coords.y);
                    System.Console.ForegroundColor = color;
                    System.Console.Write('■');
                    this.OnScreenPostion = coords;
                }
            }
            else
            {
                System.Console.SetCursorPosition(coords.x, coords.y);
                System.Console.ForegroundColor = color;
                System.Console.Write('■');
                this.OnScreenPostion = coords;
            }
        }
    }
}
