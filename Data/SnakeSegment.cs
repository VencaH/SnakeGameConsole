using SnakeGame.Data;

namespace SnakeGame.Data
{
    class SnakeSegment
    {
        public Coordinates Coordinates { get; set; }
        public Directions Direction { get; set; }

        public SnakeSegment(int x, int y, Directions directions)
        {
            this.Coordinates = new Coordinates(x,y);
            this.Direction = directions;
        }
    }
}
