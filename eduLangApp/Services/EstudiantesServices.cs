using System.Net.Http.Json;
using eduLangApp.Models;


namespace eduLangApp.Services;

public class EstudianteServices
{
    private readonly HttpClient _httpClient;

    public EstudianteServices()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(" https://cf91-2806-2f0-6000-e1df-b58e-880e-10fd-79bb.ngrok-free.app/api/");
    }

    public async Task<List<Estudiantes>> LoadEstudiantesAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Estudiantes>>("estudiantes")
               ?? new List<Estudiantes>();
    }
    public async Task<Estudiantes?> LoadEstudianteByIdAsync(int id)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<Estudiantes>($"estudiantes/{id}");
        }
        catch (Exception)
        {
            return null;
        }
    }



      

}