using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using eduLangApp.Models;
using eduLangApp.Services;
using eduLangApp.Views;

namespace eduLangApp.ViewModels;

public class DocenteViewModel : INotifyPropertyChanged
{
    private readonly DocenteService _docenteService;
    private Docente _docenteSeleccionado;
    private bool _isRefreshing;

    public ObservableCollection<Docente> ListaDocentes { get; set; } = new();
    
    public Docente DocenteSeleccionado
    {
        get => _docenteSeleccionado;
        set
        {
            _docenteSeleccionado = value;
            OnPropertyChanged();
            if (value != null)
                EditarDocenteCommand.Execute(value);
        }
    }

    public bool IsRefreshing
    {
        get => _isRefreshing;
        set
        {
            _isRefreshing = value;
            OnPropertyChanged();
        }
    }

    public ICommand LoadDocentesCommand { get; }
    public ICommand AgregarDocenteCommand { get; }
    public ICommand EditarDocenteCommand { get; }
    public ICommand EliminarDocenteCommand { get; }
    public ICommand RefreshCommand { get; }

    public DocenteViewModel()
    {
        _docenteService = new DocenteService();
        
        LoadDocentesCommand = new Command(async () => await LoadDocentesAsync());
        AgregarDocenteCommand = new Command(async () => await AgregarDocente());
        EditarDocenteCommand = new Command<Docente>(async (d) => await EditarDocente(d));
        EliminarDocenteCommand = new Command<Docente>(async (d) => await EliminarDocente(d));
        RefreshCommand = new Command(async () => {
            IsRefreshing = true;
            await LoadDocentesAsync();
            IsRefreshing = false;
        });

        // Cargar datos iniciales
        LoadDocentesCommand.Execute(null);
    }

    public async Task LoadDocentesAsync()
    {
        try
        {
            var docentes = await _docenteService.LoadDocentesAsync();
            ListaDocentes.Clear();
            foreach (var d in docentes)
                ListaDocentes.Add(d);
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
        }
    }

    private async Task AgregarDocente()
    {
        // Navegar a la página de creación con un nuevo docente vacío
        var navigationParameter = new ShellNavigationQueryParameters
        {
            { "docente", new Docente() }
        };
        await Shell.Current.GoToAsync(nameof(DocenteView), navigationParameter);
    }

    private async Task EditarDocente(Docente docente)
    {
        // Navegar a la página de edición con el docente seleccionado
        var navigationParameter = new ShellNavigationQueryParameters
        {
            { "docente", docente }
        };
        await Shell.Current.GoToAsync(nameof(DocenteView), navigationParameter);
    }

    private async Task EliminarDocente(Docente docente)
    {
        bool confirmar = await Application.Current.MainPage.DisplayAlert(
            "Confirmar",
            $"¿Está seguro que desea eliminar al docente {docente.UsuarioNombre}?",
            "Sí", "No");

        if (confirmar)
        {
            var (success, message) = await _docenteService.DeleteDocenteAsync(docente.Id);
            if (success)
            {
                await Application.Current.MainPage.DisplayAlert("Éxito", message, "OK");
                await LoadDocentesAsync(); // Refrescar la lista
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", message, "OK");
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}