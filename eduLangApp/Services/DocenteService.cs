using System.Net.Http.Json;
using eduLangApp.Models;

namespace eduLangApp.Services;

public class DocenteService
{
    private readonly HttpClient _httpClient;

    public DocenteService()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(" https://cf91-2806-2f0-6000-e1df-b58e-880e-10fd-79bb.ngrok-free.app/api/");
    }

    public async Task<List<Docente>> LoadDocentesAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Docente>>("docentes")
               ?? new List<Docente>();
    }
}