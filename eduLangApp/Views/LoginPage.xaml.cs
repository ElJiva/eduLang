using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using eduLangApp.Services;


namespace eduLangApp.Views;

public partial class LoginPage : ContentPage
{
    private readonly ApiService _apiService = new();

    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        try
        {
            var email = emailEntry.Text;
            var password = passwordEntry.Text;

            var result = await _apiService.LoginAsync(email, password);

            await DisplayAlert("Bienvenido", $"Hola {result.User.Email}, tu rol es: {result.User.Role}", "OK");

            // Aquí puedes navegar a una vista distinta según el rol
            // if (result.User.Rol == "admin") ...
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }
}