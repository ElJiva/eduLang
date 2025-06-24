using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eduLangApp.Models;
using eduLangApp.ViewModels;

namespace eduLangApp.Views;

public partial class MatriculaView : ContentPage
{
    MatriculaViewModel _vm = new MatriculaViewModel();

        public MatriculaView()
        {
            InitializeComponent();
            RefrescarLista();
        }

        private void RefrescarLista()
        {
            AlumnosListView.ItemsSource = null;
            AlumnosListView.ItemsSource = _vm.ObtenerTodos();
        }

        private void OnAgregarAlumnoClicked(object sender, EventArgs e)
        {
            var nombre = NombreEntry.Text?.Trim();
            var matricula = MatriculaEntry.Text?.Trim();

            if (!string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(matricula))
            {
                var nuevo = new Alumno() { Nombre = nombre, Matricula = matricula };
                if (_vm.AgregarAlumno(nuevo))
                {
                    NombreEntry.Text = "";
                    MatriculaEntry.Text = "";
                    RefrescarLista();
                }
                else
                {
                    DisplayAlert("Error", "Ya existe un alumno con esa matrícula", "OK");
                }
            }
        }

        private void OnEliminarAlumnoClicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var matricula = btn.CommandParameter?.ToString();

            if (!string.IsNullOrEmpty(matricula))
            {
                _vm.EliminarAlumno(matricula);
                RefrescarLista();
            }
        }

        private void OnAgregarCursoClicked(object sender, EventArgs e)
        {
            var matricula = MatriculaCursoEntry.Text?.Trim();
            var curso = NombreCursoEntry.Text?.Trim();

            if (!string.IsNullOrEmpty(matricula) && !string.IsNullOrEmpty(curso))
            {
                bool agregado = _vm.AgregarCurso(matricula, curso);
                if (agregado)
                {
                    MatriculaCursoEntry.Text = "";
                    NombreCursoEntry.Text = "";
                    RefrescarLista();
                }
                else
                {
                    DisplayAlert("Error", "No se encontró un alumno con esa matrícula", "OK");
                }
            }
            
        }
}