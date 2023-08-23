namespace WebApiConsumer.Contracts;

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
