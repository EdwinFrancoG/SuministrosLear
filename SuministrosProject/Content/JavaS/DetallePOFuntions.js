
function mostrarDetallePO(idPO) {
    var idProdOrder = idPO;

    $.ajax({
        type: 'GET',
        url: '/DetallePo/Index',
        data: {
            idProdOrder: idProdOrder
        }, success: function (result) {
            // do something with result
        },
        error: function (req, status, error) {
            alert("Error en el servidor"); 
        }
    });
}