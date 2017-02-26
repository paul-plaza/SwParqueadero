$(document).ready(function() {
   
    $("ctl00$MainContent$btbCancelar").on( "click", function LimpiarControles() {
        $('input[type=text]').each(function() {
            $(this).val('');
        });
    } );
});​