using eduLangApp.Views;

namespace eduLangApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var loginPage = new LoginPage();
        return new Window(new NavigationPage(loginPage));
    }
}