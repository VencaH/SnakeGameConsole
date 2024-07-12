using SnakeGame.Data;

namespace SnakeGame.Views
{
    interface IDrawGame
    {
        public void Draw();
        public void DrawEndScreen(int score);
    }
}
