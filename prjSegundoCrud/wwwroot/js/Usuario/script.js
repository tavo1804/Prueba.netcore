
function validarcampos() {
    var identificacion;
    var nombre;
    var apellido;
    var correo;
    var user;
    var pass;
    var rol;

    identificacion = document.getElementById("Identificacion").value;
    nombre = document.getElementById("Nombre").value;
    apellido = document.getElementById("Apellido").value;
    correo = document.getElementById("Correo").value;
    user = document.getElementById("User").value;
    pass = document.getElementById("Pass").value;
    rol = document.getElementById("cboRol");
 

    if (identificacion === "") {
        alert("Debe Ingresar la Identificacion del Usuario");
        return false;

    }

    else if (nombre === "") {

        alert("Debe Ingresar el Nombre del Usuario");
        return false;
    }

    else if (apellido === "") {

        alert("Debe Ingresar el Apellido del Usuario");
        return false;
    }

    else if (correo === "") {

        alert("Debe Ingresar el Correo del Usuario");
        return false;
    }

    else if (user === "") {

        alert("Debe Ingresar el Usuario");
        return false;
    }

    else if (pass === "") {

        alert("Debe Ingresar el Password");
        return false;
    }


    else if (rol.value === "" || rol.value === 0) {
  
        alert("Debe Seleccionar un Rol para el Usuario");
        return false;
    }


}







//$(document).ready(function () {

//    CargarCombo();

//});

//function CargarCombo() {

//    // Obtenemos el id del usuario
//    var Id;
//    var modificador;
//    var retorno = "";
//    Id = document.getElementById("idcliente").value;
//    $.ajax({

//        type: "GET",
//        url: 'Usuario/FiltraUsurioRol',
//        data: { id: Id },
//        dataType: "json",
//        success: function (response) {

//            $.each(response, function (key, registro2) {
//                iddefecto = registro2.rolid;
//            });

//            $.ajax({

//                type: "GET",
//                url:'Usuario/ObtenerRol',
//                dataType: "json",
//                success: function (data) {

//                    retorno += "<option value=' '>--Seleccione el Rol--</option>";

//                    $.each(data, function (key, registro) {

//                        id = registro.id;
//                        nombrerol = registro.nombre;


//                        if (id == iddefecto) {

//                            modificador = "selected='selected'";
//                        }

//                        else {
//                            modificador = "";
//                        }

//                       retorno += "<option " + modificador + " value='" + id + "'>";
//                        retorno += nombrerol;
//                        retorno += "</option>";

//                    });

//                    $("#cboRol").append(retorno);
//                }
//            });

//        }

//    });
//}

