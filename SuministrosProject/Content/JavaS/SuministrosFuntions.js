function redireccionarEdithSuministro(id) {
    window.location.href = '/Suministro/Edit/' + id;
}

function EditSuministro(_id) {
    $.ajax(
        {
            type: 'GET',
            url: '/Suministro/Edit',
            data: { id: _id },
            success: function (result) {
                $('#editSuministroBody').html(result);
                $('#EditSuministro').modal('show');
            },

            error: function (error) {
                // si hay un error lanzara el mensaje de error
                notificacioError('Error', 'Ocurrio un error desconocido, al comunicarse con el servidor');
            }
        });
}

function NewSuministroGet() {
    $.ajax(
        {
            type: 'GET',
            url: '/Suministro/Create',
            success: function (result) {
                $('#NewModalBody').html(result);
                $('#NewModal').modal('show');
            },
            error: function (error) {
                // si hay un error lanzara el mensaje de error
                notificacioError('Error', 'Ocurrio un error desconocido, al comunicarse con el servidor');
            }
        });

}

function GuardarSuministro() {
    var SerieSum = document.getElementById("serie").value;
    var ModeloSum = document.getElementById("modelosum").value;
    var NumeroParteSum = document.getElementById("numeroParte").value;
    var descriptionSum = document.getElementById("description").value;
    var observationSum = document.getElementById("observation").value;
    var idCategoriaSum = document.getElementById("idCategoria").value;
    $.ajax(
        {
            type: 'POST',
            url: '/Suministro/Create',
            data: {
                Serie: SerieSum,
                Modelo: ModeloSum,
                NumeroParte: NumeroParteSum,
                Descripcion: descriptionSum,
                Observacion: observationSum,
                IdCategoria: idCategoriaSum
            },
            success: function (result) {
                if (result == 'OK') {
                    $('#BodyPositive').html("Datos guardados con exito");
                    $('#idAlertPositive').modal('show');
                }
                else {
                    $('#BodyNegative').html(result);
                    $('#idAlertNegative').modal('show');
                }
            },
            error: function (error) {
                // si hay un error lanzara el mensaje de error
                notificacioError('Error', 'Ocurrio un error desconocido, al comunicarse con el servidor');
            }
        });
}

function DeleteSuministro(_id) {
    $.ajax(
        {
            type: 'POST',
            url: '/Suministro/Delete',
            data: { id: _id },
            success: function (result) {
                if (result == 'OK') {
                    $('#SuministroDeleteBodyPositive').html("Registro Eliminado");
                    $('#idAlertPositiveSuministroDelete').modal('show');
                }
                else {
                    $('#SuministroDeleteBodyNegative').html(result);
                    $('#idAlertNegativeSuministroDelete').modal('show');
                }
            },

            error: function (error) {
                // si hay un error lanzara el mensaje de error
                notificacioError('Error', 'Ocurrio un error desconocido, al comunicarse con el servidor');
            }
        });
}

function redireccionarIndex() {
    window.location.href = '/Suministro/Index';
}

