<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Marcas.aspx.cs" Inherits="SwParqueadero.Mantenimiento.Marcas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3 class="panel-title">Ingreso Marcas</h3>
        </div>
        <div class="panel-body">

            <div class="row">
                <div class="col-md-4">
                    <div class="alert alert-dismissible alert-info">
                        <div class="form-group">
                            <label class="control-label" for="focusedInput">Descripción</label>
                            <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" placeholder="Ingrese Marca" />
                        </div>
                        <div class="panel-footer">
                            <asp:Button Text="Guardar" ID="btnGuardar" runat="server" CssClass="btn btn-primary" />
                            <asp:Button Text="Cancelar" ID="btbCancelar" runat="server" CssClass="btn btn-danger" />
                        </div>
                    </div>
                </div>
                <div class="col-md-8">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h3 class="panel-title">Listado de Marcas</h3>
                        </div>
                        <div class="panel-body">
                            <asp:GridView AutoGenerateColumns="false" runat="server" ID="grdListaProveedores"
                                CssClass="table table-striped table-hover" OnRowCommand="grdListaProveedores_RowCommand">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Descripción
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblNombre" Text='<%# Bind("MAR_DESCRIPCION") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button ID="btnModificar" Text="Modificar" runat="server" CssClass="btn btn-info btn-sm"
                                                CommandName="Editar" CommandArgument='<%# Bind("MAR_CODIGO") %>' />
                                            <asp:Button ID="btnEliminar" Text="Eliminar" runat="server" CssClass="btn btn-danger btn-sm"
                                                CommandName="Eliminar" CommandArgument='<%# Bind("MAR_CODIGO") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
