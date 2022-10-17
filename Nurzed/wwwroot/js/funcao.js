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
            console.log("aqui")
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

    
//04/05/2005

}



function ValidarCPF(){

    var CPFnatural = document.querySelector("#cpf").value;
    var Exemplo = CPFnatural
    resultado = Exemplo.split("" ,14);

    /*validacao simples */

    if (CPFnatural == "000.000.000-00" ||CPFnatural == "111.111.111-11" || CPFnatural == "222.222.222-22" ||CPFnatural == "333.333.333-33" ||CPFnatural == "444.444.444-44" ||CPFnatural == "555.555.555-55" ||CPFnatural == "666.666.666-66" ||CPFnatural == "777.777.777-77" ||CPFnatural == "888.888.888-88" ||CPFnatural == "999.999.999-99"){
       var ValidacaoSimples = false;
       console.log("repetitividade encontrada")
    }
    
    /* Validacao primeiro digito */

    var digito1 = resultado[0] * 10
    var digito2 = resultado[1] * 9
    var digito3 = resultado[2] * 8
    var digito4 = resultado[4] * 7
    var digito5 = resultado[5] * 6
    var digito6 = resultado[6] * 5
    var digito7 = resultado[8] * 4
    var digito8 = resultado[9] * 3
    var digito9 = resultado[10] * 2 

    var primeiraSoma = digito1 + digito2+ digito3+ digito4+ digito5+ digito6+ digito7+ digito8+ digito9;

    let divisao1 = primeiraSoma % 11;
    let sub1 = 11- divisao1 ;

    if(sub1 >= 10){
      if( resultado[12] == 0){
        var primeDigit1 = 0
      }else{
        primeDigit1 = false
      }
    }else{
        if(sub1 == resultado[12]){
            var primeDigit2 = true;
         }else{
            primeDigit2 = false;
         }
    }

    /* Validacao segundo digito */

    var digito01 = resultado[0] * 11
    var digito02 = resultado[1] * 10
    var digito03 = resultado[2] * 9
    var digito04 = resultado[4] * 8
    var digito05 = resultado[5] * 7
    var digito06 = resultado[6] * 6
    var digito07 = resultado[8] * 5
    var digito08 = resultado[9] * 4
    var digito09 = resultado[10] * 3
    var digito10 = resultado[12] * 2
    
    var segundaSoma = digito01 + digito02+ digito03+ digito04+ digito05+ digito06+ digito07+ digito08+ digito09 + digito10;

    let divisao2 = segundaSoma % 11;
    let sub2 = 11- divisao2 ;

    if(sub2 >= 10){
       if(resultado[13] == 0){
        var segundDigit1 = 0
       }else{
        segundDigit1 = false
       }
    }else{
          if(sub2 == resultado[13]){
              var segundDigit2 = true;
           }else{
            segundDigit2 = false;
           }
    }

    if(ValidacaoSimples == false){
        alert("CPF invalido , verifique o campo")
    }else{
        if(primeDigit1 == 0 || primeDigit2 == true){
            if(segundDigit1 == 0 || segundDigit2 == true){
                alert("todos os digitos validos")
                var CPFValido = true;
            }else{
                if(primeDigit1 == false ||  primeDigit2 == false || segundDigit1 == false || segundDigit2 == false){
                    alert("CPF invalido , verifique o campo")
                }else{
                    alert("algo deu errado")
                }
            }
        }else{
            alert("CPF invalido , verifique o campo")
        }
    }
    

    //145.382.206-20
    //184.251.808-99
    //024.964.358-86
    //184.254.358-03

    //177.345.324-93
    //001.358.293-04
    //120.702.754-60

}







/*function ValidacaoGeral(){

    if(validacao1 == true || validacao2 == true){
        console.log("1 ok");
        if(validacao3 == true || validacao4 == true){
            console.log("2 ok");
            if(validacao5 == true || validacao6 == true){
                console.log("3 ok");
                let teste = document.getElementsByClassName('btn_Finalizar_adm')[0] 
                teste.setAttribute("data-bs-toggle", "modal") 
            }else{
                let teste = document.getElementsByClassName('btn_Finalizar_adm')[0] 
                teste.setAttribute("data-bs-toggle", "null")
                console.log("abacate")
            }
        }else{
            let teste = document.getElementsByClassName('btn_Finalizar_adm')[0] 
            teste.setAttribute("data-bs-toggle", "null")
            console.log("roxo")
        }
   }else{
    let teste = document.getElementsByClassName('btn_Finalizar_adm')[0] 
    teste.setAttribute("data-bs-toggle", "null")
    console.log("deu ruiiiiim")
   }

}*/

/*
CPFValido


*/


