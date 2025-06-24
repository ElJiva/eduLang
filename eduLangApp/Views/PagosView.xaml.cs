using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System.Collections.Generic;

namespace eduLangApp.Views;

public partial class PagosView : ContentPage
{
    public class Pago
    {
        public string Tipo { get; set; }               
        public string Mes { get; set; }
        public DateTime FechaPago { get; set; }
        public double Monto { get; set; }
        public bool Pagado { get; set; }

            
        public string PagadoText => Pagado ? "✅ Pagado" : "❌ No pagado";
        public Color PagadoColor => Pagado ? Colors.LimeGreen : Colors.Red;
        public bool EsMensualidad => Tipo == "Mensualidad";
    }

    public PagosView()
    {
        InitializeComponent();

        var pagosEjemplo = new List<Pago>
        {
            new Pago { Tipo = "Inscripción", FechaPago = new DateTime(2025, 1, 10), Monto = 1500, Pagado = true },
            new Pago { Tipo = "Mensualidad", Mes = "Febrero", FechaPago = new DateTime(2025, 2, 5), Monto = 1200, Pagado = true },
            new Pago { Tipo = "Mensualidad", Mes = "Marzo", FechaPago = new DateTime(2025, 3, 10), Monto = 1200, Pagado = false },
            new Pago { Tipo = "Mensualidad", Mes = "Abril", FechaPago = new DateTime(2025, 4, 5), Monto = 1200, Pagado = true }
        };

        PagosCollectionView.ItemsSource = pagosEjemplo;
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}