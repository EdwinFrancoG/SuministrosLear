function GetCreateSalida() {
    $.ajax(
        {
            type: 'GET',
            url: '/Salida/Create',
            data: {
            },
            success: function (result) {
                $('#NewModalBodyS').html(result);
                $('#NewModalS').modal('show');
            },
            error: function (error) {
                // si hay un error lanzara el mensaje de error
                notificacioError('Error', 'Ocurrio un error desconocido, al comunicarse con el servidor');
            }
        });
}


function PostCrearSalida() {
    var EquipoID = document.getElementById("EquipoID").value;
    var serieID = document.getElementById("SerieID").value;
    $.ajax(
        {
            type: 'POST',
            url: '/Salida/Create',
            data: {
                idEquipo: EquipoID,
                serieSuministroID: serieID
            },
            success: function (result) {
                if (result == 'OK') {
                    $('#BodyPositiveSalida').html("Datos guardados con exito");
                    $('#idAlertPositiveSalida').modal('show');
                }
                else {
                    $('#BodyNegativeS').html(result);
                    $('#idAlertNegativeS').modal('show');
                }
            },
            error: function (error) {
                // si hay un error lanzara el mensaje de error
                notificacioError('Error', 'Ocurrio un error desconocido, al comunicarse con el servidor');
            }
        });
}