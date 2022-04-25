//cargar datos en tabla
$(document).ready(function () {
    tabla_usuario = $('#table_id').DataTable();
//abrir modal
    $('#editModal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget)
        var recipient = button.data('whatever')
        var modal = $(this)
        modal.find('.modal-title').text('New message to ' + recipient)
        modal.find('.modal-body input').val(recipient)
    })
    $('#createModal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget)
        var recipient = button.data('whatever')
        var modal = $(this)
        modal.find('.modal-title').text('New message to ' + recipient)
        modal.find('.modal-body input').val(recipient)
    })
});

////llenar formulario para editar
//function llenarFormulario(id) {
//    var data = document.getElementById(id);
//    console.log(data);
//    var prueba = id;
//    document.getElementById('IDAUTOR').value = prueba;
//    document.getElementById('NOMBRE').value = data.childNodes[3].innerText;
//    document.getElementById('FECHANACI').value = data.childNodes[5].innerText;
//    document.getElementById('CIUDAD').value = data.childNodes[7].innerText;
//    document.getElementById('CORREO').value = data.childNodes[9].innerText;
    
//};

//Limpiar formularios

function limpiarFormulario() {
    document.getElementById("formCreateAutor").reset();
}

//Funcion crear autor
function crearautor(e, v) {
    var data1 = {
        "idautor": 10,
        "nombre": $("#nombre").val(),
        "fechanaci": $("#fechanaci").val(),
        "ciudad": $("#ciudad").val(),
        "correo": $("#correo").val()
    };
    if ($("#nombre").val() == "") {
        alert("¡El campo nombre no puede estar vacío!.");
        $("#nombre").focus();
        return false;
    } else {
        let xhr = new XMLHttpRequest();
        let url = "https://localhost:44390/api/Autor/GuardarAutor";
        xhr.open("POST", url, true);
        xhr.setRequestHeader("Content-Type", "application/json");
        xhr.onreadystatechange = function () {
            if (xhr.response === "success" && xhr.status === 200) {
                //result.innerHTML = this.responseText;
                    swal("¡Éxito!", "¡Se guardo correctamente el autor!", "success", {
                        timer: 5000,
                        buttons: false,
                    });

            }else{
                swal("¡Error!", "¡No se pudo guardar el autor!", "error", {
                    timer: 5000,
                    buttons: false,
                });
            };

            limpiarFormulario();
        };
        var data = JSON.stringify({
            data1       
        });
        xhr.send(data);
    }

};

//Funcion crear libro
function crearlibro(e, v) {
    var data1 = {
        "idautor": 10,
        "titulo": $("#titulo").val(),
        "ano": $("#ano").val(),
        "genero": $("#genero").val(),
        "numpag": $("#numpag").val(),
        "autor": $("#autor").val()
    };
    if ($("#autor").val() == "") {
        alert("¡El campo autor no puede estar vacío!.");
        $("#autor").focus();
        return false;
    } else {
        let xhr = new XMLHttpRequest();
        let url = "https://localhost:44390/api/Libro/GuardarLibro";
        xhr.open("POST", url, true);
        xhr.setRequestHeader("Content-Type", "application/json");
        xhr.onreadystatechange = function () {
            if (xhr.response != "" && xhr.status === 200) {
                swal("¡Éxito!", "¡Se guardo correctamente el libro !", "success", {
                    timer: 5000,
                    buttons: false,
                });
            }else {
                swal("¡Error!", "¡No se pudo guardar el libro puede ser por: 1. No es posible registrar el libro, se alcanzó el máximo permitido!, 2.El autor no está registrado o 3. esta colocando valores distintos a numeros en los campos de Año y numero de paginas por favor verifique", "error", {
                    timer: 5000,
                    buttons: false,
                });
            };

            limpiarFormulario();
        };
        var data = JSON.stringify({
            data1
        });
        xhr.send(data);
    }

};

//Cerrar modal
function cerrarmodal() {
   window.location.reload();
}