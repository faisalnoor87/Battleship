namespace Battleship.ViewModel
{
    public class Status
    {
        public Status(string result, bool finished)
        {
            Result = result;
            Finished = finished;
        }
        public string Result { get; }
        public bool Finished { get; }
    }
}