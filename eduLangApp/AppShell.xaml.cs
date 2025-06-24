using eduLangApp.Views;

namespace eduLangApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(DocenteView), typeof(DocenteView));
        Routing.RegisterRoute("estudiante", typeof(EstudianteView));
        

    }
}