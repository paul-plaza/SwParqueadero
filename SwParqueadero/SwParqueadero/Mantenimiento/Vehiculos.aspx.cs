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
        LogicaMarca logicaMarca = new LogicaMarca();
        LogicaModelo logicaModelo = new LogicaModelo();
        LogicaDimensiones logicaDimensiones = new LogicaDimensiones();
        LogicaUsuario logicaUsuario = new LogicaUsuario();
        #endregion

        #region Declaracion Variables

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                limpiarControles();
                cargarDDLMarca();
                cargarDDLTamanio();
                if (Request.QueryString["id"] != null)
                {
                    cargarGrid(Convert.ToInt32(Request.QueryString["id"]));
                    TBL_USUARIO usuario = logicaUsuario.ItemPorCodigo(Convert.ToInt32(Request.QueryString["id"]));
                    txtIdentificacion.Text = usuario.USU_CEDULA;
                    txtNombres.Text = usuario.USU_APELLIDOS + " " + usuario.USU_NOMBRES;
                    hfCodigoUsuario.Value = usuario.USU_CODIGO.ToString();
                }
            }
        }

        private void cargarGrid(int codigo)
        {
            gvdatos.DataSource = logicaVehiculo.ListaPorUsuario(codigo);
            gvdatos.DataBind();

        }

        private void cargarDDLMarca()
        {
            ddlMarca.DataSource = logicaMarca.Lista();
            ddlMarca.DataTextField = "MAR_DESCRIPCION";
            ddlMarca.DataValueField = "MAR_CODIGO";
            ddlMarca.DataBind();
            ddlMarca.SelectedIndex = 0;
            cargarDDLModelo(Convert.ToInt32(ddlMarca.SelectedValue));
        }

        private void cargarDDLModelo(int codigoMarca)
        {
            ddlModelo.DataSource = logicaModelo.ListaPorMarca(codigoMarca);
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
            item.USU_CODIGO = Convert.ToInt32(hfCodigoUsuario.Value);
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
                TBL_VEHICULO item = logicaVehiculo.ItemPorCodigo(Convert.ToInt32(e.CommandArgument));
                if (e.CommandName.Equals(CConstantes.Constantes.MODIFICAR))
                {
                    hfCodigo.Value = item.VEH_CODIGO.ToString();
                    txtPlaca.Text = item.VEH_PLACA;
                    ddlDimensiones.SelectedValue = item.DIM_CODIGO.ToString();
                    ddlModelo.SelectedValue = item.MOD_CODIGO.ToString();
                    ddlMarca.SelectedValue = item.TBL_MODELO.MAR_CODIGO.ToString();
                    TBL_USUARIO usuario = logicaUsuario.ItemPorCodigo(item.USU_CODIGO);
                    txtIdentificacion.Text = usuario.USU_CEDULA;
                    txtNombres.Text = usuario.USU_APELLIDOS + " " + usuario.USU_NOMBRES;
                    hfCodigoUsuario.Value = usuario.USU_CODIGO.ToString();
                    txtObservaciones.Text = item.VEH_OBSERVACION;
                }
                else if (e.CommandName.Equals(CConstantes.Constantes.ELIMINAR))
                {
                    logicaVehiculo.Eliminar(Convert.ToInt32(e.CommandArgument));
                    cargarGrid(item.USU_CODIGO);
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
                    if (fuImagen.HasFile)
                    {
                        CUtilitarios.cargarArchivos(fuImagen, MapPath("Vehiculos"), item.VEH_PLACA);
                    }
                    limpiarControles();
                    cargarGrid(item.USU_CODIGO);
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
            cargarGrid(Convert.ToInt32(hfCodigoUsuario.Value));
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            TBL_USUARIO item = new TBL_USUARIO();
            item = logicaUsuario.ItemPorCedula(txt_Buscar.Text.Trim().ToUpper());
            txtIdentificacion.Text = item.USU_CEDULA;
            txtNombres.Text = item.USU_APELLIDOS + " " + item.USU_NOMBRES;
            hfCodigoUsuario.Value = item.USU_CODIGO.ToString();
            txtPlaca.Focus();
            cargarGrid(item.USU_CODIGO);
        }

        protected void lkRefrescar_Click(object sender, EventArgs e)
        {
            cargarDDLModelo(Convert.ToInt32(ddlMarca.SelectedValue));
        }

        protected void lkRefrescarDimensiones_Click(object sender, EventArgs e)
        {
            cargarDDLTamanio();
        }

        protected void lkRefrescarMarca_Click(object sender, EventArgs e)
        {
            cargarDDLMarca();
        }

        protected void ddlMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarDDLModelo(Convert.ToInt32(ddlMarca.SelectedValue));
        }
    }
}