using System.Drawing;
using System.Linq;

namespace Battleship.Core
{
    public class Ship
    {
        public Ship(string name, Point point, int length, Direction direction)
        {
            Name = name;
            Squares = Enumerable.Range(direction == Direction.Right ? point.Y : point.X, length)
                .Select(e => direction == Direction.Right ? new Point(point.X, e) : new Point(e, point.Y))
                .Select(p => new Square(p, HitResult.None)).ToArray();
        }

        public string Name { get; }
        public Square[] Squares { get; }
        public bool Sinked { get; private set; }

        public HitResult Hit(Point point)
        {
            if (Sinked) return HitResult.Sink;
            var square = Squares.SingleOrDefault(e => e.Point.X == point.X && e.Point.Y == point.Y);
            if (square == null) return HitResult.Miss;

            square.Result = HitResult.Hit;
            if (Squares.Any(e => e.Result != HitResult.Hit)) return HitResult.Hit;
            Sinked = true;
            return square.Result = HitResult.Sink;
        }

        public class Square
        {
            public Square(Point poit, HitResult result)
            {
                Point = poit;
                Result = result;
            }

            public Point Point { get; set; }
            public HitResult Result { get; set; }
        }

        public enum Direction
        {
            Right,
            Bottom
        }

    }
}
