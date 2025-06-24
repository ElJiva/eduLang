using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using eduLangApp.Models;

namespace eduLangApp.ViewModels;

public class CursoViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Curso> Cursos { get; set; }

    public ICommand AgregarCursoCommand { get; }
    public ICommand EliminarCursoCommand { get; }

    private Curso _cursoSeleccionado;
    public Curso CursoSeleccionado
    {
        get => _cursoSeleccionado;
        set
        {
            _cursoSeleccionado = value;
            OnPropertyChanged();
        }
    }

    public CursoViewModel()
    {
        Cursos = new ObservableCollection<Curso>
        {
            new Curso { Idioma = "Inglés", Nivel = "Básico", Horario = "Lunes y Miércoles", Cupo = 25, DocenteId = 1 },
            new Curso { Idioma = "Francés", Nivel = "Intermedio", Horario = "Martes y Jueves", Cupo = 15, DocenteId = 2 }
        };

        AgregarCursoCommand = new Command(AgregarCurso);
        EliminarCursoCommand = new Command(EliminarCurso);
    }

    private void AgregarCurso()
    {
        Cursos.Add(new Curso
        {
            Idioma = "Nuevo idioma",
            Nivel = "Nuevo nivel",
            Horario = "Nuevo horario",
            Cupo = 10,
            DocenteId = 0
        });
    }

    private void EliminarCurso()
    {
        if (CursoSeleccionado != null)
            Cursos.Remove(CursoSeleccionado);
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}