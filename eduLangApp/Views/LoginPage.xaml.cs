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

            await DisplayAlert("Bienvenido de nuevo", $"{result.User.Role}", "OK");

            await Navigation.PushAsync(new MainPage());
            
            Navigation.RemovePage(this);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }
}