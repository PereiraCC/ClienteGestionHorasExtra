
function modalTarea(nombre, titulo, motivo, entrada, salida, horas, fecha) {
    const modal = document.getElementById("myModal");
    var btn = document.getElementById(nombre);
    const span = document.getElementsByClassName("close")[0];

    btn.onclick = () => modal.style.display = "block";

    span.onclick = () => modal.style.display = "none";

    document.getElementById("soli").innerText = "Solicitud #" + titulo;
    document.getElementById("txtmotivo").value = motivo;
    document.getElementById("txtentrada").value = entrada;
    document.getElementById("txtsalida").value = salida;
    document.getElementById("txtHoras").value = horas;
    document.getElementById("txtfecha").value = fecha;

    window.onclick = function (event) {
        if (event.target == modal) {
            
            modal.style.display = "none";
        }
    }
  

}

function cerrarModal() {
  const modal = document.getElementById("myModal");
  const span = document.getElementsByClassName("btnEstablecer4")[0];

  span.onclick = () => modal.style.display = "none";
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