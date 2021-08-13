

function modalAceptar(nombre) {

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

function modalARechazar(nombre) {

  console.log('Model rechazar')
  const modal2 = document.getElementById("ModalNegacion");
  const btn2 = document.getElementById(nombre);
  const span2 = document.getElementsByClassName("closeN")[0];

  btn2.onclick = () => modal2.style.display = "block";

  span2.onclick = () => modal2.style.display = "none";

  window.onclick = function(event) {
    if (event.target == modal2) {
      modal2.style.display = "none";
    }
  }
}