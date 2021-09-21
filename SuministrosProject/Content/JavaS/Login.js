
function validateLogin() {
    var user = document.getElementById("idUser").value;
    var pass = document.getElementById("pass").value;
    
    $.ajax(
        {
            type: 'POST',
            url: '/Login/Logear',
            data: {
                usuario: user,
                password: pass
            },
            success: function (result) {
                if (result == "OK") {                
                    sessionStorage.setItem("user", user);
                    sessionStorage.setItem("password", pass);

                    window.location.href = '/Home/Index';
                } else
                    if (result == "NoEncontrado") {                       
                        showError();
                        LoadError();
                    } else {
                        if (result == "NofoundInDB") {
                            var error = document.getElementById("error");
                            error.textContent = "Error, This user is not registered in Data Base, please contact the administrator"
                            error.style.color = "red"
                            LoadError();                       
                        }                 
                    }               
            },
            error: function (error) {
                // si hay un error lanzara el mensaje de error
                notificacioError('Error', 'This usser does no have permissions');
            }
        });
}


var elem = document.getElementById("pass");
elem.onkeyup = function (e) {
    if (e.keyCode == 13) {
        validateLogin();
    }
}

function LoadError() {
    setTimeout(function () {
        loadLogin()
    }, 5000);
}

function showError() {
    var error = document.getElementById("error");
    error.textContent = "Error, incorrect username and / or password"
    error.style.color = "red"
}

function loadLogin() {
    window.location.href = '/Login/LoginGet';
}

function LogOut() {
    sessionStorage.clear();
    loadLogin();
}