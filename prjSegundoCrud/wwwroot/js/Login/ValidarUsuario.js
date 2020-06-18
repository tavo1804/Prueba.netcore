$(document).ready(function ($) {

    $('#txtusuario').focus();
  

    $('#btnEntrar').on('click', function () {


        if ($('#txtusuario').val() != "" & $('#txtpassword').val() != "") {
            Validate($('#txtusuario').val(), $('#txtpassword').val());
        }
        else {

            Swal.fire(

                'Error',
                'Debe ingresar el Usuario y Password',
                'error'
            );

        }

    });

    function Validate(usuario, password) {

        var record = {
            NombreUsuario: usuario,
            Password: password

        };

        $.ajax({
            url: '/Login/GetUsuarios',
            async: false,
            type: 'POST',
            data: record,
            beforeSend: function (xhr, opts) {

            },
            complete: function () {

            },
            success: function (data) {

                if (data.status === true) {

                    window.location.href = "/Home/Index";

                }
                else if (data.status === false) {

                    Swal.fire(

                        'Error',
                        data.message,
                        'error'
                    );
                }

            },

            error: function (data) {

                Swal.fire(
                    'Error',
                    data.message,
                    'error'
                );

            }

        });
    }

});