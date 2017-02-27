$(document).ready(function () {

    //Funcion para limpiar todas las cajas de texto con el boton cancelar
    $("#MainContent_btbCancelar").on("click", function () {
        $('input[type=text]').each(function () {
            $(this).val('');
        });
        $('#MainContent_hfCodigo').attr('value', "0");
        return false;
    });

    $('#Modal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget) // Button that triggered the modal
        var recipient = button.data('whatever') // Extract info from data-* attributes
        // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
        // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
        var modal = $(this)
        modal.find('.modal-title').text('New message to ' + recipient)
        modal.find('.modal-body input').val(recipient)
    })

});