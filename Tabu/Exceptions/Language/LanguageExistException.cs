using Tabu.ExternalServices.Abstracts;
using Tabu.Helpers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tabu.Exceptions.Language
{
    public class LanguageExistException : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status409Conflict;
        public string ErrorMessage { get; }
        public LanguageExistException()
        {
            ErrorMessage = "Language already added database";
        }

        public LanguageExistException(string message) : base(message)
        {
            ErrorMessage = message;
        }
        public LanguageExistException(IErrorService _service)
        {
            ErrorMessage = _service.GetMessage(ErrorCodes.Exist, _service.GetField("Language"));
        }
    }
}
