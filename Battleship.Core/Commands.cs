﻿using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Battleship.Core
{
    public class Commands
    {
        public class HitCommand
        {          
            public int X { get; set; }
            public int Y { get; set; }
        }

        public class SetupCommand
        {
            public string[] Ships { get; set; }

            public Ship[] CreateShips()
            {
                if (Ships == null || Ships.Length == 0)
                    throw new InvalidDataException("At least one ship need to setup");
                try
                {
                    return Ships.Select(e =>
                    {
                        var segments = e.Split(' ');
                        var name = segments[0];
                        var location = segments[1];
                        var length = segments[2];
                        var direction = segments[3].ToUpper();
                        if (new[] { "H", "V" }.All(x => x != direction))
                            throw new InvalidDataException("Invalid direction");

                        var points = location.Split(',');
                        return new Ship(name,
                            new Point(Convert.ToInt16(points[0]), Convert.ToInt16(points[1])),
                            Convert.ToInt16(length),
                            direction == "H" ? Ship.Direction.Horizontal : Ship.Direction.Vertical);
                    }).ToArray();
                }
                catch (Exception ex)
                {
                    throw new InvalidDataException(
                        "Please check the ships data, the format should be eg. 'shipnameH1 x,y 3 H'/'shipnameH2 x,y 5 V'",
                        ex);
                }

            }
        }
    }
}