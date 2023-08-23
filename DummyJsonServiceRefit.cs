using Refit;

namespace WebApiConsumer;

public interface IDummyJsonServiceRefit
{
    [Get("/users/{id}")]
    Task<GetUserResponse?> GetUser(int id);
}
