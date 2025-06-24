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

    // Obtener todos los docentes (READ)
    public async Task<List<Docente>> LoadDocentesAsync()
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<List<Docente>>("api/docentes")
                   ?? new List<Docente>();
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Error al obtener docentes: {ex.Message}");
            return new List<Docente>();
        }
    }

    // Obtener un docente por ID (READ)
    public async Task<Docente> GetDocenteByIdAsync(int id)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<Docente>($"api/docentes/{id}");
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Error al obtener docente con ID {id}: {ex.Message}");
            return null;
        }
    }

    // Crear un nuevo docente (CREATE)
    public async Task<(bool success, string message)> CreateDocenteAsync(Docente docente)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/docentes", docente);
            
            if (response.IsSuccessStatusCode)
            {
                return (true, "Docente creado exitosamente");
            }
            
            var errorMessage = await response.Content.ReadAsStringAsync();
            return (false, $"Error al crear docente: {errorMessage}");
        }
        catch (Exception ex)
        {
            return (false, $"Excepción al crear docente: {ex.Message}");
        }
    }

    // Actualizar un docente existente (UPDATE)
    public async Task<(bool success, string message)> UpdateDocenteAsync(int id, Docente docente)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"api/docentes/{id}", docente);
            
            if (response.IsSuccessStatusCode)
            {
                return (true, "Docente actualizado exitosamente");
            }
            
            var errorMessage = await response.Content.ReadAsStringAsync();
            return (false, $"Error al actualizar docente: {errorMessage}");
        }
        catch (Exception ex)
        {
            return (false, $"Excepción al actualizar docente: {ex.Message}");
        }
    }

    // Eliminar un docente (DELETE)
    public async Task<(bool success, string message)> DeleteDocenteAsync(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"api/docentes/{id}");

            if (response.IsSuccessStatusCode)
            {
                return (true, "Docente eliminado exitosamente");
            }

            var errorMessage = await response.Content.ReadAsStringAsync();
            return (false, $"Error al eliminar docente: {errorMessage}");
        }
        catch (Exception ex)
        {
            return (false, $"Excepción al eliminar docente: {ex.Message}");
        }
    }
}