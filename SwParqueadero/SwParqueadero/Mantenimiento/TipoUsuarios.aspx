<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TipoUsuarios.aspx.cs" Inherits="SwParqueadero.Mantenimiento.TipoUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <hr />
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Ingreso Tipo Usuarios</h3>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-4">
                    <div class="panel panel-default" data-toggle="validator">
                        <div class="panel-body ">
                            <asp:ValidationSummary runat="server" ID="ValidationSummary1"
                                DisplayMode="BulletList"
                                ShowMessageBox="False" ShowSummary="True" CssClass="alert alert-danger" />
                            <div class="input-group">
                                <span class="input-group-addon" id="basic-addon2">Descripción</span>
                                <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" placeholder="Ingrese tipo usuario"
                                    MaxLength="50" aria-describedby="basic-addon2" />
                                <asp:HiddenField runat="server" ID="hfCodigo" Value="0" />

                            </div>
                            <asp:RequiredFieldValidator ID="rfDescripcion" runat="server"
                                ControlToValidate="txtDescripcion" Display="None"
                                SetFocusOnError="true" ErrorMessage="Campo Requerido">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="panel-footer text-right">
                            <asp:Button Text="Guardar" ID="btnGuardar" runat="server"
                                CssClass="btn btn-default"/>
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
