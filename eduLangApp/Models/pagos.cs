namespace eduLangApp.Models;

public class Pago
{
    public string Tipo { get; set; }           
    public string Mes { get; set; }           
    public DateTime FechaPago { get; set; }
    public double Monto { get; set; }
    public bool Pagado{get;set;}
}