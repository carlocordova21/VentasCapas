using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaEntidad;
using CapaNegocios;
namespace CapaPresentacion
{
    public partial class ClienteCP : Form
    {
        private static ClienteCP instancia = null;

        public static ClienteCP Instancia 
        { 
            get
            {
                if (instancia == null || instancia.IsDisposed == true)
                {
                    instancia = new ClienteCP();
                }
                return instancia;
            } 
        }

        public ClienteCP()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ClienteCN clienteCN = new ClienteCN();
            List<ClienteCE> listaClientes = new List<ClienteCE>();
            if (rbtnDesc.Checked == true)
            {
                string valorBuscado = txtBuscarDesc.Text;
                listaClientes = clienteCN.buscarNombre(valorBuscado);
            } else if (rbtnRuc.Checked == true)
            {
                string ruc = txtBuscarRuc.Text;
                listaClientes = clienteCN.buscarRuc(ruc);
            }

            dgvClientes.DataSource = listaClientes;
        }

        private void rbtnRuc_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnDesc.Checked == true)
            {
                txtBuscarDesc.Enabled = true;
                txtBuscarRuc.Enabled = false;

                txtBuscarRuc.Text = "";
            }
            else if (rbtnRuc.Checked == true)
            {
                txtBuscarDesc.Enabled = false;
                txtBuscarRuc.Enabled = true;

                txtBuscarDesc.Text = "";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string nombre = txtNombre.Text;
            string ruc = txtRuc.Text;
            string direccion = txtDireccion.Text;
            string telefono = txtTelefono.Text;

            ClienteCE clienteCE = new ClienteCE(id, nombre,ruc, direccion, telefono);
            ClienteCN clienteCN = new ClienteCN();

            if (txtId.Text == "0")
            {
                int nuevoId = clienteCN.insertar(clienteCE);
                if (nuevoId > 0) {
                    txtId.Text = nuevoId.ToString();
                    MessageBox.Show("Se ha insertado un nuevo registro");
                }
            } else
            {
                bool estado = clienteCN.actualizar(clienteCE);
                if (estado == true)
                {
                    MessageBox.Show("Se ha actualizado el registro");
                }
            }
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSel = dgvClientes.SelectedRows[0];
                int id = Convert.ToInt32(filaSel.Cells["id"].Value);
                string nombre = filaSel.Cells["nombre"].Value.ToString();
                string ruc = filaSel.Cells["numruc"].Value.ToString();
                string direccion = filaSel.Cells["direccion"].Value.ToString();
                string telefono = filaSel.Cells["telefono"].Value.ToString();

                txtId.Text = id.ToString();
                txtNombre.Text = nombre;
                txtRuc.Text = ruc;
                txtDireccion.Text = direccion;
                txtTelefono.Text = telefono;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            resetControl();
        }

        private void resetControl()
        {
            txtId.Text = "0";
            txtNombre.Text = "";
            txtRuc.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";

            txtBuscarDesc.Clear();
            txtBuscarRuc.Clear();
            dgvClientes.DataSource = null;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            if (id != 0)
            {
                DialogResult rpta = MessageBox.Show("Esta a punto " +
                    "de eliminar un registro. Esta seguro?", "Eliminar"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button2);

                ClienteCN clienteCN = new ClienteCN();
                if (rpta == DialogResult.Yes)
                {
                    bool estado = clienteCN.eliminar(id);
                    MessageBox.Show("Se elimino el registro");
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
