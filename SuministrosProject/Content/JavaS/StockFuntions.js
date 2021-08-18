﻿function notificacionPrimary(title, text) {
    $.gritter.add({
        title: title,
        text: text,
        class_name: 'gritter-color primary',
        sticky: true,
        time: '1'
    });
    return false;
}

function notificacioError(title, text) {

    $.gritter.add({
        title: title,
        text: text,
        class_name: 'gritter-color danger',
        sticky: true,
        time: '1'
    });
    return false;

}

function guardarStock() {
    var idNParte = document.getElementById("IdNumeroParte").value;
    var StockInicial = document.getElementById("StockInitial").value;
    var pendietes = document.getElementById("idpendientes").value;
    $.ajax(
        {
            type: 'POST',
            url: '/Stocks/Create',
            data: {
                IdNumeroParte: idNParte,
                StockInicial: StockInicial,
                Pendientes: pendietes
            },
            success: function (result) {
                if (result == 'OK') {
                    $('#StockBodyPositive').html("Datos guardados con exito");
                    $('#idAlertPositive').modal('show');
                }
                else {
                    $('#StockBodyNegative').html(result);
                    $('#idAlertNegative').modal('show');
                }
            },
            error: function (error) {
                // si hay un error lanzara el mensaje de error
                //notificacioError('Error', 'Ocurrio un error desconocido, al comunicarse con el servidor');
            }
        });
}


function NewStock() {
    $.ajax(
        {
            type: 'GET',
            url: '/Stocks/Create',
            success: function (result) {
                $('#createStockBody').html(result);
                $('#CreateStock').modal('show');
            },
            error: function (error) {
                // si hay un error lanzara el mensaje de error
                notificacioError('Error', 'Ocurrio un error desconocido, al comunicarse con el servidor');
            }
        });

}


function DeleteStock(_id) {
    $.ajax(
        {
            type: 'POST',
            url: '/Stocks/Delete',
            data: { id: _id },
            success: function (result) {
                if (result == 'OK') {
                    $('#StockDeleteBodyPositive').html("Registro Eliminado");
                    $('#idAlertPositiveStockDelete').modal('show');
                }
                else {
                    $('#StockDeleteBodyNegative').html(result);
                    $('#idAlertNegativeStockDelete').modal('show');
                }      
            },

            error: function (error) {
                // si hay un error lanzara el mensaje de error
                notificacioError('Error', 'Ocurrio un error desconocido, al comunicarse con el servidor');
            }
        });
}


function redireccionarIndex() {
    window.location.href = '/Stocks/Index';
}

function redireccionarIndexStock() {
    window.location.href = '/Stocks/Index';
}

//$(document).ready(function () {
//    $('#Tabla-Stock').DataTable();
//});
