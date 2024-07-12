using SnakeGame.Views;

namespace SnakeGame.Enitities
{
    class GameBoardBuilder
    {
        private int boardWidth;
        private int boardHeight;
        private IDrawBoard? view;
        private Food? food;
        private Snake? snake;

        public GameBoardBuilder SetWidth(int width)
        {
            this.boardWidth = width;
            return this;
        }

        public GameBoardBuilder SetHeight(int height)
        {
            this.boardHeight = height;
            return this;
        }

        public GameBoardBuilder SetView(IDrawBoard drawer)
        {
            this.view = drawer;
            return this;
        }

        public GameBoardBuilder AddFood(Food food)
        {
            this.food = food;
            return this;
        }

        public GameBoardBuilder AddSnake(Snake snake)
        {
            this.snake = snake;
            return this;
        }

        public GameBoard Build()
        {
            if (this.view == null || this.food == null || this.snake == null) throw new Exception("Error: Incomplete Gameboard object");
            return new GameBoard(this.view, this.food, this.snake, this.boardWidth, this.boardHeight);
        }


    }
}
