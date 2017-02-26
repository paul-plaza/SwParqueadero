using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwParqueadero.AccesoDatos;
using SwParqueadero.Negocio.Mantenimiento;

namespace SwParqueadero.Mantenimiento
{
    public partial class Marcas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                cargarGrid();
            }
        }

        private void cargarGrid()
        {
            gvdatos.DataSource = LogicaMarca.Lista();
            gvdatos.DataBind();

        }

        protected void gvdatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}