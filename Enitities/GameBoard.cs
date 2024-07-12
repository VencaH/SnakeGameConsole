using SnakeGame.Data;
using SnakeGame.Views;

namespace SnakeGame.Enitities
{
    class GameBoard
    {
        private List<List<Coordinates>> position;
        private readonly int arenaWidth;
        private readonly int arenaHeight;
        private readonly Random randomNumber;
        private readonly Food food;
        private readonly Snake snake;
        private readonly IDrawBoard view;
        public GameBoard(IDrawBoard drawer, Food food, Snake snake, int gameBoardWidth, int gameBoardHeight)
        {
            position = new List<List<Coordinates>>();
            // 0 = top, 1 = left. 2 = right, 3 = bottom
            for (int i = 0; i < 4; i++)
            {
                position.Add(new List<Coordinates>());
            }
            //top & bottom
            for (int i = 1; i < gameBoardWidth; i++)
            {
                position[0].Add(new Coordinates(i, 0));
                position[3].Add(new Coordinates(i, gameBoardHeight));
            }

            //left & right
            for (int i = 0; i <= gameBoardHeight; i++)
            {
                position[1].Add(new Coordinates(0, i));
                position[2].Add(new Coordinates(gameBoardWidth, i));
            }
            this.arenaWidth = gameBoardWidth - 2;
            this.arenaHeight = gameBoardHeight - 2;
            this.view = drawer;
            this.food = food;
            this.snake = snake;
            this.randomNumber = new Random();
        }

        public void PlaceFood()
        {
            //avoid placing food inside snake
            Coordinates foodCoordinates = new Coordinates(randomNumber.Next(1, arenaWidth), randomNumber.Next(1, arenaHeight));
            List<Coordinates> snakeCoordinates = new List<Coordinates>();
            foreach (SnakeSegment segment in this.snake.body)
                {
                snakeCoordinates.Add(segment.Coordinates);
                }
            while (foodCoordinates.IsIn(snakeCoordinates))
            {
                foodCoordinates = new Coordinates(randomNumber.Next(1, arenaWidth), randomNumber.Next(1, arenaHeight));
            }
            this.food.Place(foodCoordinates);
        }

        public void SnakeEat()
        {
            this.snake.Eat();
        }

        public void SetSnakeDirection(Directions direction)
        {
            snake.SetDirection(direction);
        }

        public void SnakeMove()
        {
            this.snake.Move();
        }

        public void Draw()
        {
            view.Draw(position);
            snake.Draw();
            this.PlaceFood();
        }

        public Collisions CheckCollisions()
        {
            if (snake.CheckSelfCollision())
            {
                return Collisions.SnakeSelf;
            }

            Coordinates head = snake.GetHead().Coordinates;
            if (head.x == arenaWidth + 2 || head.x == 0 || head.y == arenaHeight + 2 || head.y == 0)
            {
                return Collisions.Border;
            }

            if (food.position != null && food.position.Compare(head))
            {
                return Collisions.Food;
            }

            return Collisions.None;
        }

        public Coordinates getSnakeHead()
        {
            return this.snake.GetHead().Coordinates;
        }
    }
}
