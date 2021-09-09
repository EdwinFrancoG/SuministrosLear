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
                $('#NewModalBody').html(result);
                $('#NewModal').modal('show');
            },

            error: function (error) {
                // si hay un error lanzara el mensaje de error
                notificacioError('Error', 'An unknown error occurred, communicating with the server');
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
                notificacioError('Error', 'An unknown error occurred, communicating with the server');
            }
        });

}

function GuardarSuministro() {
    var SerieSum = document.getElementById("serie").value;
    var NumeroParteSum = document.getElementById("IdNumeroParte").value;
    var localizacion = document.getElementById("idLocalizacionSum").value;  
    var estado = true;

    $.ajax(
        {
            type: 'POST',
            url: '/Suministro/Create',
            data: {
                Serie: SerieSum,
                IdNumeroParte: NumeroParteSum,
                IdLocalizacion: localizacion,
                Estado: estado
            },
            success: function (result) {
                if (result == 'OK') {
                    $('#BodyPositive').html("Data saved successfully");
                    $('#idAlertPositive').modal('show');
                }
                else {
                    $('#BodyNegative').html(result);
                    $('#idAlertNegative').modal('show');
                }
            },
            error: function (error) {
                // si hay un error lanzara el mensaje de error
                notificacioError('Error', 'An unknown error occurred, communicating with the server');
            }
        });
}

//get de eliminar
function GetDeleteSuministro(idsum) {
    $.ajax(
        {
            type: 'GET',
            url: '/Suministro/Delete',
            data: {
                id: idsum
            },
            success: function (result) {
                $('#NewModalBody').html(result);
                $('#NewModal').modal('show');
            },
            error: function (error) {
                // si hay un error lanzara el mensaje de error
                notificacioError('Error', 'An unknown error occurred, communicating with the server');
            }
        });

}

function postDeleteSuministro(_id) {
    $.ajax(
        {
            type: 'POST',
            url: '/Suministro/Delete',
            data: { id: _id },
            success: function (result) {
                if (result == 'OK') {
                    $('#SuministroDeleteBodyPositive').html("Record Deleted");
                    $('#idAlertPositiveSuministroDelete').modal('show');
                }
                else {
                    $('#BodyNegative').html(result);
                    $('#idAlertNegative').modal('show');
                }
            },

            error: function (error) {
                // si hay un error lanzara el mensaje de error
                notificacioError('Error', 'An unknown error occurred, communicating with the server');
            }
        });
}

function redireccionarIndex() {
    window.location.href = '/Suministro/Index';
}

