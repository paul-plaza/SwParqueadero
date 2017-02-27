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
                limpiarControles();
                cargarGrid();
            }
        }

        private void cargarGrid()
        {
            gvdatos.DataSource = logicaMarca.Lista();
            gvdatos.DataBind();

        }

        private TBL_MARCA cargaEntidad(TBL_MARCA item)
        {
            item.MAR_DESCRIPCION = txtDescripcion.Text.Trim().ToUpper();
            return item;
        }

        private void limpiarControles()
        {
            txtDescripcion.Text = string.Empty;
            hfCodigo.Value = CConstantes.Constantes.VALOR_POR_DEFECTO;
            txtDescripcion.Focus();
            divMensaje.Attributes.Add("Style", "display:none");
            lblMensaje.Text = string.Empty;
        }
        protected void gvdatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                divMensaje.Attributes.Add("Style", "display:none");
                lblMensaje.Text = string.Empty;
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
                divMensaje.Attributes.Add("Style", "display:block");
                lblMensaje.Text = ex.Message;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDescripcion.Text))
            {
                try
                {
                    TBL_MARCA item = new TBL_MARCA();
                    if (hfCodigo.Value.Equals(CConstantes.Constantes.VALOR_POR_DEFECTO))
                    {
                        logicaMarca.Guardar(cargaEntidad(item));
                    }
                    else
                    {

                        item = logicaMarca.ItemPorCodigo(Convert.ToInt32(hfCodigo.Value));
                        item = cargaEntidad(item);
                        logicaMarca.Modificar(item);
                    }
                    cargarGrid();
                    limpiarControles();
                }
                catch (Exception ex)
                {
                    divMensaje.Attributes.Add("Style", "display:block");
                    lblMensaje.Text = ex.Message;
                }
            }
        }

        protected void gvdatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvdatos.PageIndex = e.NewPageIndex;
            cargarGrid();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            gvdatos.DataSource = logicaMarca.ListaPorDescripcion(txt_BuscarActivo.Text.Trim().ToUpper());
            gvdatos.DataBind();

        }

        protected void btn_BuscarTodosActivo_Click(object sender, EventArgs e)
        {
            cargarGrid();
        }
    }
}