function vota() {
    let verificar = document.getElementById('value').value;
    if (verificar != "sim") {
        alert(` O valor é ${verificar}`);
    }
}