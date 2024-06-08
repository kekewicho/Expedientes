using Expedientes.Model;
using System.Collections.Generic;

namespace Expedientes.Views
{
    public partial class PacientesList : ContentPage
    {
        private ModelPacientes modelPacientes;

        public PacientesList()
        {
            InitializeComponent();
            modelPacientes = new ModelPacientes();
            LoadPacientes();
        }

        private void LoadPacientes()
        {
            modelPacientes.AllNotes();
            PacientesCollectionView.ItemsSource = modelPacientes.Pacientes;
        }
    }
}
