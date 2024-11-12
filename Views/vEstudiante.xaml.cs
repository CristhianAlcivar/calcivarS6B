using calcivarS6B.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace calcivarS6B.Views;

public partial class vEstudiante : ContentPage
{
	private const string url = "http://172.17.48.1:8090/api/user";
	private readonly HttpClient cliente = new HttpClient();
	private ObservableCollection<Estudiante> estudiantes;
	public vEstudiante()
	{
		InitializeComponent();
		listar();

    }
	public async void listar()
	{
		var content = await cliente.GetStringAsync(url);
        EstudiantesResponse listaEstu = JsonConvert.DeserializeObject<EstudiantesResponse>(content);
		lvEstudaintes.ItemsSource = listaEstu.data;


    }

    private void btnAbrir_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new vInsertarEstudiante());
    }

    private void lvEstudaintes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        Estudiante objEstudiante = (Estudiante)e.SelectedItem;
		Navigation.PushAsync(new vActualizarEliminar(objEstudiante));
    }
}