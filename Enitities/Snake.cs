using SnakeGame.Views;
using SnakeGame.Data;

namespace SnakeGame.Enitities
{
    class Snake
    {
        public List<SnakeSegment> body { get; set; }
        public int Size { get; set; }
        private readonly IDrawSnake view;
        private Directions? direction;
        public Snake(IDrawSnake drawer, int x, int y)
        {
            this.view = drawer;
            this.Size = 1;
            this.direction = Directions.Right;
            this.body = new List<SnakeSegment>
                {
                    new SnakeSegment(x, y, Directions.Right)
                };

        }

        public bool CheckSelfCollision()
        {
            for (int i = 1; i < body.Count; i++)
            {
                if (body[i].Coordinates.x == body[0].Coordinates.x && body[i].Coordinates.y == body[0].Coordinates.y)
                {
                    return true;
                }
            }
            return false;
        }

        public SnakeSegment GetHead()
        {
            return this.body[0];
        }

        public void Draw()
        {
            view.Draw(this.body);
        }

        public void Eat()
        {

            switch (this.body[Size -1].Direction)
            {
                case Directions.Right:
                    this.body.Add(new SnakeSegment(
                        this.body[this.Size - 1].Coordinates.x - 1,
                        this.body[this.Size - 1].Coordinates.y,
                        Directions.Right
                        ));
                    break;
                case Directions.Left:
                    this.body.Add(new SnakeSegment(
                        this.body[this.Size - 1].Coordinates.x + 1,
                        this.body[this.Size - 1].Coordinates.y,
                        Directions.Left
                        ));
                    break;
                case Directions.Up:
                    this.body.Add(new SnakeSegment(
                        this.body[this.Size - 1].Coordinates.x,
                        this.body[this.Size - 1].Coordinates.y + 1,
                        Directions.Up
                        ));
                    break;
                case Directions.Down:
                    this.body.Add(new SnakeSegment(
                        this.body[this.Size - 1].Coordinates.x,
                        this.body[this.Size - 1].Coordinates.y - 1,
                        Directions.Down
                        ));
                    break;
            }
            Size++;
            this.Draw();

        }

        public void SetDirection(Directions directions)
        {
            if (!this.direction.HasValue)
            {
                this.direction = directions;
                return;
            }
            switch (directions)
            {
                case Directions.Up:
                    if (this.direction != Directions.Down) this.direction = directions;
                    break;
                case Directions.Down:
                    if (this.direction != Directions.Up) this.direction = directions;
                    break;
                case Directions.Right:
                    if (this.direction != Directions.Left) this.direction = directions;
                    break;
                case Directions.Left:
                    if (this.direction != Directions.Right) this.direction = directions;
                    break;
            }
        }

        public void Move()
        {
            int x = 0;
            int y = 0;
            switch (this.direction)
            {
                case Directions.Left:
                    x = -1;
                    y = 0;
                    break;
                case Directions.Right:
                    x = 1;
                    y = 0;
                    break;
                case Directions.Down:
                    x = 0;
                    y = 1;
                    break;
                case Directions.Up:
                    x = 0;
                    y = -1;
                    break;
            }
            for (int i = this.Size - 1; i > 0; i--)
            {
                this.body[i] = new SnakeSegment(this.body[i - 1].Coordinates.x,this.body[i-1].Coordinates.y, this.body[i-1].Direction);
            }
            this.body[0].Coordinates.x += x;
            this.body[0].Coordinates.y += y;
            if (this.direction != null) this.body[0].Direction = (Directions)this.direction;
            this.Draw();
        }
    }
}
