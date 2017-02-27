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
    public partial class Marcas : System.Web.UI.Page
    {
        #region Declaracion Clases
        LogicaMarca logicaMarca = new LogicaMarca();
        #endregion

        #region Declaracion Variables

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
            gvdatos.DataSource = logicaMarca.Lista();
            gvdatos.DataBind();

        }

        private TBL_MARCA cargaEntidad()
        {
            TBL_MARCA item = new TBL_MARCA();
            item.MAR_DESCRIPCION = txtDescripcion.Text.Trim().ToUpper();
            return item;
        }

        private void limpiarControles()
        {
            txtDescripcion.Text = string.Empty;
            hfCodigo.Value = CConstantes.Constantes.VALOR_POR_DEFECTO;
            txtDescripcion.Focus();
        }
        protected void gvdatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals(CConstantes.Constantes.MODIFICAR))
                {
                    TBL_MARCA item = logicaMarca.ItemPorCodigo(Convert.ToInt32(e.CommandArgument));
                    hfCodigo.Value = item.MAR_CODIGO.ToString();
                    txtDescripcion.Text = item.MAR_DESCRIPCION;
                }
                else if (e.CommandName.Equals(CConstantes.Constantes.ELIMINAR))
                {
                    logicaMarca.Eliminar(Convert.ToInt32(e.CommandArgument));
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
                        logicaMarca.Guardar(cargaEntidad());
                    }
                    else
                    {
                        TBL_MARCA item = logicaMarca.ItemPorCodigo(Convert.ToInt32(hfCodigo.Value));
                        item = cargaEntidad();
                        logicaMarca.Modificar(item);
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