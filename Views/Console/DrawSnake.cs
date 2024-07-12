using System;
using SnakeGame.Data;

namespace SnakeGame.Views.Console
{
    class DrawSnake : IDrawSnake
    {

        private readonly ConsoleColor color;
        private List<Coordinates> OnScreenPosition { get; set; }

        public DrawSnake(ConsoleColor snake_color)
        {
            this.color = snake_color;
            this.OnScreenPosition = new List<Coordinates>();
        }

        public void Draw(List<SnakeSegment> body)
        {
            for (int i = 0; i < body.Count; i++)
            {
                bool exists = false;
                for (int j = 0; j < this.OnScreenPosition.Count; j++)
                {
                    if (this.OnScreenPosition[j].Compare(body[i].Coordinates))
                    {
                        exists = true;
                        break;
                    }
                }
                if (!exists)
                {
                    System.Console.SetCursorPosition(body[i].Coordinates.x, body[i].Coordinates.y);
                    System.Console.ForegroundColor = color;
                    System.Console.Write('■');
                }
            }
            for (int i = 0; i < this.OnScreenPosition.Count; i++)
            {
                bool exist = false;
                for (int j = 0; j < body.Count; j++)
                {
                    if (body[j].Coordinates.Compare(this.OnScreenPosition[i]))
                    {
                        exist = true;
                        break;
                    }

                }

                if (!exist)
                {
                    System.Console.SetCursorPosition(this.OnScreenPosition[i].x, this.OnScreenPosition[i].y);
                    System.Console.Write(' ');
                }
            }
            this.OnScreenPosition.Clear();
            for (int i = 0; i < body.Count; i++)
            {
                this.OnScreenPosition.Add(new Coordinates(body[i].Coordinates));
            }
        }


    }
}
