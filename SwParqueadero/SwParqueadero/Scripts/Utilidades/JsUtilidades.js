$(document).ready(function () {
    CrearEventos();
});

function CrearEventos() {
    //Funcion para limpiar todas las cajas de texto con el boton cancelar
    $("#MainContent_btnCancelar").on("click", function () {
        $('input[type=text]').each(function () {
            $(this).val('');
        });
        $('input[type=number]').each(function () {
            $(this).val('');
        });
        $('input[type=email]').each(function () {
            $(this).val('');
        });
        $('#MainContent_hfCodigo').attr('value', "0");
        $('#MainContent_hfCodigoUsuario').attr('value', "0");
        return false;
    });
}

var prm = Sys.WebForms.PageRequestManager.getInstance();

prm.add_endRequest(function () {
    CrearEventos();
});