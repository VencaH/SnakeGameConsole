using SnakeGame.Data;
using SnakeGame.Views.Console;
using SnakeGame.Enitities;

namespace SnakeGame
{
    class Program
    {
        private const int AppWidth = 32;
        private const int AppHeight = 16;
        private const int BoardWidth = 31;
        private const int BoardHeight = 15;
        private const int SnakeTic = 150;
        private const ConsoleColor BorderColor = ConsoleColor.Green;
        private const ConsoleColor FoodColor = ConsoleColor.Blue;
        private const ConsoleColor SnakeColor = ConsoleColor.White;
           static void Main(string[] args)
        {
            Random randomNumber = new();
            GameBoard gameBoard = new GameBoardBuilder()
                .SetWidth(BoardWidth)
                .SetHeight(BoardHeight)
                .SetView(new DrawBoard(BorderColor))
                .AddFood(new Food(new DrawFood(FoodColor)))
                .AddSnake(new Snake(new DrawSnake(SnakeColor), BoardWidth / 2, BoardHeight / 2))
                .Build();
            Game game = new GameBuilder()
                .SetWindowHeight(AppHeight)
                .SetWindowWidth(AppWidth)
                .SetSnakeTic(SnakeTic)
                .SetGameBoard(gameBoard)
                .SetInputReader(new InputReader())
                .SetView(new DrawGame(AppWidth, AppHeight))
                .Build();
            game.Draw();
            game.Run();
        }
    }        
}

