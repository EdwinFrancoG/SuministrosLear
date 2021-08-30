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

