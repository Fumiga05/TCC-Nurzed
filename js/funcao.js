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

    var dataNasc = document.querySelector("#data_nascimento").value;
    var resultado1 = dataNasc.split("/");

    var datauniI = document.querySelector("#uni_inicio").value;
    var resultado2 = datauniI.split("/");

    var datauniF = document.querySelector("#uni_fim").value;
    var resultado3 = datauniF.split("/");
  

    var primeiro1 = resultado1[0];
    var segundo1 = resultado1[1];
    var terseiro1 = resultado1[2];

    var primeiro2 = resultado2[0];
    var segundo2 = resultado2[1];
    var terseiro2 = resultado2[2];

    var primeiro3 = resultado3[0];
    var segundo3 = resultado3[1];
    var terseiro3 = resultado3[2];


    if(terseiro1 < ano && terseiro1 > 1900){
        if(segundo1 > 12){
            alert("Data invalida , verifique os campos")
        }
        if(primeiro1 > 31){
            alert("Data invalida , verifique os campos")
        }
       var validacao1 = true;
    }else{
        if(terseiro1 == ano){
            if(segundo1 <= mes){
                if(segundo1 == mes ){
                    if(primeiro1 <= dia){
                        var validacao2 = true;
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

    if(terseiro2 < ano && terseiro2 > 1900){
        if(segundo2 > 12){
            alert("Data invalida , verifique os campos")
        }
        if(primeiro2 > 31){
            alert("Data invalida , verifique os campos")
        }
       var validacao3 = true;
    }else{
        if(terseiro2 == ano){
            if(segundo2 <= mes){
                if(segundo2 == mes ){
                    if(primeiro2 <= dia){
                        var validacao4 = true;
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

    if(terseiro3 < ano && terseiro3 > 1900){
        if(segundo3 > 12){
            alert("Data invalida , verifique os campos")
        }
        if(primeiro3 > 31){
            alert("Data invalida , verifique os campos")
        }
       var validacao5 = true;
    }else{
        if(terseiro3 == ano){
            if(segundo3 <= mes){
                if(segundo3 == mes ){
                    if(primeiro3 <= dia){
                        var validacao6 = true;
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


   if(validacao1 == true || validacao2 == true && validacao3 == true || validacao4 == true && validacao5 == true || validacao6 == true ){
    
    let teste = document.getElementsByClassName('btn_Finalizar_adm')[0] 
    teste.setAttribute("data-bs-toggle", "modal")
    
   }else{
    let teste = document.getElementsByClassName('btn_Finalizar_adm')[0] 
    teste.removeAttribute("data-bs-toggle", "modal")




//04/05/2005

}
}
