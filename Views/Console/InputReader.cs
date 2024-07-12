using System;
using System.Collections;
using SnakeGame.Data;


namespace SnakeGame.Views.Console
{
    class InputReader : IInputReader
    {
        private readonly Queue inputQueue;

        public InputReader()
        {
            inputQueue = new Queue();
        }

        public void UpdateInput()
        {
            while (System.Console.KeyAvailable)
            {
                // max of 2 last inputs are saved in the input buffer to avoid confusing behaviour
                while (this.inputQueue.Count > 2)
                {
                    this.inputQueue.Dequeue();
                }

                switch (System.Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        this.inputQueue.Enqueue(Directions.Up);
                        break;
                    case ConsoleKey.DownArrow:
                        this.inputQueue.Enqueue(Directions.Down);
                        break;
                    case ConsoleKey.LeftArrow:
                        this.inputQueue.Enqueue(Directions.Left);
                        break;
                    case ConsoleKey.RightArrow:
                        this.inputQueue.Enqueue(Directions.Right);
                        break;
                }
            }
        }
        public Directions? GetInput()
        {
            if (this.inputQueue.Count == 0) return null;
            return (Directions?)this.inputQueue.Dequeue();
        }
    }
}
