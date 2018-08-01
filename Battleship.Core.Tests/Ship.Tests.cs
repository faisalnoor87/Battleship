using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace Battleship.Core.Tests
{
    [TestClass]
    public class ShipTests
    {
        [TestMethod]
        public void GivenValidParamsWhenCallConstructorThenShouldCreateInstance()
        {
            var ship = new Ship("s1", new Point(2, 1), 3, Ship.Direction.Horizontal);
            Assert.AreEqual("s1", ship.Name);
            Assert.AreEqual(3, ship.Squares.Length);
            Assert.AreEqual(3, ship.Squares[2].Point.Y);
            Assert.AreEqual(2, ship.Squares[2].Point.X);
        }

        [TestMethod]
        public void GivenValidPointWhenCallHitThenShouldReturnHit()
        {
            var ship = new Ship("s1", new Point(2, 1), 3, Ship.Direction.Horizontal);
            var result = ship.Hit(new Point(2, 3));
            Assert.AreEqual(HitResult.Hit, result);
        }

        [TestMethod]
        public void GivenValidLastPointWhenCallHitThenShouldReturnSink()
        {
            var ship = new Ship("s1", new Point(2, 1), 3, Ship.Direction.Horizontal);
            ship.Hit(new Point(2, 1));
            ship.Hit(new Point(2, 2));
            var result = ship.Hit(new Point(2, 3));
            Assert.AreEqual(HitResult.Sink, result);
        }
    }
}
