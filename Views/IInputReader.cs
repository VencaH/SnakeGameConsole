using System.Collections;
using SnakeGame.Data;

namespace SnakeGame.Views
{
    interface IInputReader
    {
        public void UpdateInput();
        public Directions? GetInput();
    }
}
