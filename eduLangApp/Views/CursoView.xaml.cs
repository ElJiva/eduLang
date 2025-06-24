using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eduLangApp.Views;

public partial class CursoView : ContentPage
{
    public CursoView()
    {
        InitializeComponent();
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}

// public partial class CursoView : ContentPage
// {
//     public class Curso
//     {
//         public string Idioma { get; set; }
//         public string Nivel { get; set; }
//         public string Horario { get; set; }
//         public int Cupo { get; set; }
//         public int DocenteId { get; set; }
//     }
//
//     public CursoView()
//     {
//         InitializeComponent();
//
//         var cursosEjemplo = new List<Curso>
//         {
//             new Curso { Idioma = "Inglés", Nivel = "A1", Horario = "Lunes y Miércoles 10:00-12:00", Cupo = 15, DocenteId = 101 },
//             new Curso { Idioma = "Francés", Nivel = "B1", Horario = "Martes y Jueves 14:00-16:00", Cupo = 12, DocenteId = 102 },
//             new Curso { Idioma = "Japonés", Nivel = "Inicial", Horario = "Sábados 09:00-13:00", Cupo = 10, DocenteId = 103 },
//             new Curso { Idioma = "Alemán", Nivel = "B2", Horario = "Viernes 17:00-20:00", Cupo = 8, DocenteId = 104 }
//         };
//
//         CursosList.ItemsSource = cursosEjemplo;
//     }
//
//     private async void OnBackClicked(object sender, EventArgs e)
//     {
//         await Navigation.PopAsync();
//     }
// }