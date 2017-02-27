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
    public partial class TipoUsuario : System.Web.UI.Page
    {
        #region Declaracion Clases
        LogicaTipoUsuario logicaTipoUsuario = new LogicaTipoUsuario();
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
            gvdatos.DataSource = logicaTipoUsuario.ListaTipoUsuario();
            gvdatos.DataBind();

        }

        private void limpiarControles()
        {
            txtDescripcion.Text = string.Empty;
            hfCodigo.Value = CConstantes.Constantes.VALOR_POR_DEFECTO;
            txtDescripcion.Focus();
        }

        private TBL_TIPO_USUARIO cargaEntidad()
        {
            TBL_TIPO_USUARIO item = new TBL_TIPO_USUARIO();
            item.TIPU_DESCRIPCION = txtDescripcion.Text.Trim().ToUpper();
            return item;
        }

        protected void gvdatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals(CConstantes.Constantes.MODIFICAR))
                {
                    TBL_TIPO_USUARIO item = logicaTipoUsuario.ItemPorCodigo(Convert.ToInt32(e.CommandArgument));
                    hfCodigo.Value = item.TIPU_CODIGO.ToString();
                    txtDescripcion.Text = item.TIPU_DESCRIPCION;
                }
                else if (e.CommandName.Equals(CConstantes.Constantes.ELIMINAR))
                {
                    logicaTipoUsuario.Eliminar(Convert.ToInt32(e.CommandArgument));
                    cargarGrid();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDescripcion.Text))
            {
                try
                {
                    if (hfCodigo.Value.Equals(CConstantes.Constantes.VALOR_POR_DEFECTO))
                    {
                        logicaTipoUsuario.Guardar(cargaEntidad());
                    }
                    else
                    {
                        TBL_TIPO_USUARIO item = logicaTipoUsuario.ItemPorCodigo(Convert.ToInt32(hfCodigo.Value));
                        item = cargaEntidad();
                        logicaTipoUsuario.Modificar(item);
                    }
                    cargarGrid();
                }
                catch (Exception ex)
                {

                    throw;
                }
                limpiarControles();
            }
        }
    }
}