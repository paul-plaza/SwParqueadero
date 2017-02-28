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
    public partial class Puestos : System.Web.UI.Page
    {
        #region Declaracion Clases
        LogicaParqueadero logicaParqueadero = new LogicaParqueadero();
        LogicaPuestos logicaPuestos = new LogicaPuestos();
        LogicaDimensiones logicaDimensiones = new LogicaDimensiones();
        #endregion

        #region Declaracion Variables

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                limpiarControles();
                cargarDDL();
                cargarGrid();
                cargarDDLTamanio();
            }
        }

        private void cargarGrid()
        {
            if (ddlParqueadero.Items.Count > 0)
            {
                if (!string.IsNullOrEmpty(txtBuscar.Text.Trim()))
                {
                    gvdatos.DataSource = logicaPuestos.ListaPorNombreParqueadero(Convert.ToInt32(ddlParqueadero.SelectedValue), txtBuscar.Text.Trim().ToUpper());
                }
                else
                {
                    gvdatos.DataSource = logicaPuestos.ListaPorCodigoParqueadero(Convert.ToInt32(ddlParqueadero.SelectedValue));
                }
                gvdatos.DataBind();
            }
        }

        private void cargarDDLTamanio()
        {
            ddlDimensiones.DataSource = logicaDimensiones.Lista();
            ddlDimensiones.DataTextField = "DIM_DESCRIPCION";
            ddlDimensiones.DataValueField = "DIM_CODIGO";
            ddlDimensiones.DataBind();
        }

        private void cargarDDL()
        {
            ddlParqueadero.DataSource = logicaParqueadero.Lista();
            ddlParqueadero.DataTextField = "PAR_DESCRIPCION";
            ddlParqueadero.DataValueField = "PAR_CODIGO";
            ddlParqueadero.DataBind();
        }

        private TBL_PUESTOS cargaEntidad(TBL_PUESTOS item)
        {
            item.DIM_CODIGO = Convert.ToInt32(ddlDimensiones.SelectedValue);
            item.PAR_CODIGO = Convert.ToInt32(ddlParqueadero.SelectedValue);
            item.PUE_NOMBRE = txtDescripcion.Text.Trim().ToUpper();
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
                    TBL_PUESTOS item = logicaPuestos.ItemPorCodigo(Convert.ToInt32(e.CommandArgument));
                    hfCodigo.Value = item.PUE_CODIGO.ToString();
                    txtDescripcion.Text = item.PUE_NOMBRE;

                }
                else if (e.CommandName.Equals(CConstantes.Constantes.ELIMINAR))
                {
                    logicaPuestos.Eliminar(Convert.ToInt32(e.CommandArgument));
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
                    TBL_PUESTOS item = new TBL_PUESTOS();
                    if (hfCodigo.Value.Equals(CConstantes.Constantes.VALOR_POR_DEFECTO))
                    {
                        if (logicaParqueadero.ItemPorCodigo(Convert.ToInt32(ddlParqueadero.SelectedValue)).PAR_PUESTOS == 0)
                        {
                            logicaPuestos.Guardar(cargaEntidad(item));
                        }
                    }
                    else
                    {

                        item = logicaPuestos.ItemPorCodigo(Convert.ToInt32(hfCodigo.Value));
                        item = cargaEntidad(item);
                        logicaPuestos.Modificar(item);
                    }
                    limpiarControles();
                    cargarGrid();
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
            gvdatos.DataSource = logicaPuestos.ListaPorNombreParqueadero(Convert.ToInt32(ddlParqueadero.SelectedValue), txtBuscar.Text.Trim().ToUpper());
            gvdatos.DataBind();
        }

        protected void btn_BuscarTodosActivo_Click(object sender, EventArgs e)
        {
            cargarGrid();
        }

        protected void lkRefrescar_Click(object sender, EventArgs e)
        {
            cargarDDL();
        }

        protected void lkRefrescarDimensiones_Click(object sender, EventArgs e)
        {
            cargarDDLTamanio();
        }
    }
}