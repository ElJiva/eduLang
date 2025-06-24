namespace eduLangApp.Models;

public class Docente
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public string UsuarioNombre { get; set; }
    public string Correo { get; set; }
    public string Especialidad { get; set; }
    public string Disponibilidad { get; set; }
}