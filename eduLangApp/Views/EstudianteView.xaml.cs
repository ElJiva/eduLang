using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eduLangApp.ViewModels;

namespace eduLangApp.Views;

public partial class EstudianteView : ContentPage
{
    EstudianteViewModel viewModel;

    public EstudianteView()
    {
        InitializeComponent();
        viewModel = new EstudianteViewModel();
        BindingContext = viewModel;
    }

    private async void OnLoadClicked(object sender, EventArgs e)
    {
        await viewModel.LoadEstudiantesAsync();
    }
        

        
    private async void OnBuscarPorIdClicked(object sender, EventArgs e)
    {
        if (int.TryParse(IdEntry.Text, out int id))
        {
            await viewModel.BuscarEstudiantePorIdAsync(id);
        }
        else
        {
            await DisplayAlert("Error", "Ingresa un ID válido.", "OK");
        }
    }

}