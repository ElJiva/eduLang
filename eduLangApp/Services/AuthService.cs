using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using eduLangApp.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace eduLangApp.Services;


public class AuthService
{
  private readonly HttpClient _httpClient = new()
  {
    BaseAddress = new Uri("http://localhost:3000/api/")
  };


  public async Task<bool> LoginAsync(string email, string password)
  {
    try
    {
      var loginData = new
      {
        Email = email,
        Password = password
      };

      var response = await _httpClient.PostAsJsonAsync("auth/login", loginData);

      if (!response.IsSuccessStatusCode)
        return false;

      var result = await response.Content.ReadFromJsonAsync<AuthResponse>();

      if (result?.Success == true)
      {
        // Preferences.Set("user", result.Usuario.Nombre); // Descomenta si necesitas esto
        return true;
      }

      return false;
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Error en LoginAsync: {ex}");
      throw; // O puedes return false si prefieres manejar el error silenciosamente
    }
  }
}