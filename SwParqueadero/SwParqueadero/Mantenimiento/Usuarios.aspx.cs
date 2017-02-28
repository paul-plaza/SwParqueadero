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
        #region Declaracion Clases
        LogicaUsuario logicaUsuario = new LogicaUsuario();
        LogicaTipoUsuario logicaTipoUsuario = new LogicaTipoUsuario();
        CUtilitarios cUtilitarios = new CUtilitarios();
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarGrid();
                cargar_ddlTipoUsuario();
            }
        }

        private void cargar_ddlTipoUsuario()
        {
            ddlTipoUsuario.DataSource = logicaTipoUsuario.ListaTipoUsuario();
            ddlTipoUsuario.DataTextField = "TIPU_DESCRIPCION";
            ddlTipoUsuario.DataValueField = "TIPU_CODIGO";
            ddlTipoUsuario.DataBind();
        }

        private void cargarGrid()
        {
            gvdatos.DataSource = logicaUsuario.Lista();
            gvdatos.DataBind();

        }

        private void limpiarControles()
        {
            txtCedula.Text = string.Empty;
            txtNombres.Text = string.Empty;
            txtApellidos.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtContacto.Text = string.Empty;

            hfCodigo.Value = CConstantes.Constantes.VALOR_POR_DEFECTO;
            txtCedula.Focus();
        }

        private TBL_USUARIO cargaEntidad(TBL_USUARIO item)
        {
            item.USU_CEDULA = txtCedula.Text.Trim().ToUpper();
            item.USU_NOMBRES = txtNombres.Text.Trim().ToUpper();
            item.USU_APELLIDOS = txtApellidos.Text.Trim().ToUpper();
            item.USU_CORREO = txtCorreo.Text.Trim();
            item.USU_CONTACTO = txtContacto.Text.Trim().ToUpper();
            item.USU_ESTADO = true;
            item.USU_PASSWORD = cUtilitarios.Encriptar(txtCedula.Text);
            item.TIPU_CODIGO = Convert.ToInt32(ddlTipoUsuario.SelectedValue);
            
            
            return item;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCedula.Text))
            {
                try
                {
                    TBL_USUARIO item = new TBL_USUARIO();
                    if (hfCodigo.Value.Equals(CConstantes.Constantes.VALOR_POR_DEFECTO))
                    {
                       
                            logicaUsuario.Guardar(cargaEntidad(item)); 
                    }
                    else
                    {
                        item = logicaUsuario.ItemPorCodigo(Convert.ToInt32(hfCodigo.Value));
                        item = cargaEntidad(item);
                        logicaUsuario.Modificar(item);
                    }
                    cargarGrid();
                    cargar_ddlTipoUsuario();
                }
                catch (Exception ex)
                {

                    throw;
                }
                limpiarControles();
            }
        }

        protected void gvdatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals(CConstantes.Constantes.MODIFICAR))
                {
                    TBL_USUARIO item = logicaUsuario.ItemPorCodigo(Convert.ToInt32(e.CommandArgument));
                    hfCodigo.Value = item.USU_CODIGO.ToString();
                    txtCedula.Text = item.USU_CEDULA;
                    txtNombres.Text = item.USU_NOMBRES;
                    txtApellidos.Text = item.USU_APELLIDOS;
                    txtContacto.Text = item.USU_CONTACTO;
                    txtCorreo.Text = item.USU_CORREO;
                    ddlTipoUsuario.SelectedValue = item.TIPU_CODIGO.ToString();
                }
                else if (e.CommandName.Equals(CConstantes.Constantes.ELIMINAR))
                {
                    logicaUsuario.Eliminar(Convert.ToInt32(e.CommandArgument));
                    cargarGrid();
                }
                else if (e.CommandName.Equals(CConstantes.Constantes.ENVIAR_CORREO))
                {
                    TBL_USUARIO item = logicaUsuario.ItemPorCodigo(Convert.ToInt32(e.CommandArgument));
                    
                    item.USU_CORREO

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

      
    }
}