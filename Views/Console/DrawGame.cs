using System;

namespace SnakeGame.Views.Console
{
    class DrawGame : IDrawGame
    {
        private readonly int windowWidth;
        private readonly int windowHeight;
        public DrawGame(int windowWidth, int windowHeight)
        {
            this.windowHeight = windowHeight;
            this.windowWidth = windowWidth;

        }

        public void Draw()
        {
            System.Console.WindowHeight = windowHeight;
            System.Console.WindowWidth = windowWidth;
            System.Console.CursorVisible = false;
        }

        public void DrawEndScreen(int score)
        {
            System.Console.SetCursorPosition(windowWidth / 5, windowHeight / 2);
            System.Console.WriteLine("Game over, Score: " + score);
            System.Console.SetCursorPosition(windowWidth / 5, windowHeight / 2 + 1);
            System.Console.ReadKey();
        }
    }
}
