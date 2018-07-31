using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Core
{
    public static class Storage
    {
        public static Console Console { get; set; }
        static Storage()
        {
            Console = new Console();
        }
    }
}
