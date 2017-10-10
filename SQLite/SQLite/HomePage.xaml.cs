using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            listaListView.ItemTemplate = new DataTemplate(typeof(EmpleadoCell));
            listaListView.RowHeight = 70;

            using (var datos = new DataAccess())
            {                
                listaListView.ItemsSource = datos.GetEmpleados();
            }

            agregarButton.Clicked += AgregarButton_Clicked;

        }

        private async void AgregarButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nombresEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar nombres", "Aceptar");
                nombresEntry.Focus();
                return;
            }

            if (string.IsNullOrEmpty(apellidosEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar apellidos", "Aceptar");
                apellidosEntry.Focus();
                return;
            }

            if (string.IsNullOrEmpty(salarioEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar salario", "Aceptar");
                salarioEntry.Focus();
                return;
            }

            var empleado = new Empleado
            {
                Nombres = nombresEntry.Text,
                Apellidos = apellidosEntry.Text,
                FechaContrato = fechaContratoDatePicker.Date,
                Salario = Decimal.Parse(salarioEntry.Text),
                Activo = activoSwitch.IsToggled
            };

            using (var datos = new DataAccess())
            {
                datos.InsertEmpleado(empleado);
                listaListView.ItemsSource = datos.GetEmpleados();
            }

            nombresEntry.Text = string.Empty;
            apellidosEntry.Text = string.Empty;
            salarioEntry.Text = string.Empty;
            fechaContratoDatePicker.Date = DateTime.Now;
            activoSwitch.IsToggled = true;
            await DisplayAlert("Confirmacion", "Empleado creado", "Aceptar");
        }
    }
}