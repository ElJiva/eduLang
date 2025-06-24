using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using eduLangApp.Services;
using Microsoft.Maui.Controls;

namespace eduLangApp.ViewModels;

public class LoginViewModel : INotifyPropertyChanged
{
    private readonly AuthService _authService;
    private readonly Page _page;
    
    private string _email;
    private string _password;
    private bool _isBusy;

    public event PropertyChangedEventHandler PropertyChanged;

    public string Email
    {
        get => _email;
        set
        {
            if (_email == value) return;
            _email = value;
            OnPropertyChanged();
        }
    }

    public string Password
    {
        get => _password;
        set
        {
            if (_password == value) return;
            _password = value;
            OnPropertyChanged();
        }
    }

    public bool IsBusy
    {
        get => _isBusy;
        set
        {
            if (_isBusy == value) return;
            _isBusy = value;
            OnPropertyChanged();
            ((Command)LoginCommand).ChangeCanExecute();
        }
    }

    public ICommand LoginCommand { get; }
    public ICommand RegisterCommand { get; }

    public LoginViewModel(AuthService authService, Page page)
    {
        _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        _page = page ?? throw new ArgumentNullException(nameof(page));

        LoginCommand = new Command(async () => await Login(), () => !IsBusy);
        RegisterCommand = new Command(async () => await NavigateToRegister());
    }

    private async Task Login()
    {
        if (IsBusy) return;

        try
        {
            IsBusy = true;

            if (string.IsNullOrWhiteSpace(Email) 
                || string.IsNullOrWhiteSpace(Password))
            {
                await _page.DisplayAlert("Error", "Por favor ingresa email y contraseña", "OK");
                return;
            }

            var isAuthenticated = await _authService.LoginAsync(Email, Password);

            if (isAuthenticated)
            {
                // Navegación después de login exitoso
                await Shell.Current.GoToAsync("//MainPage");
                // Alternativa si no usas Shell:
                // await _page.Navigation.PushAsync(new MainPage());
            }
            else
            {
                await _page.DisplayAlert("Error", "Credenciales incorrectas", "OK");
            }
        }
        catch (Exception ex)
        {
            await _page.DisplayAlert("Error", $"Error al iniciar sesión: {ex.Message}", "OK");
            // Considera loggear el error: Debug.WriteLine(ex);
        }
        finally
        {
            IsBusy = false;
        }
    }

    private async Task NavigateToRegister()
    {
        await Shell.Current.GoToAsync("//RegisterPage");
        // Alternativa si no usas Shell:
        // await _page.Navigation.PushAsync(new RegisterPage());
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}