using System;

using System.Collections.Generic;
using System.Web.UI.WebControls;
using SwParqueadero.AccesoDatos;
using SwParqueadero.Comun;
using SwParqueadero.Negocio.Mantenimiento;
using System.Threading.Tasks;
using System.Web.Security;

namespace SwParqueadero.Mantenimiento
{
    public partial class Usuarios : System.Web.UI.Page
    {
        #region Declaracion Clases
        LogicaUsuario logicaUsuario = new LogicaUsuario();
        LogicaTipoUsuario logicaTipoUsuario = new LogicaTipoUsuario();
        LogicaEmpresa logicaEmpresa = new LogicaEmpresa();
        CUtilitarios cUtilitarios = new CUtilitarios();

        List<string> correos = new List<string>();
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarGrid();
                cargar_ddlTipoUsuario();
                AgregarAtributosComponentes();
            }
        }

        public void AgregarAtributosComponentes()
        {
            txtCedula.Attributes.Add("onkeydown", "onkeydown");
            txtCedula.Attributes.Add("onkeypress", "return funSoloNumeros(event)");
            txtCedula.Attributes.Add("onblur", "return funValidarDocumento(this,this)");
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
        private void cargarGrid(string cedula)
        {
            gvdatos.DataSource = logicaUsuario.ListaUsuarioPorCedula(cedula);
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
            item.USU_PASSWORD = Membership.GeneratePassword(6, 1);
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
                        EEmail mail = new EEmail();
                        item = cargaEntidad(item);
                        mail.Mensaje = "Sus credenciales de acceso al sistema de parqueadero son: <br/><B>Usuario: </B>" + item.USU_CEDULA + "<br/><B>Password: </B>" + item.USU_PASSWORD;
                        mail.IntroCabecera = logicaEmpresa.ItemDefault().EMP_NOMBRE;
                        mail.Resumen = string.Empty;
                        mail.Subtitulo = string.Empty;
                        mail.TituloMensjae = "Credenciales";
                        correos.Add(item.USU_CORREO);
                        cUtilitarios.EnviarCorreoGenerico(logicaEmpresa.ItemDefault(), correos, mail, Server.MapPath(CConstantes.Constantes.PLANTILLA_MAIL));
                        item.USU_PASSWORD = cUtilitarios.Encriptar(item.USU_PASSWORD);
                        logicaUsuario.Guardar(item);
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
                    divMensaje.Attributes.Add("Style", "display:block");
                    lblMensaje.Text = ex.Message;
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
                    Task.Factory.StartNew(() =>
                    {
                        try
                        {
                            #region Mail
                            TBL_USUARIO item = logicaUsuario.ItemPorCodigo(Convert.ToInt32(e.CommandArgument));
                            EEmail mail = new EEmail();
                            item.USU_PASSWORD = Membership.GeneratePassword(6, 1);
                            mail.Mensaje = "Se a generado para el siguiente <B>Usuario: </B>" + item.USU_CEDULA + " una contraseña temporal para el ingreso al sistema de parqueadero. <br/> <B>Password: </B>" + item.USU_PASSWORD;
                            item.USU_PASSWORD = cUtilitarios.Encriptar(item.USU_PASSWORD);
                            mail.IntroCabecera = logicaEmpresa.ItemDefault().EMP_NOMBRE;
                            mail.Resumen = string.Empty;
                            mail.Subtitulo = string.Empty;
                            mail.TituloMensjae = "Credenciales";
                            
                            #endregion
                            
                            correos.Add(item.USU_CORREO);
                            cUtilitarios.EnviarCorreoGenerico(logicaEmpresa.ItemDefault(), correos, mail, Server.MapPath(CConstantes.Constantes.PLANTILLA_MAIL));
                        }
                        catch (Exception ex)
                        {
                            divMensaje.Attributes.Add("Style", "display:block");
                            lblMensaje.Text = ex.Message;
                        }
                    });
                }
                else if (e.CommandName.Equals(CConstantes.Constantes.ASIGNACION_VEHICULO))
                {
                    TBL_USUARIO item = logicaUsuario.ItemPorCodigo(Convert.ToInt32(e.CommandArgument));
                    Response.Redirect("~/Vehiculos.aspx?id=" + item.USU_CODIGO);
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

        protected void btn_BuscarTodosActivo_Click(object sender, EventArgs e)
        {
            txt_BuscarActivo.Text = string.Empty;
            if (string.IsNullOrEmpty(txt_BuscarActivo.Text))
            {
                cargarGrid();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_BuscarActivo.Text))
            {
                cargarGrid(txt_BuscarActivo.Text);
            }
        }
    }
}