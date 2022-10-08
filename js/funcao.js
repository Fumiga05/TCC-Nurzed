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


function validacaoData() {
    var data = new Date();
    var dia = String(data.getDate()).padStart(2, '0');
    var mes = String(data.getMonth() + 1).padStart(2, '0');
    var ano = data.getFullYear();

    var data = document.querySelector("#data_nascimento").value;
    var resultado = data.split("/");
  
    var primeiro = resultado[0];
    var segundo = resultado[1];
    var terseiro = resultado[2];

 
    if(terseiro < ano && terseiro > 1890){
        if(segundo > 12){
            alert("Data invalida , verifique os campos")
        }
        if(primeiro > 31){
            alert("Data invalida , verifique os campos")
        }

        /*desparador */
    }else{
        if(terseiro == ano){
            if(segundo <= mes){
                if(segundo == mes ){
                    if(primeiro <= dia){
                    
                    /*desparador */
                    }else{
                        alert("Data invalida , verifique os campos");
                    }
                }
            }else{
                alert("Data invalida , verifique os campos");
            }

        }else{
            alert("Data invalida , verifique os campos");
        }
    }
}

