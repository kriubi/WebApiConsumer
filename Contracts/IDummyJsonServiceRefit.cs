using Refit;

namespace WebApiConsumer.Contracts;

public interface IDummyJsonServiceRefit
{
    [Get("/users/{id}")]
    Task<GetUserResponse?> GetUser(int id);
}
