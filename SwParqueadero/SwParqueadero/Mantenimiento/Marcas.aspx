<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Marcas.aspx.cs" Inherits="SwParqueadero.Mantenimiento.Marcas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <hr />
    <div class="panel panel-info">
        <div class="panel-heading">
            <h2 class="panel-title"><em>Marcas de Vehiculos</em></h2>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-4">
                    <asp:Panel runat="server" class="panel panel-default" DefaultButton="btnGuardar">
                        <div class="panel-body">
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="basic-addon2">Descripción</span>
                                    <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" placeholder="Ingrese Marca"
                                        MaxLength="50" aria-describedby="basic-addon2" />
                                </div>
                                <asp:RequiredFieldValidator ID="rfDescripcion" runat="server"
                                    ControlToValidate="txtDescripcion" Display="None"
                                    SetFocusOnError="true" ErrorMessage="Campo Requerido">*</asp:RequiredFieldValidator>
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
                                    <asp:Panel ID="pnl_defbotonbuscar" runat="server" CssClass="form-inline col-md-12"
                                        DefaultButton="btnBuscar">
                                        <asp:TextBox ID="txt_BuscarActivo" placeholder="(Texto a buscar)" runat="server"
                                            class="form-control"></asp:TextBox>
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
                                                <asp:Label ID="lblNombre" Text='<%# Bind("MAR_DESCRIPCION") %>' Font-Size="XX-Small"
                                                    ToolTip='<%# Bind("MAR_DESCRIPCION") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnModificar" Text="" CausesValidation="false" runat="server"
                                                    Font-Size="10pt" Style="text-decoration: none; color: yellowgreen"
                                                    CssClass="glyphicon glyphicon-pencil" ToolTip="Modificar"
                                                    CommandName="M" CommandArgument='<%# Bind("MAR_CODIGO") %>' />
                                                <asp:LinkButton ID="btnEliminar" Text="" runat="server" CssClass="glyphicon glyphicon-remove"
                                                    ToolTip="Eliminar" Font-Size="10pt" Style="text-decoration: none; color: red"
                                                    CommandName="E" CausesValidation="false" OnClientClick="return confirm('Esta Seguro de Eliminar el resgistro?')"
                                                    CommandArgument='<%# Bind("MAR_CODIGO") %>' />
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
