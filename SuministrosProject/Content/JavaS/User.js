function NewUser() {
    $.ajax(
        {
            type: 'GET',
            url: '/Usuario/Create',
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