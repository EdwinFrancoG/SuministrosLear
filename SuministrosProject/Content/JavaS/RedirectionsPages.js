function redireccionarHome() {
    window.location.href = '/Home/Index'
}

function redireccionarPage(id) {
    window.location.href = '/DetallePo/Index/?idProdOrder=' + id
}


function redireccionarStock() {
    window.location.href = '/Stocks/Index'
}

function Cambiar_estado_a_pendiente(idPO) {
    window.location.href = '/DetallePo/cambiarEstadoAPendiente/?idPO=' + idPO
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