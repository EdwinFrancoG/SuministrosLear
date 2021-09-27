function GuardarCategoria() {
    var Description = document.getElementById("des").value;
    var Observation = document.getElementById("obs").value;
    $.ajax(
        {
            type: 'POST',
            url: '/Categorias/create',
            data: {
                CategoriaDescripcion: Description,
                Observacion: Observation
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

$(function () {
    $('#NewModal').on('shown.bs.modal', function (e) {
        $('#des').focus();
    })
});


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
                notificacioError('Error', 'An unknown error occurred, communicating with the server');
            }
        });

}

function EditCat(_id) {
    $.ajax(
        {
            type: 'GET',
            url: '/Categorias/Edit',
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

function DeleteCat(_id) {
    $.ajax(
        {
            type: 'GET',
            url: '/Categorias/Delete',
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


function redireccionarIndex() {
    window.location.href = '/Categorias/Index';
}
