﻿using PrimerEjemplo.Pages;

namespace PrimerEjemplo
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(GestionPlatosPage),typeof(GestionPlatosPage));
        }
    }
}
