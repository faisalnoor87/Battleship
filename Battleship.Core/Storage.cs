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
