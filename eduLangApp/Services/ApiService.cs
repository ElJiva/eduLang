namespace eduLangApp.Services;

using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService()
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:3000/api/")
        };
    }

    // Login
    public async Task<UserResponse> LoginAsync(string email, string password)
    {
        var loginData = new LoginRequest
        {
            Email = email,
            Password = password
        };
        var response = await _httpClient.PostAsJsonAsync("auth/login", loginData);
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<UserResponse>(); 
            if (result == null)
                throw new Exception("Respuesta nula del servidor");
            return result;
        }
        else
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception("Login fallido: " + error);
        }
    }
}