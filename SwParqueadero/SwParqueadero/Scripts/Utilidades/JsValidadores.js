$('#formValidar').bootstrapValidator({
    message: 'Este valor no es valido',
    feedbackIcons: {

        valid: 'glyphicon glyphicon-ok',

        invalid: 'glyphicon glyphicon-remove',

        validating: 'glyphicon glyphicon-refresh'

    },

    fields: {

        ctl00$MainContent$txtDescripcion: {

            validators: {

                notEmpty: {

                    message: 'El nombre es requerido'

                }

            }

        },
    }
});