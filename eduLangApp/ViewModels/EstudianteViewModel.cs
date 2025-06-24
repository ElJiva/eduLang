using System.Collections.ObjectModel;
using System.ComponentModel;
using eduLangApp.Models;
using eduLangApp.Services;

namespace eduLangApp.ViewModels;

public class EstudianteViewModel : INotifyPropertyChanged
{
    private readonly EstudianteServices _estudianteServices;
    public ObservableCollection<Estudiantes> ListaEstudiantes { get; set; } = new();
    public Estudiantes EstudianteEncontrado { get; set; } = new();

    public EstudianteViewModel()
    {
        _estudianteServices = new EstudianteServices();
    }

    public async Task LoadEstudiantesAsync()
    {
        try
        {
            var estudiantes = await _estudianteServices.LoadEstudiantesAsync();
            ListaEstudiantes.Clear();
            foreach (var est in estudiantes)
                ListaEstudiantes.Add(est);
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
        }
    }
    public async Task BuscarEstudiantePorIdAsync(int id)
    {
        try
        {
            var estudiante = await _estudianteServices.LoadEstudianteByIdAsync(id);
            if (estudiante != null)
            {
                EstudianteEncontrado = estudiante;
                ListaEstudiantes.Clear();
                ListaEstudiantes.Add(estudiante);
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("No encontrado", $"No se encontró el estudiante con ID {id}", "OK");
            }
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
        }
    }
        
        

    public event PropertyChangedEventHandler PropertyChanged;
}