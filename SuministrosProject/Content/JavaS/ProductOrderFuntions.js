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
                notificacioError('Error', 'Ocurrio un error desconocido, al comunicarse con el servidor');
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
                    $('#BodyPositivePO').html("Datos guardados con exito");
                    $('#idAlertPositivePO').modal('show');
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