using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eduLangApp.Views;

public partial class MatriculaView : ContentPage
{
    public MatriculaView()
    {
        InitializeComponent();
            
        NombreLabel.Text = "Juan Carlos Rodríguez";
        MatriculaLabel.Text = "ALU-2025-0021";
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}