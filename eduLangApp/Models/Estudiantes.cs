namespace eduLangApp.Models;

public class Estudiantes
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public string Nombre { get; set; }
    public string UsuarioNombre { get; set; }
    public string Correo { get; set; }
    public string Rol { get; set; }
    public string Matricula { get; set; }
    public string CursoIdioma { get; set; }
    public string CursoNivel { get; set; }
    public string CursoHorario { get; set; }
}