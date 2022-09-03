namespace Backend.App.Interface
{
    public interface IJwtAuthenticationService
    {
        string Authenticate(string username, string password);
    }
}
