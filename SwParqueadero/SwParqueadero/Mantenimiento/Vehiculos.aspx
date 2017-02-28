<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Vehiculos.aspx.cs" Inherits="SwParqueadero.Mantenimiento.Vehiculos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <hr />
    <div class="panel panel-info">
        <div class="panel-heading">
            <h2 class="panel-title"><em>Vehiculos</em></h2>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-4">
                    <asp:Panel runat="server" class="panel panel-default" DefaultButton="btnGuardar">
                        <div class="panel-body">
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="basic-addon10">Identificación</span>
                                    <asp:TextBox runat="server" ID="txtIdentificacion" CssClass="form-control" disabled
                                        aria-describedby="basic-addon10" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="basic-addon11">Nombres</span>
                                    <asp:TextBox runat="server" ID="txtNombres" CssClass="form-control" disabled aria-describedby="basic-addon11" />
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                    ControlToValidate="txtPlaca" Display="None"
                                    SetFocusOnError="true" ErrorMessage="Campo Placa Requerido">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="basic-addon1">Placa</span>
                                    <asp:TextBox runat="server" ID="txtPlaca" CssClass="form-control" placeholder="Ingrese Placa"
                                        MaxLength="50" aria-describedby="basic-addon1" />
                                </div>
                                <asp:RequiredFieldValidator ID="rfPlaca" runat="server"
                                    ControlToValidate="txtPlaca" Display="None"
                                    SetFocusOnError="true" ErrorMessage="Campo Placa Requerido">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="basic-addon3">Modelo</span>
                                    <asp:DropDownList ID="ddlModelo" CssClass="btn btn-default dropdown-toggle col-md-12"
                                        aria-describedby="basic-addon3" runat="server">
                                    </asp:DropDownList>
                                    <span class="input-group-addon" id="basic-addon4">
                                        <asp:LinkButton ID="lkRefrescarModelo" class="glyphicon glyphicon-refresh" Style="text-decoration: none"
                                            runat="server" OnClick="lkRefrescar_Click" CausesValidation="false" /></span>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="basic-addon5">Tamaño</span>
                                    <asp:DropDownList ID="ddlDimensiones" CssClass="btn btn-default dropdown-toggle col-md-12"
                                        aria-describedby="basic-addon3" runat="server">
                                    </asp:DropDownList>
                                    <span class="input-group-addon" id="basic-addon6">
                                        <asp:LinkButton ID="lkRefrescarDimensiones"
                                            class="glyphicon glyphicon-refresh" Style="text-decoration: none"
                                            runat="server" OnClick="lkRefrescarDimensiones_Click"
                                            CausesValidation="false" /></span>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="input-group">
                                    <asp:FileUpload ID="fuImagen" CssClass="btn btn-default" runat="server" />
                                    <span class="input-group-addon" id="basic-addon7">.png</span>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="basic-addon8">Observaciones</span>
                                    <asp:TextBox runat="server" ID="txtObservaciones" TextMode="MultiLine" CssClass="form-control"
                                        MaxLength="50" aria-describedby="basic-addon1" />
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ControlToValidate="txtPlaca" Display="None"
                                    SetFocusOnError="true" ErrorMessage="Campo Placa Requerido">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="panel-footer text-right">
                            <asp:Button Text="Guardar" ID="btnGuardar" runat="server"
                                CssClass="btn btn-default" OnClick="btnGuardar_Click" />
                            <asp:Button Text="Cancelar" ID="btnCancelar" runat="server" CausesValidation="false"
                                CssClass="btn btn-primary" />
                        </div>
                    </asp:Panel>
                </div>
                <div class="col-md-8">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-md-12 text-right">
                                    <asp:Panel ID="pnUsuario" runat="server" CssClass="form-inline col-md-12"
                                        DefaultButton="btnBuscar">
                                        <div class="input-group">
                                            <span class="input-group-addon" id="basic-addon12"><em>Buscar Usuario</em></span>
                                            <asp:TextBox ID="txt_BuscarActivo" placeholder="(Identificación)" runat="server"
                                                class="form-control"></asp:TextBox>
                                        </div>
                                        <asp:Button Text="Buscar" ID="btnBuscar" CssClass="btn btn-outline-success"
                                            CausesValidation="false" runat="server" OnClick="btnBuscar_Click" />
                                        <asp:Button ID="btn_BuscarTodosActivo" runat="server" CausesValidation="False" class="btn btn-primary"
                                            Text="Todos" ToolTip="Mostrar Todos"
                                            OnClick="btn_BuscarTodosActivo_Click" />
                                    </asp:Panel>
                                </div>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                                <asp:GridView AutoGenerateColumns="false" Font-Size="X-Small" runat="server" ID="gvdatos"
                                    CellSpacing="-1" CssClass="table table-condensed table-hover GridView1" AllowPaging="true"
                                    PageSize="5"
                                    OnRowCommand="gvdatos_RowCommand"
                                    OnPageIndexChanging="gvdatos_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Descripción
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblNombre" Text='<%# Bind("VEH_PLACA") %>' Font-Size="XX-Small"
                                                    ToolTip='<%# Bind("VEH_PLACA") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Marca
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblDescripcion" Text='<%# Bind("VEH_OBSERVACION") %>' Font-Size="XX-Small"
                                                    ToolTip='<%# Bind("VEH_OBSERVACION") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnModificar" Text="" CausesValidation="false" runat="server"
                                                    Font-Size="10pt" Style="text-decoration: none; color: yellowgreen"
                                                    CssClass="glyphicon glyphicon-pencil" ToolTip="Modificar"
                                                    CommandName="M" CommandArgument='<%# Bind("VEH_CODIGO") %>' />
                                                <asp:LinkButton ID="btnEliminar" Text="" runat="server" CssClass="glyphicon glyphicon-remove"
                                                    ToolTip="Eliminar" Font-Size="10pt" Style="text-decoration: none; color: red"
                                                    CommandName="E" CausesValidation="false" OnClientClick="return confirm('Esta Seguro de Eliminar el resgistro?')"
                                                    CommandArgument='<%# Bind("VEH_CODIGO") %>' />
                                            </ItemTemplate>
                                            <ItemStyle Width="200px" HorizontalAlign="Center"></ItemStyle>
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
    <asp:HiddenField runat="server" ID="hfCodigoUsuario" Value="0" />
</asp:Content>


