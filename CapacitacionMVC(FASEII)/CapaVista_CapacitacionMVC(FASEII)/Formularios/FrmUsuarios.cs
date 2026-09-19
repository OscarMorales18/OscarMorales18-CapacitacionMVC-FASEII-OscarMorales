using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaControlador_CapacitacionMVC_FASEII_.Modelos;
using CapaVista_CapacitacionMVC_FASEII_.Reportes;

namespace CapaVista_CapacitacionMVC_FASEII_.Formularios
{
    public partial class FrmUsuarios : Form
    {
        private ModeloUsuarios usuario = new ModeloUsuarios();
        public FrmUsuarios()
        {
            InitializeComponent();
            panIngresoDatos.Enabled = false;
            listadoUsuarios();
            CargarDatos();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            listaUsuarios();
        }

        private void listaUsuarios()
        {
            try
            {
                dgvUsuarios.DataSource = usuario.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                usuario.IdUsuario = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells[0].Value);
                usuario.Estado = CapaControlador_CapacitacionMVC_FASEII_.EstadoEntidad.Deleted;
                string resultado = usuario.GrabarCambios();
                MessageBox.Show(resultado);
                listaUsuarios();
            }
            else
            {
                MessageBox.Show("Seleccione un registro para eliminar");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvUsuarios.DataSource = usuario.FindbyId(txtSearch.Text);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvUsuarios.DataSource = usuario.FindbyId(txtSearch.Text);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            usuario.Usuario = txtNombreUsuario.Text;
            usuario.Contrasena = txtContrasenaUsuario.Text;
            usuario.Rol = txtRolUsuario.Text; 
            bool valido = new Ayudas.ValidacionDatos(usuario).Validar();
            if (valido == true)
            {
                string resultado = usuario.GrabarCambios();
                MessageBox.Show(resultado);
                listaUsuarios();
                Reinicio();
            }
        }

        private void Reinicio()
        {
            txtNombreUsuario.Text = "";
            txtContrasenaUsuario.Text = "";
            txtRolUsuario.Text = "";
            panIngresoDatos.Enabled = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            panIngresoDatos.Enabled = true;
            usuario.Estado = CapaControlador_CapacitacionMVC_FASEII_.EstadoEntidad.Added;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                panIngresoDatos.Enabled = true;
                usuario.Estado = CapaControlador_CapacitacionMVC_FASEII_.EstadoEntidad.Modified;
                usuario.IdUsuario = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells[0].Value);
                txtNombreUsuario.Text = dgvUsuarios.CurrentRow.Cells[1].Value.ToString();
                txtContrasenaUsuario.Text = dgvUsuarios.CurrentRow.Cells[2].Value.ToString();
                txtRolUsuario.Text = dgvUsuarios.CurrentRow.Cells[3].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione un registro para editar");
            }
        }
        private void listadoUsuarios()
        {
            try
            {
                var lista = usuario.GetAll();
                MessageBox.Show("Registros encontrados: " + lista.Count());
                dgvUsuarios.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        void CargarDatos()
        {
            comboInteligente1.llenarCombo("usuarios", "rol", "usuario");
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmReporteUsuarios reporte = new frmReporteUsuarios();
            reporte.Show();
        }
    }
}
