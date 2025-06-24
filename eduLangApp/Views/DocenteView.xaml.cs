using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eduLangApp.ViewModels;

namespace eduLangApp.Views;

public partial class DocenteView : ContentPage
{
    DocenteViewModel viewModel;

    public DocenteView()
    {
        InitializeComponent();
        viewModel = new DocenteViewModel();
        BindingContext = viewModel;
    }

    private async void OnLoadClicked(object sender, EventArgs e)
    {
        await viewModel.LoadDocentesAsync();
    }
}