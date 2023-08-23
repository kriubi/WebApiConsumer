namespace WebApiConsumer.Contracts;

public interface IDummyJsonService
{
    Task<LoginResponse?> Login(string username, string password);
    Task<GetUserResponse?> GetUser(int id);
}
