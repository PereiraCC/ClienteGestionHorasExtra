

function cerrarModal() {
  const modal = document.getElementById("myModal");
  const span = document.getElementsByClassName("btnEstablecer4")[0];

  span.onclick = () => modal.style.display = "none";
}

function seleccionarTarea() {
    const txtMotivo = document.getElementById("txtmotivo");
    const txtCodigo = document.getElementById("txtCodigo");
    txtCodigo.value = txtMotivo.value;

    const modal = document.getElementById("myModal");
    const span = document.getElementsByClassName("btnEstablecer3Actividades")[0];

    span.onclick = () => modal.style.display = "none";
}

function modalEvidencias(nombre, titulo, motivo, entrada, salida, ruta, estado, idPersona) {

    //const txtCodigo = document.getElementById("txtCodigo");
    //txtCodigo.value = "";

    const modal = document.getElementById("myModal");
    var btn = document.getElementById(nombre);
    const span = document.getElementsByClassName("close")[0];
    let evidencia = document.getElementById("txtArchivo");

    btn.onclick = () => modal.style.display = "block";

    span.onclick = () => modal.style.display = "none";

    document.getElementById("soli").innerText = "Solicitud #" + titulo;
    document.getElementById("idEvidencia").value = titulo;
    document.getElementById("txtmotivo").value = motivo;
    document.getElementById("txtentrada").value = entrada;
    document.getElementById("txtsalida").value = salida;
    evidencia.value = ruta
    //evidencia.setAttribute("href", ruta);
    document.getElementById("txtEstado").value = (estado == true) ? "Aprobada" : "Pendiente | Rechazada";
    document.getElementById("idPersona").value = idPersona;

    window.onclick = function (event) {
        if (event.target == modal) {

            modal.style.display = "none";
        }
    }


}

//function modalPendiente(nombre) {

//  const modal = document.getElementById("myModal2");
//  var btn = document.getElementById(nombre);
//  const span = document.getElementsByClassName("closeN")[0];

//  btn.onclick = () => modal.style.display = "block";

//  span.onclick = () => modal.style.display = "none";

//  window.onclick = function(event) {
//    if (event.target == modal) {
//      modal.style.display = "none";
//    }
//  }
//}

//function cerrarModalActividades() {
//  const modal = document.getElementById("myModal2");
//  const span = document.getElementsByClassName("btnEstablecer4")[1];

//  span.onclick = () => modal.style.display = "none";
//}

//function cerrarModalActividades2() {
//  const modal = document.getElementById("myModal2");
//  const span = document.getElementsByClassName("btnCerrar")[0];

//  span.onclick = () => modal.style.display = "none";
//}