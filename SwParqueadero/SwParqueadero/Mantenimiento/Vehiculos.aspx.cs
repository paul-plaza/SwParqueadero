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
    public partial class Vehiculos : System.Web.UI.Page
    {
        #region Declaracion Clases
        LogicaVehiculo logicaVehiculo = new LogicaVehiculo();
        LogicaModelo logicaModelo = new LogicaModelo();
        LogicaDimensiones logicaDimensiones = new LogicaDimensiones();
        #endregion

        #region Declaracion Variables

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                limpiarControles();
                cargarDDLModelo();
                cargarDDLTamanio();
                cargarGrid();
            }
        }

        private void cargarGrid()
        {
            gvdatos.DataSource = logicaVehiculo.Lista();
            gvdatos.DataBind();

        }

        private void cargarDDLModelo()
        {
            ddlModelo.DataSource = logicaModelo.Lista();
            ddlModelo.DataTextField = "MOD_DESCRIPCION";
            ddlModelo.DataValueField = "MOD_CODIGO";
            ddlModelo.DataBind();
        }

        private void cargarDDLTamanio()
        {
            ddlDimensiones.DataSource = logicaDimensiones.Lista();
            ddlDimensiones.DataTextField = "DIM_DESCRIPCION";
            ddlDimensiones.DataValueField = "DIM_CODIGO";
            ddlDimensiones.DataBind();
        }

        private TBL_VEHICULO cargaEntidad(TBL_VEHICULO item)
        {
            item.VEH_PLACA = txtPlaca.Text.Trim().ToUpper();
            item.DIM_CODIGO = Convert.ToInt32(ddlDimensiones.SelectedValue);
            item.MOD_CODIGO = Convert.ToInt32(ddlModelo.SelectedValue);
            item.USU_CODIGO = Convert.ToInt32(hfCodigo.Value);
            item.VEH_OBSERVACION = txtObservaciones.Text.Trim().ToUpper();
            
            return item;
        }

        private void limpiarControles()
        {
            txtPlaca.Text = string.Empty;
            hfCodigo.Value = CConstantes.Constantes.VALOR_POR_DEFECTO;
            txtPlaca.Focus();
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
                    TBL_MODELO item = logicaModelo.ItemPorCodigo(Convert.ToInt32(e.CommandArgument));
                    hfCodigo.Value = item.MOD_CODIGO.ToString();
                    txtPlaca.Text = item.MOD_DESCRIPCION;
                    ddlModelo.SelectedValue = item.MAR_CODIGO.ToString();
                }
                else if (e.CommandName.Equals(CConstantes.Constantes.ELIMINAR))
                {
                    logicaModelo.Eliminar(Convert.ToInt32(e.CommandArgument));
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
            if (!string.IsNullOrEmpty(txtPlaca.Text))
            {
                try
                {
                    TBL_VEHICULO item = new TBL_VEHICULO();
                    if (hfCodigo.Value.Equals(CConstantes.Constantes.VALOR_POR_DEFECTO))
                    {
                        logicaVehiculo.Guardar(cargaEntidad(item));
                    }
                    else
                    {

                        item = logicaVehiculo.ItemPorCodigo(Convert.ToInt32(hfCodigo.Value));
                        item = cargaEntidad(item);
                        logicaVehiculo.Modificar(item);
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
            gvdatos.DataSource = logicaModelo.ListaPorDescripcion(txt_BuscarActivo.Text.Trim().ToUpper());
            gvdatos.DataBind();

        }

        protected void btn_BuscarTodosActivo_Click(object sender, EventArgs e)
        {
            cargarGrid();
        }

        protected void lkRefrescar_Click(object sender, EventArgs e)
        {
            cargarDDLModelo();
        }

        protected void lkRefrescarDimensiones_Click(object sender, EventArgs e)
        {
            cargarDDLTamanio();
        }
    }
}