

function modalPago(nombre, titulo, funcionario,  horas, quincena, desc, monto, idFormularioPago) {

    const modal = document.getElementById("myModal");
    var btn = document.getElementById(nombre);
    const span = document.getElementsByClassName("close")[0];

    btn.onclick = () => modal.style.display = "block";

    span.onclick = () => modal.style.display = "none";

    document.getElementById("txtTitulo").innerText = "Pago #" + titulo;
    document.getElementById("txtNombre").value = funcionario;
    document.getElementById("txtHoras").value = horas;
    document.getElementById("txtQuincena").value = quincena;
    document.getElementById("txtDescripcion").value = desc;
    document.getElementById("txtMonto").value = monto;
    document.getElementById("idFormularioPago").value = idFormularioPago;

    window.onclick = function (event) {
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