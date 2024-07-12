using SnakeGame.Data;

namespace SnakeGame.Views
{
    interface IDrawSnake
    {
        public void Draw(List<SnakeSegment> position);
    }
}
