using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPFinalNivel2_MuñozSalas
{
    public partial class ListadoDeArticulos : Form
    {
        private List<Articulos> articulos;
        public ListadoDeArticulos(string Usuario)
        {
            InitializeComponent();
            label1.Text = "Usuario: " + Usuario;
        }

        private void ListadoDeArticulos_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void Cargar()
        {
            try
            {
                negocioArticulo obj = new negocioArticulo();
                articulos = obj.Listar();

                dgvArticulos.DataSource = articulos;
                dgvArticulos.Columns["UrlImagen"].Visible = false;
                cargarImagen(articulos[0].UrlImagen);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbArticulos.SizeMode = PictureBoxSizeMode.Zoom;
                pbArticulos.Load(imagen);
            }
            catch (Exception)
            {
                //MessageBox.Show("No se pudo encontrar la imagen");
                pbArticulos.Load("https://cdn.icon-icons.com/icons2/3001/PNG/512/default_filetype_file_empty_document_icon_187718.png");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AltaArticulo alta = new AltaArticulo();
            alta.ShowDialog();
            Cargar();
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            Articulos seleccionado = (Articulos)dgvArticulos.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.UrlImagen);
        }
    }
}
