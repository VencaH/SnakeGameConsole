using SnakeGame.Data;
namespace SnakeGame.Views
{
    interface IDrawBoard
    {
        public void Draw(List<List<Coordinates>>  borders);
    }
}
