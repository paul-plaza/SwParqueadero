<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroUsuario.aspx.cs" Inherits="SwParqueadero.Login.RegistroUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <div class="row">
            <div class="col-md-2">
                </div>
            <div class="col-md-8">
                
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">Registro de Usuario</h3>
                    </div>
                    <div class="panel-body">
                        <div class="form-group">
                            <label for="inputEmail" class="col-lg-2 control-label">Nombres</label>
                            <div class="col-lg-10">
                                <input type="text" class="form-control" id="txtNombres" placeholder="Nombres">
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="inputEmail" class="col-lg-2 control-label">Apellidos</label>
                            <div class="col-lg-10">
                                <input type="text" class="form-control" id="txtApellidos" placeholder="Apellidos">
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="inputEmail" class="col-lg-2 control-label">Cédula</label>
                            <div class="col-lg-10">
                                <input type="text" class="form-control" id="txtCedula" placeholder="Cédula">
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="inputEmail" class="col-lg-2 control-label">Email</label>
                            <div class="col-lg-10">
                                <input type="email" class="form-control" id="txtCorreo" placeholder="Correo Eléctronico">
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="inputEmail" class="col-lg-2 control-label">Télefono</label>
                            <div class="col-lg-10">
                                <input type="text" class="form-control" id="txtTelefono" placeholder="Télefono">
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-2 control-label">Radios</label>
                            <div class="col-lg-10">
                                <div class="radio">
                                    <label>
                                        <input type="radio" name="optionsRadios" id="optionsRadios1" value="option1" checked="">
                                        Option one is this
                                    </label>
                                </div>
                                <div class="radio">
                                    <label>
                                        <input type="radio" name="optionsRadios" id="optionsRadios2" value="option2">
                                        Option two can be something else
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-10 col-lg-offset-2">
                                <button type="submit" class="btn btn-primary">Submit</button>
                            </div>
                        </div>
                    </div>
                </div>
                
            </div>

            <div class="col-md-2">
                </div>
        </div>
    </fieldset>
</asp:Content>
