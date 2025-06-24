using eduLangApp.Views;

namespace eduLangApp;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void GoToEstudiantes(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EstudianteView());
    }

    private async void GoToDocente(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DocenteView());
    }
    private async void OnPaymentsClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PagosView());
    }
    private async void OnCalificacionesClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CalificacionesView());
    }
    private async void OnCursosClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CursoView());
    }
    private async void OnMatriculaClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MatriculaView());
    }




       
}