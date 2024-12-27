namespace Tabu.ExternalServices.Abstracts
{
    public interface IErrorService
    {
        string GetMessage(string code);
        string GetMessage(string code, params object[] args);
        string GetField(string fieldName);
    }
}
