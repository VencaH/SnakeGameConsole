using SnakeGame.Data;
using SnakeGame.Views;

namespace SnakeGame.Enitities
{
    class Food
    {
        public Coordinates? position { get; set; }
        private readonly IDrawFood view;

        public Food(IDrawFood drawer)
        {
            view = drawer;
        }

        public void Place(Coordinates position)
        {
            this.position = new Coordinates(position);
            this.Draw();
        }

        private void Draw()
        {
            if (this.position == null) return;
            view.Draw(this.position);
        }
    }
}
