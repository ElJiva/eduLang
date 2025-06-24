using eduLangApp.Models;

namespace eduLangApp.ViewModels;

public class CredencialAlumnoViewModel
{
    public Alumno AlumnoActual { get; private set; }

    public CredencialAlumnoViewModel()
    {
        AlumnoActual = new Alumno
        {
            Nombre = "Juan Pérez",
            Matricula = "A01234567"
        };
    }

    public CredencialAlumnoViewModel(Alumno alumno)
    {
        AlumnoActual = alumno;
    }
}