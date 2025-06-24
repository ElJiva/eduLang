using System.Collections.ObjectModel;
using eduLangApp.Models;

namespace eduLangApp.ViewModels;

public class CalificacionesViewModel
{
    public ObservableCollection<Calificacion> ListaCalificaciones { get; set; }

    public CalificacionesViewModel()
    {
        ListaCalificaciones = new ObservableCollection<Calificacion>
        {
            new Calificacion { Curso = "Matemáticas", Evaluacion = "Parcial 1", Nota = 8.5 },
            new Calificacion { Curso = "Matemáticas", Evaluacion = "Parcial 2", Nota = 9.0 },
            new Calificacion { Curso = "Ciencias", Evaluacion = "Final", Nota = 8.8 },
            new Calificacion { Curso = "Historia", Evaluacion = "Parcial 1", Nota = 7.5 },
        };
    }
}