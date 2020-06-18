function validarcampos() {
    var identificacion;
    var nombre;
    var correo;
    var direccion;

    identificacion = document.getElementById("Identificacion").value;
    nombre = document.getElementById("Nombre").value;
    correo = document.getElementById("Correo").value;
    direccion = document.getElementById("Direccion").value;

    if (identificacion === "") {
        alert("Debe Ingresar la Identificacion del cliente");
        return false;

    }

    else if (nombre === "") {

        alert("Debe Ingresar el Nombre del Cliente");
        return false;
    }

    else if (correo === "") {

        alert("Debe Ingresar el Correo del cliente");
        return false;
    }

    else if (direccion === "") {

        alert("Debe Ingresar la Direccion del cliente");
        return false;
    }


}

