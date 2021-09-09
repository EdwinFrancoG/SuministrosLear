function NewNumberPart() {
    $.ajax(
        {
            type: 'GET',
            url: '/NumeroParte/Create',
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


function SaveNumberPart() {
    var DescriptionNP = document.getElementById("idDescriptionNP").value;
    var ModelNP = document.getElementById("ModelNP").value;
    var BrandNP = document.getElementById("BrandNP").value;
    var TypeNP = document.getElementById("TypeNP").value;
    var ObservationNP = document.getElementById("ObservationNP").value;
    $.ajax(
        {
            type: 'POST',
            url: '/NumeroParte/create',
            data: {
                Descripcion: DescriptionNP,
                Modelo: ModelNP,
                Marca: BrandNP,
                IdCategoria: TypeNP,
                Observacion: ObservationNP
            },
            success: function (result) {
                if (result == 'OK') {
                    $('#BodyPositiveNP').html("Data saved successfully");
                    $('#idAlertPositiveNP').modal('show');
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


$(function () {
    $('#NewModal').on('shown.bs.modal', function (e) {
        $('.focus').focus();
    })
});


function EditNumeroParte(_id) {
    $.ajax(
        {
            type: 'GET',
            url: '/NumeroParte/Edit',
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



//get de eliminar
function GetDeleteNumeroParte(idNP) {
    $.ajax(
        {
            type: 'GET',
            url: '/NumeroParte/Delete',
            data: {
                id: idNP
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

function postDeleteNumeroParte(_id) {
    $.ajax(
        {
            type: 'POST',
            url: '/NumeroParte/Delete',
            data: { id: _id },
            success: function (result) {
                if (result == 'OK') {
                    $('#BodyPositiveNP').html("Record Deleted");
                    $('#idAlertPositiveNP').modal('show');
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
