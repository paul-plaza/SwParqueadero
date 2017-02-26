<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="appSisVen.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/Styles/css_login/animate.css" rel="stylesheet" type="text/css" />
    <link href="../Content/Styles/css_login/blueimp-gallery.min.css" rel="stylesheet" type="text/css" />
    <link href="../Content/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../Content/Styles/css_login/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="../Content/Styles/css_login/set.css" rel="stylesheet" type="text/css" />
    <link href="../Content/Styles/css_login/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="../Scripts/js_login/wow.min.js"></script>
    <script type="text/javascript" src="../Scripts/bootstrap.js"></script>
    <script type="text/javascript" src="../Scripts/js_login/touchSwipe.min.js"></script>
    <script type="text/javascript" src="../Scripts/js_login/script.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div id="contact" class="spacer">
        <div class="container contactform center">
            <div class="row wowload fadeInLeftBig">
                <div class="row">
                    <div class="col-md-4">
                    </div>
                    <div class="col-md-4 text-center center-block" style="text-align: center">
                        <div class="process">
                            <ul class="row text-center list-inline  wowload bounceInUp ">
                                <li class="effect-chico"><span>
                                    <img class="scrollpoint" src="../Content/Styles/images/people.png" alt="Index" height="80" width="80" /><b><strong>
                                        Inicio de Sesi&oacute;n</strong></b> </span></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                    </div>
                    <div class="col-md-4" style="">
                        <div class="form-group">
                            <label for="email">
                            </label>
                            <div class="input-group">
                                <span class="input-group-addon"><span class="glyphicon glyphicon-user"></span></span>
                                <input runat="server" type="text" style="font-size: 16px; font-family: Helvetica;"
                                    class="form-control" id="txtLogin" name="txtLogin" placeholder="Ingrese su Usuario"
                                    required="required" /></div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                    </div>
                    <div class="col-md-4" style="">
                        <div class="form-group">
                            <label for="email">
                            </label>
                            <div class="input-group">
                                <span class="input-group-addon"><span class="glyphicon glyphicon-lock"></span></span>
                                <input runat="server" autocomplete="false" type="password" style="font-size: 16px; font-family: Helvetica;"
                                    class="form-control" id="txtPassword" name="txtPassword" placeholder="Ingrese su Contraseña"
                                    required="required" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row text-center">
                    <div class="col-md-4">
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                                <%--<asp:Button runat="server" ID="btnAcceder" CssClass="btn btn-info" Text="Acceder al sistema" OnClientClick="btnAcceder_Click(); return false;"/>--%>
                            <asp:Button runat="server" ID="btnAcceder" CssClass="btn btn-info" Text="Acceder al sistema" OnClick="btnAcceder_Click1"  />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        </div>
    
    </form>
    <div class="footer text-center spacer">
        <p class="wowload flipInX">
            Copyright 2017 Parqueadero. Todos los derechos reservados.</p>
    </div>
</body>
</html>
