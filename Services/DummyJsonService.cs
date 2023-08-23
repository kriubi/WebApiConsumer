using System.Text.Json;
using WebApiConsumer.Contracts;

namespace WebApiConsumer.Services;

public sealed class DummyJsonService : IDummyJsonService
{
    private readonly HttpClient _httpClient;

    public DummyJsonService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GetUserResponse?> GetUser(int id)
    {
        var response = await _httpClient.GetFromJsonAsync<GetUserResponse>($"users/{id}");
        return response ?? null;
    }

    public async Task<LoginResponse?> Login(string username, string password)
    {
        var response = await _httpClient.PostAsJsonAsync("auth/login", new
        {
            username,
            password
        });

        response.EnsureSuccessStatusCode();

        using var responseStream = await response.Content.ReadAsStreamAsync();

        var result = await JsonSerializer.DeserializeAsync<LoginResponse>(responseStream);

        return result ?? null;
    }
}
