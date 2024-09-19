using PrimerEjemplo.ConexionDatos;
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
        }

        //Evento clic a un plato de la lista
        async void OnelementoCambiado(object sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine("[EVENTO] Botón ElementoCambiado clickeado");
        }
    }

}
