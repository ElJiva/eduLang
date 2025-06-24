using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using eduLangApp.Models;

namespace eduLangApp.ViewModels;

public class CursoViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Curso> Cursos { get; set; }

    public CursoViewModel()
    {
            
        Cursos = new ObservableCollection<Curso>
        {
            new Curso { Idioma = "Inglés", Nivel = "Básico", Horario = "Lunes y Miércoles", Cupo = 25, DocenteId = 1 },
            new Curso { Idioma = "Francés", Nivel = "Intermedio", Horario = "Martes y Jueves", Cupo = 15, DocenteId = 2 },
            new Curso { Idioma = "Alemán", Nivel = "Avanzado", Horario = "Sábados", Cupo = 10, DocenteId = 3 },
        };
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}