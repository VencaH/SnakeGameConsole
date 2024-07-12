using SnakeGame.Data;
using SnakeGame.Views;

namespace SnakeGame.Enitities
{
    class Game
    {
        private int score;
        private readonly GameBoard board;
        private readonly int screenWidth;
        private readonly int screenHeight;
        private readonly int snakeTick;
        private readonly IDrawGame view;
        private GameState state;
        private readonly IInputReader inputReader;
        private DateTime lastSnakeTic;

        public Game(int width, int height, int snakeTick, IDrawGame view, GameBoard board, IInputReader inputReader)
        {
            this.screenWidth = width;
            this.screenHeight = height;
            this.snakeTick = snakeTick;
            this.view = view;
            this.board = board;
            this.inputReader = inputReader;
            this.score = 0;
            this.state = GameState.Ready;

        }
        private bool CheckSnakeTic()
        {
            DateTime now = DateTime.Now;
            if (now.Subtract(this.lastSnakeTic).TotalMilliseconds > this.snakeTick)
            {
                this.lastSnakeTic = now;
                return true;
            }
            return false;
        }
        private void ResolveCollision()
        {
            switch (this.board.CheckCollisions())
            {
                case Collisions.SnakeSelf:
                    this.state = GameState.Gameover;
                    break;
                case Collisions.Border:
                    this.state = GameState.Gameover;
                    break;
                case Collisions.Food:
                    this.score++;
                    this.board.PlaceFood();
                    this.board.SnakeEat();
                    break;
                case Collisions.None:
                    break;
            }
        }
        private void EndGame()
        {
            this.view.DrawEndScreen(this.score);
        }
        public void Draw()
        {
            this.view.Draw();
            board.Draw();

        }
        public void Run()
        {
            while (true)
            {
                if (state == GameState.Ready)
                {
                    board.SetSnakeDirection(Directions.Right);
                    this.state = GameState.Start;
                }
                if (state == GameState.Start)
                {
                    inputReader.UpdateInput();
                    if (this.CheckSnakeTic())
                    {
                        Directions? newDirection = inputReader.GetInput();
                        if (newDirection.HasValue)
                        {
                            board.SetSnakeDirection(newDirection.Value);
                        }
                        board.SnakeMove();
                        this.ResolveCollision();
                    }
                }
                if (state == GameState.Gameover)
                {
                    this.EndGame();
                    break;
                }
            }
        }
    }

}

