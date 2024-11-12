using calcivarS6B.Models;
using System.Net;

namespace calcivarS6B.Views;

public partial class vActualizarEliminar : ContentPage
{
    private const string url = "http://172.17.48.1:8090/api/user";

    public vActualizarEliminar(Estudiante estudiante)
	{
		InitializeComponent();
        txtId.Text = estudiante.id.ToString();
        txtNombre.Text = estudiante.nombre;
        txtApellido.Text = estudiante.apellido;
        txtEdad.Text = estudiante.edad.ToString();

    }


    private async void btnActualizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();

            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);

            cliente.UploadValues($"{url}/{txtId.Text}", "PUT", parametros);

            await Navigation.PushAsync(new vEstudiante());

        }
        catch (Exception ex)
        {
            await DisplayAlert("ERROR", ex.Message, "Cerrar");
        }
    }

    private async void btnEliminar_Clicked(object sender, EventArgs e)
    {
        bool confirmacion = await DisplayAlert("Confirmación", "¿Estás seguro de que deseas eliminar este elemento?", "Sí", "No");

        if (confirmacion)
        {
            try
            {
                WebClient cliente = new WebClient();

                var parametros = new System.Collections.Specialized.NameValueCollection();

                cliente.UploadValues($"{url}/{txtId.Text}", "DELETE", parametros);

                await Navigation.PushAsync(new vEstudiante());


            }
            catch (Exception ex)
            {
                await DisplayAlert("ERROR", ex.Message, "Cerrar");
            }
        }
    }
}