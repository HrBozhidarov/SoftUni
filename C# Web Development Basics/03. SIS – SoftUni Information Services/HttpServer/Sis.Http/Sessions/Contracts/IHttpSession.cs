namespace Sis.Http.Sessions.Contracts
{
    public interface IHttpSession
    {
        string Id { get; }

        object GetParameter(string key);

        bool ContainsParameter(string key);

        void AddParameter(string key, object parameter);

        void ClearParameters();
    }
}
