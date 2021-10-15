function redireccionarHome() {
    window.location.href = '/Home/Index'
}

function redireccionarPage(id) {
    window.location.href = '/DetallePo/Index/?idProdOrder=' + id
}

function PageRedirection(url) {
    window.location.href = url;
}

function RedireccionarUser() {
    window.location.href = "/Usuario/Index"
}

function redirectEntradas() {
    window.location.href = "/Entrada/Index"
}

function redireccionarLocalizacion() {
    window.location.href = '/Localizacions/Index'
}

function redireccionarStock() {
    window.location.href = '/Stocks/Index'
}

function Cambiar_estado_a_pendiente(idPO) {
    window.location.href = '/DetallePo/cambiarEstadoAPendiente/?idPO=' + idPO
}

function Cambiar_estado_a_cerrada(idPO) {
    window.location.href = '/DetallePo/cambiarEstadoACerrada/?idPO=' + idPO
}


function redireccionarPO() {
    window.location.href = '/ProductOrder/Index'
}

function redireccionarCategorias() {
    window.location.href = '/Categorias/Index'
}


function redireccionarPerfil() {
    window.location.href = '/Perfils/Index'
}

function redireccionarSuministros() {
    window.location.href = '/Suministro/Index'
}

function redireccionarIndexPO() {
    window.location.href = '/ProductOrder/Index'
}

function IndexSalida() {
    window.location.href = '/Salida/Index'
}

function redireccionarLocation() {
    window.location.href = '/Localizacions/Index'
}

function redireccionarNumeroParte() {
    window.location.href = '/NumeroParte/Index'
}

function viewReportSalida() {
    window.location.href = '/Salida/viewReportSalida'
}

function ReportByNumberPart() {
    window.location.href = '/Salida/ReportByNumberPart'
}

function ReportByEquipment() {
    window.location.href = '/Salida/ReportByEquipment'
}
