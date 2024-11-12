using System.Net;

namespace calcivarS6B.Views;

public partial class vInsertarEstudiante : ContentPage
{
    private const string url = "http://172.17.48.1:8090/api/user";

    public vInsertarEstudiante()
	{
		InitializeComponent();
	}

    private void btnGuardar_Clicked(object sender, EventArgs e)
    {
		try
		{
			WebClient cliente = new WebClient();
			var parametros = new System.Collections.Specialized.NameValueCollection();
			parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);

			cliente.UploadValues(url, "POST", parametros);
			Navigation.PushAsync(new vEstudiante());

        }
        catch (Exception ex)
		{
			DisplayAlert("ERROR", ex.Message, "Cerrar");
		}

    }
}