using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SQLite
{
    public class EmpleadoCell : ViewCell
    {
        public EmpleadoCell()
        {
            var idEmpleadoLabel = new Label
            {
                HorizontalTextAlignment = TextAlignment.End,
                HorizontalOptions = LayoutOptions.Start,
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
            };
            idEmpleadoLabel.SetBinding(Label.TextProperty, new Binding("IDEmpleado"));

            var nombreCompletoLabel = new Label
            {
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };
            nombreCompletoLabel.SetBinding(Label.TextProperty, new Binding("NombreCompleto"));

            var fechaContratoLabel = new Label
            {
                HorizontalOptions = LayoutOptions.StartAndExpand
            };
            fechaContratoLabel.SetBinding(Label.TextProperty, new Binding("FechaContratoEdited"));

            var salarioLabel = new Label
            {
                HorizontalTextAlignment = TextAlignment.End,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };
            salarioLabel.SetBinding(Label.TextProperty, new Binding("SalarioEdited"));

            var activoSwitch = new Switch
            {
                IsEnabled = false,
                HorizontalOptions = LayoutOptions.End
            };
            activoSwitch.SetBinding(Label.TextProperty, new Binding("Activo"));

            var line1 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    idEmpleadoLabel, nombreCompletoLabel
                },
            };

            var line2 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    fechaContratoLabel, salarioLabel, activoSwitch
                },
            };

            View = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children =
                {
                    line1, line2
                },
            };
        }
    }
}
