function GuardarCategoria() {
    var Description = document.getElementById("des").value;
    var Observation = document.getElementById("obs").value;
    var State = document.getElementById("sta").value;
    $.ajax(
        {
            type: 'POST',
            url: '/Categorias/create',
            data: {
                CategoriaDescripcion: Description,
                Observacion: Observation,
                Estado: State
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

function NewCategoria() {
    $.ajax(
        {
            type: 'GET',
            url: '/Categorias/Create',
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

function redireccionarIndex() {
    window.location.href = '/Categorias/Index';
}
