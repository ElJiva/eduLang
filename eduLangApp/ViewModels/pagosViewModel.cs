using System.Collections.ObjectModel;
using eduLangApp.Models;

namespace eduLangApp.ViewModels;

public class PagosViewModel
{
    public ObservableCollection<Pago> ListaPagos { get; set; }

    public PagosViewModel()
    {
        ListaPagos = new ObservableCollection<Pago>
        {
            new Pago { Tipo = "Inscripción", FechaPago = new DateTime(2025, 1, 10), Monto = 1500, Pagado = true },
            new Pago { Tipo = "Mensualidad", Mes = "Febrero", FechaPago = new DateTime(2025, 2, 5), Monto = 1200, Pagado = true },
            new Pago { Tipo = "Mensualidad", Mes = "Marzo", FechaPago = new DateTime(2025, 3, 10), Monto = 1200, Pagado = false }
        };
    }
}