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
            gvdatos.DataSource = logicaParqueadero.Lista();
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

        private TBL_PARQUEADERO cargaEntidad(TBL_PARQUEADERO item)
        {
            item.PAR_DESCRIPCION = txtDescripcion.Text.Trim().ToUpper();
            item.PAR_DIRECCION = txtDireccion.Text.Trim().ToUpper();
            item.PAR_ENCARGADO = txtEncargado.Text.Trim().ToUpper();
            item.PAR_TELEFONO_ENCARGADO = txtTelefonoEncargado.Text;
            item.PAR_CONTACTO = txtContacto1.Text.Trim().ToUpper();
            item.PAR_CONTACTO2 = txtContacto2.Text.Trim().ToUpper();
            item.PAR_TELEFONO = txtTelefonoContacto1.Text.Trim().ToUpper();
            item.PAR_TELEFONO2 = txtTelefonoContacto2.Text.Trim().ToUpper();
            item.PAR_PUESTOS = Convert.ToInt32(txtPuestos.Text);
            return item;
        }

        protected void gvdatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals(CConstantes.Constantes.MODIFICAR))
                {
                    TBL_PARQUEADERO item = logicaParqueadero.ItemPorCodigo(Convert.ToInt32(e.CommandArgument));
                    hfCodigo.Value = item.PAR_CODIGO.ToString();
                    txtDescripcion.Text = item.PAR_DESCRIPCION;
                    txtDireccion.Text = item.PAR_DIRECCION;
                    txtEncargado.Text = item.PAR_ENCARGADO;
                    txtTelefonoEncargado.Text = item.PAR_TELEFONO_ENCARGADO;
                    txtContacto1.Text = item.PAR_CONTACTO;
                    txtContacto2.Text = item.PAR_CONTACTO2;
                    txtTelefonoContacto1.Text = item.PAR_TELEFONO;
                    txtTelefonoContacto2.Text = item.PAR_TELEFONO2;
                    txtPuestos.Text = item.PAR_PUESTOS.ToString();

                }
                else if (e.CommandName.Equals(CConstantes.Constantes.ELIMINAR))
                {
                    logicaParqueadero.Eliminar(Convert.ToInt32(e.CommandArgument));
                    cargarGrid();
                }
            }
            catch (Exception ex)
            {
                divMensaje.Attributes.Add("Style", "display:block");
                lblMensaje.Text = ex.Message;
            }
        }

        protected void gvdatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvdatos.PageIndex = e.NewPageIndex;
            cargarGrid();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDescripcion.Text))
            {
                try
                {
                    TBL_PARQUEADERO item = new TBL_PARQUEADERO();
                    if (hfCodigo.Value.Equals(CConstantes.Constantes.VALOR_POR_DEFECTO))
                    {
                        logicaParqueadero.Guardar(cargaEntidad(item));
                    }
                    else
                    {
                        item = logicaParqueadero.ItemPorCodigo(Convert.ToInt32(hfCodigo.Value));
                        item = cargaEntidad(item);
                        logicaParqueadero.Modificar(item);
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