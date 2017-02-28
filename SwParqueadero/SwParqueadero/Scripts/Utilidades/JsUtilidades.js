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

    var modal = document.getElementById('myModal');

    var img = document.getElementById('myImg');
    var modalImg = document.getElementById("img01");
    var captionText = document.getElementById("caption");
    
    img.onclick = function () {
        modal.style.display = "block";
        modalImg.src = this.src;
        captionText.innerHTML = this.alt;
    }

    var span = document.getElementsByClassName("close")[0];

    span.onclick = function () {
        modal.style.display = "none";
    }


}

var prm = Sys.WebForms.PageRequestManager.getInstance();

prm.add_endRequest(function () {
    CrearEventos();
});