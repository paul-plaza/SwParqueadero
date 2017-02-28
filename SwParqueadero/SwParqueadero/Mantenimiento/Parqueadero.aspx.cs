using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwParqueadero.AccesoDatos;
using SwParqueadero.Comun;
using SwParqueadero.Negocio.Mantenimiento;

namespace SwParqueadero.Mantenimiento
{
    public partial class Parqueadero : System.Web.UI.Page
    {
        #region Declaracion Clases
        LogicaParqueadero logicaParqueadero = new LogicaParqueadero();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarGrid();
            }
        }

        private void cargarGrid()
        {
            gvdatos.DataSource = logicaParqueadero.ListaParqueadero();
            gvdatos.DataBind();
        }

        private void limpiarControles()
        {
            txtDescripcion.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtEncargado.Text = string.Empty;
            txtTelefonoEncargado.Text = string.Empty;
            txtContacto1.Text = string.Empty;
            txtContacto2.Text = string.Empty;
            txtTelefonoContacto1.Text = string.Empty;
            txtTelefonoContacto2.Text = string.Empty;

            hfCodigo.Value = CConstantes.Constantes.VALOR_POR_DEFECTO;
            txtDireccion.Focus();
        }

        protected void gvdatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvdatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}