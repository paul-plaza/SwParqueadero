<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Usuarios.aspx.cs" Inherits="SwParqueadero.Mantenimiento.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript" src="../Scripts/Utilidades/ValidacionDocumentosElectronicos.js"></script>
    <hr />
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Ingreso Usuarios</h3>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-4">
                    <div class="panel panel-default" data-toggle="validator">
                        <div class="panel-body ">
                            <asp:HiddenField runat="server" ID="hfCodigo" Value="0" />
                            
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="basic-addon1">Cédula</span>
                                    <asp:TextBox runat="server" ID="txtCedula" CssClass="form-control" placeholder="Ingrese cédula"
                                        MaxLength="50" aria-describedby="basic-addon1" />
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                    ControlToValidate="txtCedula" Display="None"
                                    SetFocusOnError="true" ErrorMessage="Campo Cédula Requerido">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="basic-addon2">Nombre</span>
                                    <asp:TextBox runat="server" ID="txtNombres" CssClass="form-control" placeholder="Ingrese nombre"
                                        MaxLength="50" aria-describedby="basic-addon2" />
                                </div>
                                <asp:RequiredFieldValidator ID="rfDescripcion" runat="server"
                                    ControlToValidate="txtNombres" Display="None"
                                    SetFocusOnError="true" ErrorMessage="Campo Nombre Requerido">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="basic-addon3">Apellido</span>
                                    <asp:TextBox runat="server" ID="txtApellidos" CssClass="form-control" placeholder="Ingrese apellido"
                                        MaxLength="50" aria-describedby="basic-addon3" />
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ControlToValidate="txtApellidos" Display="None"
                                    SetFocusOnError="true" ErrorMessage="Campo Apellido Requerido">*</asp:RequiredFieldValidator>
                            </div>
                             <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="basic-addon4">Contacto</span> 
                                    <asp:TextBox runat="server" ID="txtContacto" CssClass="form-control" placeholder="Ingrese teléfono"
                                        TextMode="Number"
                                        MaxLength="50" aria-describedby="basic-addon4" />
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                    ControlToValidate="txtContacto" Display="None"
                                    SetFocusOnError="true" ErrorMessage="Campo Contacto Requerido">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="basic-addon5">E-mail</span>
                                    <asp:TextBox runat="server" ID="txtCorreo" CssClass="form-control" placeholder="Ingrese e-mail"
                                        TextMode="Email"
                                        MaxLength="50" aria-describedby="basic-addon5" />
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                    ControlToValidate="txtCorreo" Display="None"
                                    SetFocusOnError="true" ErrorMessage="Campo E-mail Requerido">*</asp:RequiredFieldValidator>
                            </div>
                            
                          
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="basic-addon8">Tipo Usuario</span>
                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlTipoUsuario">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer text-right">
                            <asp:Button Text="Guardar" ID="btnGuardar" runat="server"
                                CssClass="btn btn-default" OnClick="btnGuardar_Click" />
                            <asp:Button Text="Cancelar" ID="btnCancelar" runat="server" CssClass="btn btn-primary" />
                        </div>
                    </div>
                </div>
                <div class="col-md-8">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-md-12 text-right">
                                    <asp:Panel ID="pnl_defbotonbuscar" runat="server" CssClass="form-inline col-md-12"
                                        DefaultButton="btnBuscar">
                                        <asp:TextBox ID="txt_BuscarActivo" placeholder="(Ingrese Cédula)" runat="server"
                                            class="form-control"></asp:TextBox>
                                        <asp:Button Text="Buscar" ID="btnBuscar" CssClass="btn btn-outline-success" 
                                            CausesValidation="false" runat="server" OnClick="btnBuscar_Click" />
                                        <asp:Button ID="btn_BuscarTodosActivo" runat="server" CausesValidation="False" class="btn btn-primary"
                                            Text="Todos" ToolTip="Mostrar Todos" OnClick="btn_BuscarTodosActivo_Click" />
                                    </asp:Panel>
                                </div>
                            </div>
                        </div>

                        <div class="panel-body">
                            <div class="table-responsive">
                                <asp:GridView AutoGenerateColumns="false" Font-Size="X-Small" runat="server" ID="gvdatos" AllowPaging="true" PageSize="5"
                                    CellSpacing="-1" CssClass="table table-condensed table-hover GridView1" OnRowCommand="gvdatos_RowCommand" OnPageIndexChanging="gvdatos_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Cédula
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblCedula" Text='<%# Bind("USU_CEDULA") %>' Font-Size="XX-Small"
                                                    ToolTip='<%# Bind("USU_CEDULA") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Nombres
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblNombres" Text='<%# Bind("USU_NOMBRES") %>' Font-Size="XX-Small"
                                                    ToolTip='<%# Bind("USU_NOMBRES") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Apellidos
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblApellidos" Text='<%# Bind("USU_APELLIDOS") %>' Font-Size="XX-Small"
                                                    ToolTip='<%# Bind("USU_APELLIDOS") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Correo
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblCorreo" Text='<%# Bind("USU_CORREO") %>' Font-Size="XX-Small"
                                                    ToolTip='<%# Bind("USU_CORREO") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Contacto
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblContacto" Text='<%# Bind("USU_CONTACTO") %>' Font-Size="XX-Small"
                                                    ToolTip='<%# Bind("USU_CONTACTO") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnModificar" Text="" CausesValidation="false" runat="server"
                                                    Font-Size="10pt" Style="text-decoration: none; color: yellowgreen"
                                                    CssClass="glyphicon glyphicon-pencil" ToolTip="Modificar"
                                                    CommandName="M" CommandArgument='<%# Bind("USU_CODIGO") %>' />
                                                <asp:LinkButton ID="btnEliminar" Text="" runat="server" CssClass="glyphicon glyphicon-remove"
                                                    ToolTip="Eliminar" Font-Size="10pt" Style="text-decoration: none; color: red"
                                                    CommandName="E" CausesValidation="false" OnClientClick="return confirm('Esta Seguro de Eliminar el resgistro?')"
                                                    CommandArgument='<%# Bind("USU_CODIGO") %>' />

                                                <asp:LinkButton ID="btnEnviarCorreo" Text="" runat="server" CssClass="glyphicon glyphicon-envelope" ToolTip="Reenviar Password"
                                                    CommandName="C" CausesValidation="false" CommandArgument='<%# Bind("USU_CODIGO") %>'
                                                    Font-Size="10pt" Style="text-decoration: none; color: blue" />

                                                
                                                <asp:LinkButton ID="lnkAsignarVehiculo" Text="" runat="server" CssClass="glyphicon glyphicon-plus" ToolTip="Asignar Vehículo"
                                                    CommandName="a" CausesValidation="false" CommandArgument='<%# Bind("USU_CODIGO") %>'
                                                    Font-Size="10pt" Style="text-decoration: none; color: blue" />
                                                
                                            </ItemTemplate>
                                            <ItemStyle Width="100px" HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <asp:ValidationSummary runat="server" ID="ValidationSummary1"
                        DisplayMode="BulletList"
                        ShowMessageBox="False" ShowSummary="True" CssClass="alert alert-danger" />
                    <div id="divMensaje" runat="server" style="display: none" class="alert alert-danger">
                        <strong>Advertencia!</strong>
                        <asp:Label ID="lblMensaje" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
