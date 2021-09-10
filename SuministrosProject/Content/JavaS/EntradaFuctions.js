function GetCreateEntrada(IdNumeroParte, idPO) {
    var numeroParte = IdNumeroParte;
    var productOrder = idPO;
    $.ajax(
        {
            type: 'GET',
            url: '/Entrada/CreateEntrada',
            data: {
                numeroDeParte: numeroParte,
                idPO: productOrder
            },
            success: function (result) {
                $('#createBodyEntrada').html(result);
                $('#CreateEntrada').modal('show');               
            },
            error: function (error) {
                // si hay un error lanzara el mensaje de error
                notificacioError('Error', 'Ocurrio un error desconocido, al comunicarse con el servidor');
            }
        });
}


var elem = document.getElementById("serieSum");
elem.onkeyup = function (e) {
    if (e.keyCode == 13) {
        PostCrearEntrada();
    }
}


$(function () {
    $('#CreateEntrada').on('shown.bs.modal', function (e) {
        $('.focus').focus();
    })
});

$('#newEntry').on("click", function () {
    $('#serieSum').val('');
});


function PostCrearEntrada() {
    var serie = document.getElementById("serieSum").value;
    var idNumeroParte = document.getElementById("IdnumeroParte").value;
    var IdProductO = document.getElementById("IdProductO").value;
    var localizacion = document.getElementById("idLocalizacion").value;
    
    $.ajax(
        {
            type: 'POST',
            url: '/Entrada/Create',
            data: {
                SerieSuministro: serie,
                numeroParte: idNumeroParte,
                idPO: IdProductO,
                IdLocalizacion: localizacion
            },
            success: function (result) {
                if (result == 'OK') {
                    $('#BodyPositiveEntrada').html("Datos guardados con exito");
                    $('#idAlertPositiveEntrada').modal('show');
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
