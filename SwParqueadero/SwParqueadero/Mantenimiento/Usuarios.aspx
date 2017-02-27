<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="SwParqueadero.Mantenimiento.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
                            <asp:HiddenField runat="server" ID="HiddenField2" Value="0" />
                            <asp:ValidationSummary runat="server" ID="ValidationSummary1"
                                DisplayMode="BulletList"
                                ShowMessageBox="False" ShowSummary="True" CssClass="alert alert-danger" />
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="basic-addon1">Cédula</span>
                                    <asp:TextBox runat="server" ID="txtCedula" CssClass="form-control" placeholder="Ingrese cédula"
                                        MaxLength="50" aria-describedby="basic-addon1" />
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                    ControlToValidate="txtCedula" Display="None"
                                    SetFocusOnError="true" ErrorMessage="Campo Requerido">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="basic-addon2">Nombre</span>
                                    <asp:TextBox runat="server" ID="txtNombres" CssClass="form-control" placeholder="Ingrese nombre"
                                        MaxLength="50" aria-describedby="basic-addon2" />
                                </div>
                                <asp:RequiredFieldValidator ID="rfDescripcion" runat="server"
                                    ControlToValidate="txtNombres" Display="None"
                                    SetFocusOnError="true" ErrorMessage="Campo Requerido">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="basic-addon3">Apellido</span>
                                    <asp:TextBox runat="server" ID="txtApellidos" CssClass="form-control" placeholder="Ingrese apellido"
                                        MaxLength="50" aria-describedby="basic-addon3" />
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ControlToValidate="txtApellidos" Display="None"
                                    SetFocusOnError="true" ErrorMessage="Campo Requerido">*</asp:RequiredFieldValidator>
                            </div>
                             <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="basic-addon4">Contacto</span>
                                    <asp:TextBox runat="server" ID="txtContacto" CssClass="form-control" placeholder="Ingrese teléfono"
                                        MaxLength="50" aria-describedby="basic-addon4" />
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                    ControlToValidate="txtContacto" Display="None"
                                    SetFocusOnError="true" ErrorMessage="Campo Requerido">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="basic-addon5">E-mail</span>
                                    <asp:TextBox runat="server" ID="txtCorreo" CssClass="form-control" placeholder="Ingrese e-mail" TextMode="Email"
                                        MaxLength="50" aria-describedby="basic-addon5" />
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                    ControlToValidate="txtCorreo" Display="None"
                                    SetFocusOnError="true" ErrorMessage="Campo Requerido">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="basic-addon6">Password</span>
                                    <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" placeholder="Ingrese Password" TextMode="Password"
                                        MaxLength="50" aria-describedby="basic-addon6" />
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                    ControlToValidate="txtPassword" Display="None"
                                    SetFocusOnError="true" ErrorMessage="Campo Requerido">*</asp:RequiredFieldValidator>
                            </div>
                           <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon " id="basic-addon7">Confirmar</span>
                                    <asp:TextBox runat="server" ID="TextBox1" CssClass="form-control" placeholder="Confirmar password" TextMode="Password"
                                        MaxLength="50" aria-describedby="basic-addon7" />
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                    ControlToValidate="txtPassword" Display="None"
                                    SetFocusOnError="true" ErrorMessage="Campo Requerido">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="basic-addon8">Tipo Usuario</span>
                                    <asp:DropDownList runat="server" CssClass="form-control">
                                        <asp:ListItem Text="Admini" />
                                        <asp:ListItem Text="Profesor" />
                                    </asp:DropDownList>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                    ControlToValidate="txtPassword" Display="None"
                                    SetFocusOnError="true" ErrorMessage="Campo Requerido">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="panel-footer text-right">
                            <asp:Button Text="Guardar" ID="btnGuardar" runat="server"
                                CssClass="btn btn-default" />
                            <asp:Button Text="Cancelar" ID="btbCancelar" runat="server" CssClass="btn btn-primary" />
                        </div>
                    </div>
                </div>
                <div class="col-md-8">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <h3 class="panel-title">Listado de Tipos de Usuarios</h3>
                        </div>

                        <div class="panel-body">
                            <div class="table-responsive">
                                
                                <%--<asp:GridView AutoGenerateColumns="false" Font-Size="X-Small" runat="server" ID="gvdatos"
                                    CssClass="table table-striped table-hover"
                                    OnRowCommand="gvdatos_RowCommand">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Descripción
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblNombre" Text='<%# Bind("MAR_DESCRIPCION") %>' Font-Size="XX-Small"
                                                    ToolTip='<%# Bind("MAR_DESCRIPCION") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="btnModificar" Text="Modificar" CausesValidation="false" runat="server"
                                                    CssClass="btn btn-info btn-sm" ValidationGroup="gisad"
                                                    CommandName="M" CommandArgument='<%# Bind("MAR_CODIGO") %>' />
                                                <asp:Button ID="btnEliminar" Text="Eliminar" runat="server" CssClass="btn btn-danger btn-sm"
                                                    CommandName="E" CausesValidation="false" OnClientClick="return confirm('Esta Seguro de Eliminar el resgistro?')"
                                                    CommandArgument='<%# Bind("MAR_CODIGO") %>' ValidationGroup="gisad" />
                                            </ItemTemplate>
                                            <ItemStyle Width="200px" HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
