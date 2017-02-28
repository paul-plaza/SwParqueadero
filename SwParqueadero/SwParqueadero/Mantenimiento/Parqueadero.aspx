<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Parqueadero.aspx.cs" Inherits="SwParqueadero.Mantenimiento.Parqueadero" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <hr />
    <div class="panel panel-info">
        <div class="panel-heading">
            <h2 class="panel-title"><em>Parqueadero</em></h2>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-4">
                    <asp:Panel runat="server" class="panel panel-default" DefaultButton="btnGuardar">
                        <div class="panel-body">
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="basic-addon1">Descripción</span>
                                    <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" placeholder="Ingrese Descripción"
                                        MaxLength="50" aria-describedby="basic-addon1" />
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                    ControlToValidate="txtDescripcion" Display="None"
                                    SetFocusOnError="true" ErrorMessage="Campo Descripción Requerido">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="basic-addon2">Dirección</span>
                                    <asp:TextBox runat="server" ID="txtDireccion" CssClass="form-control" placeholder="Ingrese Dirección"
                                        MaxLength="50" aria-describedby="basic-addon2" />
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ControlToValidate="txtDireccion" Display="None"
                                    SetFocusOnError="true" ErrorMessage="Campo Dirección Requerido">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="basic-addon3">Encargado</span>
                                    <asp:TextBox runat="server" ID="txtEncargado" CssClass="form-control" placeholder="Ingrese Nombre Encargado"
                                        MaxLength="50" aria-describedby="basic-addon3" />
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                    ControlToValidate="txtEncargado" Display="None"
                                    SetFocusOnError="true" ErrorMessage="Campo Encargado Requerido">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="basic-addon4">Telf. Encargado</span>
                                    <asp:TextBox runat="server" ID="txtTelefonoEncargado" CssClass="form-control" placeholder="Ingrese Teléfono Encargado" TextMode="Number" min="0"
                                        MaxLength="15" aria-describedby="basic-addon4" />
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                    ControlToValidate="txtTelefonoEncargado" Display="None"
                                    SetFocusOnError="true" ErrorMessage="Campo Teléfono Encargado Requerido">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="basic-addon5">Contacto 1</span>
                                    <asp:TextBox runat="server" ID="txtContacto1" CssClass="form-control" placeholder="Ingrese Nombre Contacto 1"
                                        MaxLength="50" aria-describedby="basic-addon5" />
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                    ControlToValidate="txtContacto1" Display="None"
                                    SetFocusOnError="true" ErrorMessage="Campo Contacto 1 Requerido">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="basic-addon6">Telf. Contacto 1</span>
                                    <asp:TextBox runat="server" ID="txtTelefonoContacto1" CssClass="form-control" placeholder="Ingrese Teléfono Contacto 1" TextMode="Number" min="0"
                                        MaxLength="15" aria-describedby="basic-addon6" />
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                    ControlToValidate="txtTelefonoContacto1" Display="None"
                                    SetFocusOnError="true" ErrorMessage="Campo Teléfono Contacto 1 Requerido">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="basic-addon7">Contacto 2</span>
                                    <asp:TextBox runat="server" ID="txtContacto2" CssClass="form-control" placeholder="Ingrese Nombre Contacto 2"
                                        MaxLength="50" aria-describedby="basic-addon7" />
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                    ControlToValidate="txtContacto2" Display="None"
                                    SetFocusOnError="true" ErrorMessage="Campo Teléfono Contacto 2 Requerido">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="basic-addon8">Telf. Contacto 2</span>
                                    <asp:TextBox runat="server" ID="txtTelefonoContacto2" CssClass="form-control" placeholder="Ingrese Teléfono Contacto 2" TextMode="Number" min="0"
                                        MaxLength="15" aria-describedby="basic-addon8" />
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                    ControlToValidate="txtTelefonoContacto2" Display="None"
                                    SetFocusOnError="true" ErrorMessage="Campo Teléfono Contacto 2 Requerido">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="basic-addon9">Puestos</span>
                                    <asp:TextBox runat="server" ID="txtPuestos" CssClass="form-control" placeholder="Ingrese Cantidad Puestos" TextMode="Number" min="0"
                                        MaxLength="50" aria-describedby="basic-addon9" />
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                    ControlToValidate="txtPuestos" Display="None"
                                    SetFocusOnError="true" ErrorMessage="Campo Puestos Requerido">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="panel-footer text-right">
                            <asp:Button Text="Guardar" ID="btnGuardar" runat="server"
                                CssClass="btn btn-default" OnClick="btnGuardar_Click"  />
                            <asp:Button Text="Cancelar" ID="btnCancelar" runat="server" CausesValidation="false"
                                CssClass="btn btn-primary" />
                        </div>
                    </asp:Panel>
                </div>
                <div class="col-md-8">
                    <div class="panel panel-default">
                        
                        <div class="panel-body">
                            <div class="table-responsive">
                                <asp:GridView AutoGenerateColumns="false" Font-Size="X-Small" runat="server" ID="gvdatos"
                                    CellSpacing="-1" CssClass="table table-condensed table-hover GridView1" AllowPaging="true"
                                    PageSize="5"
                                    OnPageIndexChanging="gvdatos_PageIndexChanging" OnRowCommand="gvdatos_RowCommand">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Nombre
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblDescripcio" Text='<%# Bind("PAR_DESCRIPCION") %>' Font-Size="XX-Small"
                                                    ToolTip='<%# Bind("PAR_DESCRIPCION") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Direccion
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblDireccion" Text='<%# Bind("PAR_DIRECCION") %>' Font-Size="XX-Small"
                                                    ToolTip='<%# Bind("PAR_DIRECCION") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Puesto
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblPuesto" Text='<%# Bind("PAR_PUESTOS") %>' Font-Size="XX-Small"
                                                    ToolTip='<%# Bind("PAR_PUESTOS") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Contacto 1
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblTelefono" Text='<%# Bind("PAR_TELEFONO") %>' Font-Size="XX-Small"
                                                    ToolTip='<%# Bind("PAR_TELEFONO") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Contacto 2
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblTelefono2" Text='<%# Bind("PAR_TELEFONO2") %>' Font-Size="XX-Small"
                                                    ToolTip='<%# Bind("PAR_TELEFONO2") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Contacto 3
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblTelefonoEncargado" Text='<%# Bind("PAR_TELEFONO_ENCARGADO") %>' Font-Size="XX-Small"
                                                    ToolTip='<%# Bind("PAR_TELEFONO_ENCARGADO") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnModificar" Text="" CausesValidation="false" runat="server"
                                                    Font-Size="10pt" Style="text-decoration: none; color: yellowgreen"
                                                    CssClass="glyphicon glyphicon-pencil" ToolTip="Modificar"
                                                    CommandName="M" CommandArgument='<%# Bind("PAR_CODIGO") %>' />
                                                <asp:LinkButton ID="btnEliminar" Text="" runat="server" CssClass="glyphicon glyphicon-remove"
                                                    ToolTip="Eliminar" Font-Size="10pt" Style="text-decoration: none; color: red"
                                                    CommandName="E" CausesValidation="false" OnClientClick="return confirm('Esta Seguro de Eliminar el registro?')"
                                                    CommandArgument='<%# Bind("PAR_CODIGO") %>' />
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
    <asp:HiddenField runat="server" ID="hfCodigo" Value="0" />
</asp:Content>

