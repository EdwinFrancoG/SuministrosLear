function NewLocation() {
    $.ajax(
        {
            type: 'GET',
            url: '/Localizacions/Create',
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

$(function () {
    $('#NewModal').on('shown.bs.modal', function (e) {
        $('.focus').focus();
    })
});

function SaveLocation() {
    var Description = document.getElementById("descriptionID").value;
    $.ajax(
        {
            type: 'POST',
            url: '/Localizacions/Create',
            data: {
                descripcion: Description
            },
            success: function (result) {
                if (result == 'OK') {
                    $('#BodyPositiveLocation').html("Datos guardados con exito");
                    $('#idAlertPositiveLocation').modal('show');
                }
                else {
                    $('#BodyNegativeLocation').html(result);
                    $('#idAlertNegativeLocation').modal('show');
                }
            },
            error: function (error) {
                // si hay un error lanzara el mensaje de error
                notificacioError('Error', 'Ocurrio un error desconocido, al comunicarse con el servidor');
            }
        });
}
