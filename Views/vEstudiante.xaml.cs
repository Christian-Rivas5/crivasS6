using crivasS6.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace crivasS6.Views;

public partial class vEstudiante : ContentPage
{
	private const string url = "http://192.168.1.30/moviles/wsestudiantes.php";
	private readonly HttpClient cliente = new HttpClient();
	private ObservableCollection<Estudiante> est;
	public vEstudiante()
	{
		InitializeComponent();
		ObtenerDatos();
	}

	public async void ObtenerDatos()
	{
		var contetnt = await cliente.GetStringAsync(url);
		List<Estudiante> mostrar = JsonConvert.DeserializeObject<List<Estudiante>>(contetnt);
		est =new ObservableCollection<Estudiante> (mostrar);
		listEstudiante.ItemsSource = est;



    }
}