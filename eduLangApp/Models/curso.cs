namespace eduLangApp.Models;

public class Curso
{
    public string Idioma { get; set; }
    public string Nivel { get; set; }
    public string Horario { get; set; }
    public int Cupo { get; set; }
    public int DocenteId { get;set;}
}