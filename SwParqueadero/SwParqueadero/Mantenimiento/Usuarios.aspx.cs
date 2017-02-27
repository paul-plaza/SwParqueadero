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
    public partial class Usuarios : System.Web.UI.Page
    {

        LogicaTipoUsuario ltp = new LogicaTipoUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargar_ddlTipoUsuario();
            }
        }

        private void cargar_ddlTipoUsuario()
        {
            ddlTipoUsuario.DataSource = ltp.ListaTipoUsuario();
            ddlTipoUsuario.DataTextField = "TIPU_DESCRIPCION";
            ddlTipoUsuario.DataValueField = "TIPU_CODIGO";
            ddlTipoUsuario.DataBind();
        }
    }
}