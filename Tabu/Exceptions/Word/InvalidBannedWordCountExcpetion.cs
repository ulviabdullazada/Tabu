namespace Tabu.Exceptions.Word
{
    public class InvalidBannedWordCountExcpetion : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status400BadRequest;

        public string ErrorMessage { get; }
        public InvalidBannedWordCountExcpetion()
        {
            ErrorMessage = "Banned word count must be equal to 8";
        }

        public InvalidBannedWordCountExcpetion(string message) : base(message)
        {
            ErrorMessage = message;
        }
    }
}
