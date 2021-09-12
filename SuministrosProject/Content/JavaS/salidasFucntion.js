function GetCreateSalida() {
    $.ajax(
        {
            type: 'GET',
            url: '/Salida/Create',
            data: {
            },
            success: function (result) {
                $('#NewModalBodyS').html(result);
                $('#NewModalS').modal('show');
            },
            error: function (error) {
                // si hay un error lanzara el mensaje de error
                notificacioError('Error', 'Ocurrio un error desconocido, al comunicarse con el servidor');
            }
        });
}

$(function () {
    $('#NewModalS').on('shown.bs.modal', function (e) {
        $('.focus').focus();
    })
});

var elem = document.getElementById("SerialNumber");
elem.onkeyup = function (e) {
    if (e.keyCode == 13) {
        PostCrearSalida();
    }
}



function PostCrearSalida() {
    var EquipoID = document.getElementById("EquipoID").value;
    var serieID = document.getElementById("SerialNumber").value;
    $.ajax(
        {
            type: 'POST',
            url: '/Salida/Create',
            data: {
                idEquipo: EquipoID,
                serieSuministroID: serieID
            },
            success: function (result) {
                if (result == 'OK') {
                    $('#BodyPositiveSalida').html("Datos guardados con exito");
                    $('#idAlertPositiveSalida').modal('show');
                }
                else {
                    $('#BodyNegativeS').html(result);
                    $('#idAlertNegativeS').modal('show');
                }
            },
            error: function (error) {
                // si hay un error lanzara el mensaje de error
                notificacioError('Error', 'Ocurrio un error desconocido, al comunicarse con el servidor');
            }
        });
}

$("#BotonLimpiar").on("click", function () {
    $('#SerialNumber').val('');
});

$("#clearDate").on("click", function () {
    $('#IdStartDate').val('');
    $('#IdEndDate').val('');
});

function reporteSalidaGet() {
    window.location.href = '/Salida/ReportSalidas'
}


function GenerarReporteConsumo() {
    var _startDate = document.getElementById("IdStartDate").value;
    var _endDate = document.getElementById("IdEndDate").value;
    $.ajax(
        {
            type: 'GET',
            dataType: 'html', //el tipo de dato que nos regresara el servidor en este caso regresa html
            url: '/Salida/ReportSalidas',
            data: {
                startDate: _startDate, //variables que recibe el metodo del controlador
                endDate: _endDate
            },
            success: function (result) {
                $("#idReportSalida").html(result);
            },
            error: function (error) {
                $("#idReportSalida").html(error);
            }
        });
}

function GenerarReporteConsumoPorNumeroParte() {
    var _startDate = document.getElementById("IdStartDate").value;
    var _endDate = document.getElementById("IdEndDate").value;
    var NPart = document.getElementById("IdNumberPart").value;
    $.ajax(
        {
            type: 'GET',
            dataType: 'html', //el tipo de dato que nos regresara el servidor en este caso regresa html
            url: '/Salida/ReportSalidas',
            data: {
                startDate: _startDate, //variables que recibe el metodo del controlador
                endDate: _endDate,
                numberPart: NPart
            },
            success: function (result) {
                $("#idReportSalida").html(result);
            },
            error: function (error) {
                $("#idReportSalida").html(error);
            }
        });
}

function GenerarReporteConsumoPorEquipo() {
    var _startDate = document.getElementById("IdStartDate").value;
    var _endDate = document.getElementById("IdEndDate").value;
    var _equipment = document.getElementById("IdEquipment").value;
    $.ajax(
        {
            type: 'GET',
            dataType: 'html', //el tipo de dato que nos regresara el servidor en este caso regresa html
            url: '/Salida/ReportSalidas',
            data: {
                startDate: _startDate, //variables que recibe el metodo del controlador
                endDate: _endDate,
                equipment: _equipment
            },
            success: function (result) {
                $("#idReportSalida").html(result);
            },
            error: function (error) {
                $("#idReportSalida").html(error);
            }
        });
}
