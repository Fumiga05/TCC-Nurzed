var CPFValido;
var DataValida;

function avaCronograma() {

    let section = document.getElementById('aux30');
    section.style.display = 'block';

    let btnava = document.getElementById('aux10');
    btnava.style.display = 'none';

    let btntroc = document.getElementById('aux31');
    btntroc.style.display = 'block';

    let select = document.getElementById('aux9');
    select.style.display = 'none';
}

function f5() {
    if (window.confirm("Trocar de horário não salva suas alterações, ainda assim deseja trocar de horário?")) {
        location.reload(true);
    }
}

function avaPeriodo() {
    let btnava2 = document.getElementById('aux36');
    btnava2.style.display = 'none';

    let btnTroca = document.getElementById('aux37');
    btnTroca.style.display = 'block';

    let conteudoPeriodo = document.getElementById('aux38');
    conteudoPeriodo.style.display = 'block';

    let vazio2 = document.getElementById('aux39');
    vazio2.style.display = 'none';

}

function avaPeriodoADM() {
    let btnava2 = document.getElementById('aux36');
    btnava2.style.display = 'none';

    let btnTroca = document.getElementById('aux37');
    btnTroca.style.display = 'block';

    let conteudoPeriodo = document.getElementById('aux38');
    conteudoPeriodo.style.display = 'block';

    let vazio2 = document.getElementById('aux47');
    vazio2.style.display = 'none';

}



