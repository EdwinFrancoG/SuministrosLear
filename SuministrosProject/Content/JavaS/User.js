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


function SaveUser() {
    var gafete = document.getElementById("idCreateBy").value;
    var name = document.getElementById("idName").value;
    var lastName = document.getElementById("idlastName").value;
    var user = document.getElementById("User").value;
    var Perfil = document.getElementById("idperfil").value;
    $.ajax(
        {
            type: 'POST',
            url: '/Usuario/create',
            data: {
                IdGafete: gafete,
                Nombre: name,
                Apellido: lastName,
                usuario: user,
                Estado: true,
                IdPerfil: Perfil
            },
            success: function (result) {
                if (result == 'OK') {
                    $('#BodyPositiveU').html("Data saved successfully");
                    $('#idAlertPositiveU').modal('show');
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
