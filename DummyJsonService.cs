using System.Text.Json;

namespace WebApiConsumer;

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

public interface IDummyJsonService
{
    Task<LoginResponse?> Login(string username, string password);
    Task<GetUserResponse?> GetUser(int id);
}

public sealed record LoginResponse
{
    public int id { get; set; }
    public string username { get; set; } = string.Empty;
    public string password { get; set; } = string.Empty;
    public string email { get; set; } = string.Empty;
    public string firstName { get; set; } = string.Empty;
    public string lastName { get; set; } = string.Empty;
    public string gender { get; set; } = string.Empty;
    public string image { get; set; } = string.Empty;
    public string token { get; set; } = string.Empty;
}
