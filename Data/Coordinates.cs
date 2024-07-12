namespace SnakeGame.Data
{
    class Coordinates
    {
        public int x { get; set; }
        public int y { get; set; }

        public Coordinates(Coordinates origin)
        {
            x = origin.x;
            y = origin.y;
        }

        public Coordinates(int position_x, int position_y)
        {
            x = position_x;
            y = position_y;
        }

        public bool Compare(Coordinates target)
        {
            return this.x == target.x && this.y == target.y;
        }
        
        public bool IsIn(List<Coordinates> target)
        {
            foreach (Coordinates target_item in target)
            {
                if (target_item.x == x && target_item.y == y)
                    return true;
            }
            return false;
        }

    }
}
