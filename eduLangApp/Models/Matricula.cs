namespace eduLangApp.Models;

public class Alumno
{
    public string Nombre { get; set; }
    public string Matricula { get; set; }
    public List<string> Cursos { get; set; } = new List<string>();

    public override bool Equals(object obj)
    {
        return obj is Alumno other && Matricula == other.Matricula;
    }

    public override int GetHashCode()
    {
        return Matricula.GetHashCode();
    }
}