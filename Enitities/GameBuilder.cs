using SnakeGame.Views;

namespace SnakeGame.Enitities
{
    class GameBuilder
    {
        private int windowWidth;
        private int windowHeight;
        private int snakeTick;
        private IDrawGame? view;
        private GameBoard? board;
        private IInputReader? inputReader;

        public GameBuilder SetWindowWidth(int width)
        {
            this.windowWidth = width;
            return this;
        }

        public GameBuilder SetWindowHeight(int height)
        {
            this.windowHeight = height;
            return this;
        }

        public GameBuilder SetSnakeTic(int tick)
        {
            snakeTick = tick;
            return this;
        }

        public GameBuilder SetView(IDrawGame drawer)
        {
            this.view = drawer;
            return this;
        }

        public GameBuilder SetGameBoard(GameBoard board)
        {
            this.board = board;
            return this;
        }

        public GameBuilder SetInputReader(IInputReader inputReader)
        {
            this.inputReader = inputReader;
            return this;
        }

        public Game Build()
        {
            if (this.view == null || this.board == null || this.inputReader == null) throw new Exception("Error: Incomplete Game object");
            return new Game(this.windowWidth, this.windowHeight, this.snakeTick, this.view, this.board, this.inputReader);
        }
    }
}
