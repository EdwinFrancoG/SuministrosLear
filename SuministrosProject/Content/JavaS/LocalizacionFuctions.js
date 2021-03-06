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
                notificacioError('Error', 'An unknown error occurred, communicating with the server');
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
                    $('#BodyPositiveLocation').html("Data saved successfully");
                    $('#idAlertPositiveLocation').modal('show');
                }
                else {
                    $('#BodyNegativeLocation').html(result);
                    $('#idAlertNegativeLocation').modal('show');
                }
            }
        });
}

function EditLocation(_id) {
    $.ajax(
        {
            type: 'GET',
            url: '/Localizacions/Edit',
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

function DeleteLocation(_id) {
    $.ajax(
        {
            type: 'GET',
            url: '/Localizacions/Delete',
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
