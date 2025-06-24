using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eduLangApp.Views;

public partial class CalificacionesView : ContentPage
{
    public CalificacionesView()
    {
        InitializeComponent();
    }

    private async void OnRegresarClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); 
    }
}