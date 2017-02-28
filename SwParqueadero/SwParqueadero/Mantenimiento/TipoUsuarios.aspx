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
                                CssClass="btn btn-default" OnClick="btnGuardar_Click"/>
                            <asp:Button Text="Cancelar" ID="btnCancelar" runat="server" CssClass="btn btn-primary" />
                        </div>
                    </div>
                </div>
                <div class="col-md-8">
                    <div class="panel panel-default">

                        <div class="panel-body">
                            <div class="table-responsive">
                                <asp:GridView AutoGenerateColumns="false" Font-Size="X-Small" runat="server" ID="gvdatos"
                                    CellSpacing="-1" CssClass="table table-condensed table-hover GridView1" OnRowCommand="gvdatos_RowCommand">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Descripción
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblNombre" Text='<%# Bind("TIPU_DESCRIPCION") %>' Font-Size="XX-Small"
                                                    ToolTip='<%# Bind("TIPU_DESCRIPCION") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                             <asp:LinkButton ID="btnModificar" Text="" CausesValidation="false" runat="server"
                                                    Font-Size="10pt" Style="text-decoration: none; color: yellowgreen"
                                                    CssClass="glyphicon glyphicon-pencil" ToolTip="Modificar"
                                                    CommandName="M" CommandArgument='<%# Bind("TIPU_CODIGO") %>' />
                                                <asp:LinkButton ID="btnEliminar" Text="" runat="server" CssClass="glyphicon glyphicon-remove"
                                                    ToolTip="Eliminar" Font-Size="10pt" Style="text-decoration: none; color: red"
                                                    CommandName="E" CausesValidation="false" OnClientClick="return confirm('Esta Seguro de Eliminar el registro?')"
                                                    CommandArgument='<%# Bind("TIPU_CODIGO") %>' />
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
</asp:Content>
