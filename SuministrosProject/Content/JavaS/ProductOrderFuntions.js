function NewPO() {
    $.ajax(
        {
            type: 'GET',
            url: '/ProductOrder/Create',
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

function GuardarPO() {
    var Code = document.getElementById("idCodigo").value;
    var Req = document.getElementById("idRequisicion").value;
    var Description = document.getElementById("idDescripcion").value;
    var Gafete = document.getElementById("idGafete").value;
    $.ajax(
        {
            type: 'POST',
            url: '/ProductOrder/create',
            data: {
                Descripcion: Description,
                Codigo: Code,
                Requisicion: Req,
                IdGafete: Gafete
            },
            success: function (result) {
                if (result == 'OK') {
                    $('#BodyPositivePO').html("Data saved successfully");
                    $('#idAlertPositivePO').modal('show');
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

function DeletePO(_id) {
    $.ajax(
        {
            type: 'GET',
            url: '/ProductOrder/Delete',
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
