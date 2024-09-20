using PrimerEjemplo.ConexionDatos;
using PrimerEjemplo.Models;

namespace PrimerEjemplo.Pages;

[QueryProperty(nameof(plato), "Plato")]
public partial class GestionPlatosPage : ContentPage
{
	private readonly IRestConexionDatos restConexionDatos;
	private Plato _plato;
	private bool _esNuevo;
	public Plato plato {
		get => _plato;
		set {
			_esNuevo = esNuevo(value);
			_plato = value;
			OnPropertyChanged();//Obligatorio
		}
	}
	public GestionPlatosPage(IRestConexionDatos restConexionDatos)
	{
		InitializeComponent();
		this.restConexionDatos = restConexionDatos;
		BindingContext = this;// Debemos poner esto
    }
	bool esNuevo(Plato plato) {
		if (plato.Id == 0)
			return true;
		return false;
	}

	async void OnCancelClic(object sender, EventArgs e) {
		await Shell.Current.GoToAsync("..");//Retorna un nivel atrás
	}
	async void OnGuardarClic(object sender, EventArgs e) {
		if (_esNuevo)
		{
			await restConexionDatos.AddPlatoAsync(plato);
		}else
			await restConexionDatos.UpdatePlatoAsync(plato);
        await Shell.Current.GoToAsync("..");
    }

	async void OnEliminarClic(object sender, EventArgs e) {
        await restConexionDatos.DeletePlatoAsync(plato.Id);
        await Shell.Current.GoToAsync("..");
    }

}