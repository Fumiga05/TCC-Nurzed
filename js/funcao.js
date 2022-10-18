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


function validacaoData() {
    var validandoDatauniI;
    var validandoDataNasc;
    var validandoDatauniF;
    

    var data = new Date();
    var dia = String(data.getDate()).padStart(2, '0');
    var mes = String(data.getMonth() + 1).padStart(2, '0');
    var ano = data.getFullYear();

    var nasc = document.querySelector("#data_nascimento").value;
    var dataNasc = nasc.split("/");

    var dianasc = dataNasc[0];
    var mesnasc = dataNasc[1];
    var anonasc = dataNasc[2];
   
    var uniI = document.querySelector("#uni_inicio").value;
    var dataUniI = uniI.split("/");

    var diauniI = dataUniI[0];
    var mesuniI = dataUniI[1];
    var anouniI = dataUniI[2];

    var uniF = document.querySelector("#uni_fim").value;
    var dataUniF = uniF.split("/");

    var diauniF = dataUniF[0];
    var mesuniF = dataUniF[1];
    var anouniF = dataUniF[2];

    if(anonasc > 1900 && mesnasc <= 12 && dianasc <= 31){
        if(anonasc == ano){
            if(mesnasc == mes){
                if(dianasc <= dia){
                    validandoDataNasc = true;
                }else{
                    validandoDataNasc = false;
                }
            }else if(mesnasc < mes){
                validandoDataNasc = true;
            }else{
                validandoDataNasc = false;
            }
        }else{
            if(anonasc > ano){
                validandoDataNasc = false;
            }else{
                validandoDataNasc = true;
            }
        }
    }else{
        validandoDataNasc = false;
    }

    if(anouniI > 1900 && mesuniI <= 12 && diauniI <= 31){
        if(anouniI == ano){
            if(mesuniI == mes){
                if(diauniI <= dia){
                    validandoDatauniI = true;
                }else{
                    validandoDatauniI = false;
                    console.log("1")
                }
            }else if(mesuniI < mes){
                validandoDatauniI = true;
            }else{
                validandoDatauniI = false;
                console.log("2")
            }
        }else{
            if(anouniI > ano){
                validandoDatauniI = false;
                console.log("3")
            }else{
                validandoDatauniI = true;
            }
        }
    }else{
        validandoDatauniI = false;
        console.log("4")
    }

    if(anouniF > 1900 && mesuniF <= 12 && diauniF <= 31){
        if(anouniF == ano){
            if(mesuniF == mes){
                if(diauniF <= dia){
                    validandoDatauniF = true;
                }else{
                    validandoDatauniF = false;
                }
            }else if(mesuniF < mes){
                validandoDatauniF = true;
            }else{
                validandoDatauniF = false;
            }
        }else{
            if(anouniF > ano){
                validandoDatauniF = false;
            }else{
                validandoDatauniF = true;
            }
        }
    }else{
        validandoDatauniF = false;
    }

  
    console.log(nasc)
    console.log(uniI)
    console.log(uniF)

    console.log(" -" + mesuniI)

    console.log(validandoDataNasc)
    console.log(validandoDatauniI)
    console.log(validandoDatauniF)


    if(validandoDatauniF == true && validandoDatauniI == true && validandoDataNasc == true){
        console.log("data valida")
        DataValida = true 
        dataNasc = []
        dataUniI = []
        dataUniF = []
    }else{
        alert("Data invalida verifique os campos")
        console.log("data invalida")
        DataValida = false 
        dataNasc = []
        dataUniI = []
        dataUniF = []
    }
   
}



function ValidarCPF(){

    var CPFnatural = document.querySelector("#cpf").value;
    var Exemplo = CPFnatural;
    resultado = Exemplo.split("" ,14);
    

    /*validacao simples */

    if (CPFnatural == "000.000.000-00" ||CPFnatural == "111.111.111-11" || CPFnatural == "222.222.222-22" ||CPFnatural == "333.333.333-33" ||CPFnatural == "444.444.444-44" ||CPFnatural == "555.555.555-55" ||CPFnatural == "666.666.666-66" ||CPFnatural == "777.777.777-77" ||CPFnatural == "888.888.888-88" ||CPFnatural == "999.999.999-99"){
       var ValidacaoSimples = false;
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
    let sub2 = 11 - divisao2 ;

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
        CPFValido = false;
    }else{
        if(primeDigit1 == 0 || primeDigit2 == true){
            if(segundDigit1 == 0 || segundDigit2 == true){
                console.log("CPF valido")
                CPFValido = true;
            }else{
                if(primeDigit1 == false ||  primeDigit2 == false || segundDigit1 == false || segundDigit2 == false){
                    alert("CPF invalido , verifique o campo")
                    CPFValido = false;
                }else{
                    alert("algo deu errado")
                }
            }
        }else{
            alert("CPF invalido , verifique o campo")
        }
    }
    
    
    //invalidos
    //177.345.324-93
    //001.358.293-04
    //120.702.754-60

}


function ValidacaoGeral(){

    if(CPFValido == true && DataValida == true){
        console.log("validou")
        let teste = document.getElementsByClassName('btn_Finalizar_adm')[0] 
        teste.setAttribute("data-bs-toggle","modal") 
    }
}



function chamarBtn(){
    validacaoData();
    ValidarCPF();
    ValidacaoGeral();
}