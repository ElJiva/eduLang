using eduLangApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace eduLangApp.ViewModels;

public class MatriculaViewModel
{
    private static List<Alumno> _alumnos = new List<Alumno>();

    public Alumno AlumnoActual { get; private set; }

    public MatriculaViewModel() { }

    public MatriculaViewModel(Alumno alumno)
    {
        AlumnoActual = alumno;
    }

    public bool AgregarAlumno(Alumno alumno)
    {
        if (_alumnos.Any(a => a.Matricula == alumno.Matricula))
            return false;

        _alumnos.Add(alumno);
        return true;
    }

    public bool EliminarAlumno(string matricula)
    {
        var alumno = _alumnos.FirstOrDefault(a => a.Matricula == matricula);
        if (alumno != null)
        {
            _alumnos.Remove(alumno);
            return true;
        }
        return false;
    }

    public Alumno BuscarPorMatricula(string matricula)
    {
        return _alumnos.FirstOrDefault(a => a.Matricula == matricula);
    }

    public List<Alumno> ObtenerTodos()
    {
        return _alumnos;
    }

    public bool AgregarCurso(string matricula, string curso)
    {
        var alumno = _alumnos.FirstOrDefault(a => a.Matricula == matricula);
        if (alumno != null)
        {
            if (!alumno.Cursos.Contains(curso))
                alumno.Cursos.Add(curso);
            return true;
        }
        return false;
    }
}