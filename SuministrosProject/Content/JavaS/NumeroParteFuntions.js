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
                notificacioError('Error', 'Ocurrio un error desconocido, al comunicarse con el servidor');
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
                    $('#BodyPositiveNP').html("Datos guardados con exito");
                    $('#idAlertPositiveNP').modal('show');
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


$(function () {
    $('#NewModal').on('shown.bs.modal', function (e) {
        $('.focus').focus();
    })
});
