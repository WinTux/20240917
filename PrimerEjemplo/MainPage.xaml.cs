using PrimerEjemplo.ConexionDatos;
using PrimerEjemplo.Models;
using PrimerEjemplo.Pages;
using System.Diagnostics;

namespace PrimerEjemplo
{
    public partial class MainPage : ContentPage
    {
        private readonly IRestConexionDatos conexionDatos;

        public MainPage(IRestConexionDatos conexionDatos)
        {
            InitializeComponent();
            this.conexionDatos = conexionDatos;
        }

        protected async override void OnAppearing() { 
            base.OnAppearing();
            coleccionPlatosView.ItemsSource = await conexionDatos.GetPlatosAsync();
        }

        //Evento Add
        async void OnAddPlatoClic(object sender, EventArgs e) {
            Debug.WriteLine("[EVENTO] Botón AddPlato clickeado");
            var param = new Dictionary<string, object> {
                {nameof(Plato), new Plato() }
            };
            await Shell.Current.GoToAsync(nameof(GestionPlatosPage),param);
        }

        //Evento clic a un plato de la lista
        async void OnelementoCambiado(object sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine("[EVENTO] Botón ElementoCambiado clickeado");
            var param = new Dictionary<string, object> {
                {nameof(Plato), e.CurrentSelection.FirstOrDefault() as Plato }
            };
            await Shell.Current.GoToAsync(nameof(GestionPlatosPage), param);
        }
    }

}
