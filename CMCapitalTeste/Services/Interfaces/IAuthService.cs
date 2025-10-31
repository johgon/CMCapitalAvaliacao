namespace CMCapitalAvaliacao.Services.Interfaces
{
    public interface IAuthService
    {
        string Login(string username, string password);
        void Register(string username, string password, string role = "User");
    }
}
