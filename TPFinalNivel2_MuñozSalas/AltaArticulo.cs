﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;
namespace TPFinalNivel2_MuñozSalas
{
    public partial class AltaArticulo : Form
    {
        public AltaArticulo()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            negocioArticulo negocio = new negocioArticulo();
            Articulos articulo = new Articulos();
            try
            {
                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Precio = Convert.ToDecimal(txtPrecio.Text);
                articulo.Marca = (Marcas)cbMarca.SelectedItem;
                articulo.Categoria = (Categorias)cbCategoria.SelectedItem;
                articulo.UrlImagen = txtImagen.Text;

                negocio.AgregarArticulo(articulo);
                MessageBox.Show("Agregado con éxito");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void AltaArticulo_Load(object sender, EventArgs e)
        {
            negocioMarca aux = new negocioMarca();
            negocioCategoria aux2 = new negocioCategoria(); 

            try
            {
                cbMarca.DataSource = aux.listar();
                cbCategoria.DataSource = aux2.listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtImagen.Text);
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbArticulo.SizeMode = PictureBoxSizeMode.Zoom;
                pbArticulo.Load(imagen);
            }
            catch (Exception)
            {
                //MessageBox.Show("No se pudo encontrar la imagen");
                pbArticulo.Load("https://cdn.icon-icons.com/icons2/3001/PNG/512/default_filetype_file_empty_document_icon_187718.png");
            }
        }
    }
}
