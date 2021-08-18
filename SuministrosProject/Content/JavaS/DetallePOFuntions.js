
function mostrarDetallePO(idPO) {
    var IDProdOrder = idPO;

    $.ajax({
        type: 'GET',
        url: '/DetallePo/Create',
        data: {
            idProdOrder: IDProdOrder
        },
        success: function (result) {
            $('#NewModalBodyDetPO').html(result);
            $('#NewModalDetPO').modal('show');
        },
        error: function (req, status, error) {
            alert("Error en el servidor"); 
        }
    });
}

function GuardarDetallePO() {
    var productOrderID = document.getElementById("IdproductOrderDet").value;
    var numberParteInput = document.getElementById("idNumberPart").value;
    var cantidadPedidoInput = document.getElementById("idCantidadPedido").value;
    var observacionInput = document.getElementById("idObservacionDPO").value;
    
    $.ajax(
        {
            type: 'POST',
            url: '/DetallePo/Create',
            data: {
                IdNumeroParte: numberParteInput,
                cantidadPedido: cantidadPedidoInput,
                Observacion: observacionInput,
                IdProductOrder: productOrderID
            },
            success: function (result) {
                if (result == 'OK') {
                    $('#BodyDetPO').html("Datos guardados con exito");
                    $('#DeteallePO').modal('show');
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


function deleteDetallePo(id) {
    $.ajax({
        type: 'GET',
        url: '/DetallePo/Delete',
        data: {
            id: id
        },
        success: function (result) {
            $('#NewModalBodyDetPO').html(result);
            $('#NewModalDetPO').modal('show');
        },
        error: function (req, status, error) {
            alert("Error en el servidor");
        }
    });
}

function cargarVista(urlAccion, idmostrar) {
    $.ajax(
        {
            type: 'GET',
            dataType: 'html', //el tipo de dato que nos regresara el servidor en este caso regresa html
            url: urlAccion,
            //URL del action result que cargara la vista parcial
            success: function (result) {
                //cuando se ejecuta bien la funcion agregara al div vistaParcial el contenido
                //que recibio del servidor
                $("#" + idmostrar).html(result);
            },
            error: function (error) {
                // si hay un error lanzara el mensaje de error
                $("#" + idmostrar).html(error);
            }
        });

}