using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Battleship.Core
{
    public class Console
    {
        private IList<Board> _boards;
        private const int PlayerNumber = 2;

        public void Setup(Commands.SetupCommand setup)
        {
            if (_boards == null || _boards.Count == PlayerNumber) _boards = new List<Board>();
            var board = new Board();
            board.Setup(setup);
            _boards.Add(board);
        }

        public Board.MissileStatus Hit(Commands.HitCommand hitCommand)
        {
            if (_boards == null || _boards.Count != PlayerNumber)
                throw new InvalidOperationException("Console has not been setup yet");
            if (_boards.All(e => e.PalyerName != hitCommand.PlayerName)) throw new InvalidDataException("Uknown player");
            var board = _boards.Single(e => e.PalyerName != hitCommand.PlayerName);
            return board.Hit(new Point(hitCommand.X, hitCommand.Y));
        }
    }
}
