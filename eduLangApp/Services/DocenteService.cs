using System.Net.Http.Json;
using eduLangApp.Models;

namespace eduLangApp.Services;

public class DocenteService
{
    private readonly HttpClient _httpClient;

    public DocenteService()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(ApiUrl.BaseUrl);
    }

    public async Task<List<Docente>> LoadDocentesAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Docente>>("docentes")
               ?? new List<Docente>();
    }
}