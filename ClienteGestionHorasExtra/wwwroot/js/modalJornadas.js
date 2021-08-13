

function modalJornada(nombre) {

  const modal = document.getElementById("myModal");
  var btn = document.getElementById(nombre);
  const span = document.getElementsByClassName("close")[0];

  btn.onclick = () => modal.style.display = "block";

  span.onclick = () => modal.style.display = "none";

  window.onclick = function(event) {
    if (event.target == modal) {
      modal.style.display = "none";
    }
  }
}

function cerrarModal() {
  const modal = document.getElementById("myModal");
  const span = document.getElementsByClassName("btnEstablecer3")[0];

  span.onclick = () => modal.style.display = "none";
}