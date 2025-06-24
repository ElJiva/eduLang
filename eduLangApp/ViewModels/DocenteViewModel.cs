using System.Collections.ObjectModel;
using System.ComponentModel;
using eduLangApp.Models;
using eduLangApp.Services;

namespace eduLangApp.ViewModels;

public class DocenteViewModel : INotifyPropertyChanged
{
    private readonly DocenteService _docenteService;
    public ObservableCollection<Docente> ListaDocentes { get; set; } = new();

    public DocenteViewModel()
    {
        _docenteService = new DocenteService();
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

    public event PropertyChangedEventHandler PropertyChanged;
}