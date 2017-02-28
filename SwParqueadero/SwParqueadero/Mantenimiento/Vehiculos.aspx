<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Vehiculos.aspx.cs" Inherits="SwParqueadero.Mantenimiento.Vehiculos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/CssModal.css" rel="stylesheet" />
    <hr />
    <div class="panel panel-info">
        <div class="panel-heading">
            <h2 class="panel-title"><em>Vehiculos Debe realizar una búsqueda inicialmente</em></h2>
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
                                <asp:RequiredFieldValidator ID="rfNombres" runat="server"
                                    ControlToValidate="txtNombres" Display="None"
                                    SetFocusOnError="true" ErrorMessage="Campo Nombre Requerido">*</asp:RequiredFieldValidator>
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
                                    <span class="input-group-addon" id="basic-addon13">Marca</span>
                                    <asp:DropDownList ID="ddlMarca"
                                        CssClass="btn btn-default dropdown-toggle col-md-12" AutoPostBack="true"
                                        aria-describedby="basic-addon13" runat="server"
                                        OnSelectedIndexChanged="ddlMarca_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <span class="input-group-addon" id="basic-addon14">
                                        <asp:LinkButton ID="lkRefrescarMarca" class="glyphicon glyphicon-refresh" Style="text-decoration: none"
                                            runat="server" CausesValidation="false"
                                            OnClick="lkRefrescarMarca_Click" /></span>
                                </div>
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
                                    <span class="input-group-addon" id="basic-addon8">Observaciones</span>
                                    <asp:TextBox runat="server" ID="txtObservaciones" TextMode="MultiLine" CssClass="form-control"
                                        MaxLength="50" aria-describedby="basic-addon1" />
                                </div>
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
                                            <asp:TextBox ID="txt_Buscar" placeholder="(Identificación)" runat="server"
                                                class="form-control"></asp:TextBox>
                                        </div>
                                        <asp:Button Text="Buscar" ID="btnBuscar" CssClass="btn btn-outline-success"
                                            CausesValidation="false" runat="server" OnClick="btnBuscar_Click" />
                                    </asp:Panel>
                                </div>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive" style="height: 270px">
                                <script>
                                    function ampliar(e) {
                                        var modal = document.getElementById('myModal');
                                        var modalImg = document.getElementById("img01");
                                        var captionText = document.getElementById("caption");
                                        modal.style.display = "block";
                                        modalImg.src = e.src;
                                        captionText.innerHTML = e.alt;
                                    }
                                    var span = document.getElementsByClassName("close")[0];
                                    span.onclick = function () {
                                        modal.style.display = "none";
                                    }
                                </script>

                                <asp:GridView AutoGenerateColumns="false" Font-Size="X-Small" runat="server" ID="gvdatos"
                                    CellSpacing="-1" CssClass="table table-condensed table-hover GridView1" AllowPaging="true"
                                    PageSize="5"
                                    OnRowCommand="gvdatos_RowCommand"
                                    OnPageIndexChanging="gvdatos_PageIndexChanging"
                                    OnRowDataBound="gvdatos_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <img id="myImg" onclick="ampliar(this)" runat="server" src="~/Archivos/Vehiculos/carro.jpg"
                                                    alt="vehiculo" width="35"
                                                    height="35">
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
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
                                                Modelo
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblDescripcionModelo" Text='<%# Eval("TBL_MODELO.MOD_DESCRIPCION") %>'
                                                    Font-Size="XX-Small"
                                                    ToolTip='<%# Eval("TBL_MODELO.MOD_DESCRIPCION") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Tamaño
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblTamanio" Text='<%# Eval("TBL_DIMENSION.DIM_DESCRIPCION") %>' Font-Size="XX-Small"
                                                    ToolTip='<%# Eval("TBL_DIMENSION.DIM_DESCRIPCION") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Observaciones
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
                                                    CommandName="E" CausesValidation="false" OnClientClick="return confirm('Esta Seguro de Eliminar el registro?')"
                                                    CommandArgument='<%# Bind("VEH_CODIGO") %>' />
                                            </ItemTemplate>
                                            <ItemStyle Width="100px" HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <div class="input-group">
                                <script>
                                    function myfunction() {
                                        var codigo = parseInt($('#MainContent_hfCodigoUsuario').val());
                                        if (codigo == 0) {
                                            alert('Debe seleccionar un registro antes de subir!');
                                            return false;
                                        }
                                    }

                                    function finalizar() {

                                    }

                                </script>
                                <ajaxToolkit:AjaxFileUpload ID="aFile" runat="server"
                                    ContextKeys="fred"
                                    AllowedFileTypes="jpg,jpeg"
                                    MaximumNumberOfFiles="1"
                                    OnUploadComplete="aFile_UploadComplete"
                                    OnClientUploadStart="myfunction" />
                                <span class="input-group-addon" id="basic-addon7">...</span>
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

    <div id="myModal" class="modal" style="z-index: 999999">
        <span class="close" onclick="document.getElementById('myModal').style.display='none'">
            &times;</span>
        <img class="modal-content" id="img01" height="250px" width="250px" >
        <div id="caption"></div>
    </div>
</asp:Content>


