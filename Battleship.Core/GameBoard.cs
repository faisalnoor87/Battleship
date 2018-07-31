using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Battleship.Core
{
    public class GameBoard
    {
        private const int Dimension = 10;
        private Square[,] _squares;
        private Ship[] _ships;

        public void Setup(Commands.SetupCommand setupa)
        {
            
            PalyerName = setupa.PlayerName;
            _squares = new Square[Dimension, Dimension];
            _ships = setupa.CreateShips();
            Parallel.ForEach(_ships, ship =>
            {
                Array.ForEach(ship.Squares, shipSquare =>
                {
                    if (!CheckPoint(shipSquare.Point))
                        throw new InvalidDataException($"Ship '{ship.Name}' can't fit within board");
                    var existing = _squares[shipSquare.Point.X, shipSquare.Point.Y];
                    if (existing?.ShipIndex != null)
                        throw new InvalidDataException(
                            $"Ship '{ship.Name}' overlapping with ship '{_ships[existing.ShipIndex.Value].Name}'");
                    _squares[shipSquare.Point.X, shipSquare.Point.Y]
                        = new Square { Result = shipSquare.Result, ShipIndex = Array.IndexOf(_ships, ship) };
                });
            });
        }

        public string PalyerName { get; set; }

        private static bool CheckPoint(Point point)
        {
            return point.X >= 0 && point.X < Dimension && point.Y >= 0 && point.Y < Dimension;
        }

        public MissileStatus Hit(Point point)
        {
            if(!CheckPoint(point)) throw new InvalidDataException("Location out of scope");
            if (Finished) throw new InvalidOperationException("Game already finished");
            TotalHit += 1;
            var square = _squares[point.X, point.Y];
            if (square?.ShipIndex == null) square = _squares[point.X, point.Y] = new Square {Result = HitResult.Miss};
            else square.Result = _ships[square.ShipIndex.Value].Hit(point);
            Finished = _ships.All(e => e.Sinked);
            return new MissileStatus
            {
                Result = square.Result,
                Finished = Finished
            };
        }

        public bool Finished { get;private set; }

        public int TotalHit { get; private set; }

        public class MissileStatus
        {
            public HitResult Result { get; set; }
            public bool Finished { get; set; }
        }

        public class Square
        {
            public HitResult Result { get; set; }
            public int? ShipIndex { get; set; }
        }

    }
}
