using System;
using System.Drawing;

namespace Battleship.Core
{
    public class Console
    {
        private Board _boards;
        private const int PlayerNumber = 1;

        public void Setup(Commands.SetupCommand setup)
        {
            _boards = new Board();
            _boards.Setup(setup);           
        }

        public Board.MissileStatus Hit(Commands.HitCommand hitCommand)
        {
            if (_boards == null)
                throw new InvalidOperationException("Console has not been setup yet");           
            return _boards.Hit(new Point(hitCommand.X, hitCommand.Y));
        }
    }
}
