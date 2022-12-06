var CPFValido;
var DataValida;
var btn_Finalizar_adm = document.getElementsByClassName('btn_Finalizar_adm')[0]
var staticBackdrop = document.getElementById('staticBackdrop')


window.onload = historico();
function historico() {
    document.querySelectorAll('.input-disabled').forEach(button => {
        button.disabled = true;
    });
}

function campoVazio() {
    let nomecompleto = document.querySelector("#nomecompleto").value;
    let nomemae = document.querySelector("#nomemae").value;
    let nomepai = document.querySelector("#nomepai").value;
    let data_nascimento = document.querySelector("#data_nascimento").value;
    let cpf = document.querySelector("#cpf").value;
    let sexo = document.querySelector("#sexo").value;
    let rg = document.querySelector("#rg").value;
    let cep = document.querySelector("#cep").value;
    let telefone = document.querySelector("#telefone").value;
    let uni_inicio = document.querySelector("#uni_inicio").value;
    let uni_fim = document.querySelector("#uni_fim").value;
    let coren = document.querySelector("#coren").value;
    let matricula = document.querySelector("#matricula").value;
    let senha = document.querySelector("#senha").value;

    if (nomecompleto == "" || nomemae == "" || nomepai == "" || data_nascimento == "" || cpf == "" || sexo == "" || rg == "" || cep == "" || telefone == "" || uni_inicio == "" || uni_fim == "" || coren == "" || matricula == "" || senha == "") {
        

        MostrarMensagem('Preencha todos os campos vazios', 'orange', 'Atenção', 'fa-solid fa-triangle-exclamation')
        //alert("Campo vazio! Verifique os campos.")

    } else {
        validacaoData();
        ValidarCPF();
    }

}

function validacaoData() {
    let validandoDatauniI;
    let validandoDataNasc;
    let validandoDatauniF;


    let data = new Date();
    let dia = String(data.getDate()).padStart(2, '0');
    let mes = String(data.getMonth() + 1).padStart(2, '0');
    let ano = data.getFullYear();

    var nasc = document.querySelector("#data_nascimento").value;
    let dataNasc = nasc.split("/");

    let dianasc = dataNasc[0];
    let mesnasc = dataNasc[1];
    let anonasc = dataNasc[2];

    var uniI = document.querySelector("#uni_inicio").value;
    let dataUniI = uniI.split("/");

    let diauniI = dataUniI[0];
    let mesuniI = dataUniI[1];
    let anouniI = dataUniI[2];

    var uniF = document.querySelector("#uni_fim").value;
    let dataUniF = uniF.split("/");

    let diauniF = dataUniF[0];
    let mesuniF = dataUniF[1];
    let anouniF = dataUniF[2];

    if (anonasc > 1900) {
        if (anonasc == ano) {
            if (mesnasc == mes) {
                if (dianasc <= dia) {
                    validandoDataNasc = true;
                } else {
                    validandoDataNasc = false;
                }
            } else if (mesnasc < mes) {
                validandoDataNasc = true;
            } else {
                validandoDataNasc = false;
            }
        } else {
            if (anonasc > ano) {
                validandoDataNasc = false;
            } else {
                validandoDataNasc = true;
            }
        }
    } else {
        validandoDataNasc = false;
    }

    if (anouniI > 1900) {
        if (anouniI == ano) {
            if (mesuniI == mes) {
                if (diauniI <= dia) {
                    validandoDatauniI = true;
                } else {
                    validandoDatauniI = false;
                }
            } else if (mesuniI < mes) {
                validandoDatauniI = true;
            } else {
                validandoDatauniI = false;
            }
        } else {
            if (anouniI > ano) {
                validandoDatauniI = false;
            } else {
                validandoDatauniI = true;
            }
        }
    } else {
        validandoDatauniI = false;
    }

    if (anouniF > 1900) {
        if (anouniF == ano) {
            if (mesuniF == mes) {
                if (diauniF <= dia) {
                    validandoDatauniF = true;
                } else {
                    validandoDatauniF = false;
                }
            } else if (mesuniF < mes) {
                validandoDatauniF = true;
            } else {
                validandoDatauniF = false;
            }
        } else {
            if (anouniF > ano) {
                validandoDatauniF = false;
            } else {
                validandoDatauniF = true;
            }
        }
    } else {
        validandoDatauniF = false;
    }




    if (validandoDatauniF == true && validandoDatauniI == true && validandoDataNasc == true) {
        console.log("data valida")
        DataValida = true
        dataNasc = []
        dataUniI = []
        dataUniF = []
    } else {
        DataValida = false
        MostrarMensagem('Data invalida verifique os campos', 'red', 'Erro', 'fa-solid fa-circle-exclamation')
        dataNasc = []
        dataUniI = []
        dataUniF = []
    }
}

function ValidarCPF() {

    let CPFnatural = document.querySelector("#cpf").value;
    console.log(CPFnatural)
    let Exemplo = CPFnatural;
    resultado = Exemplo.split("", 14);


    /*validacao simples */

    if (CPFnatural == "000.000.000-00" || CPFnatural == "111.111.111-11" || CPFnatural == "222.222.222-22" || CPFnatural == "333.333.333-33" || CPFnatural == "444.444.444-44" || CPFnatural == "555.555.555-55" || CPFnatural == "666.666.666-66" || CPFnatural == "777.777.777-77" || CPFnatural == "888.888.888-88" || CPFnatural == "999.999.999-99") {
        var ValidacaoSimples = false;
        console.log("repetitividade encontrada")
    }

    /* Validacao primeiro digito */

    let digito1 = resultado[0] * 10
    let digito2 = resultado[1] * 9
    let digito3 = resultado[2] * 8
    let digito4 = resultado[4] * 7
    let digito5 = resultado[5] * 6
    let digito6 = resultado[6] * 5
    let digito7 = resultado[8] * 4
    let digito8 = resultado[9] * 3
    let digito9 = resultado[10] * 2

    let primeiraSoma = digito1 + digito2 + digito3 + digito4 + digito5 + digito6 + digito7 + digito8 + digito9;

    let divisao1 = primeiraSoma % 11;
    let sub1 = 11 - divisao1;

    if (sub1 >= 10) {
        if (resultado[12] == 0) {
            var primeDigit1 = 0
        } else {
            primeDigit1 = false
        }
    } else {
        if (sub1 == resultado[12]) {
            var primeDigit2 = true;
        } else {
            primeDigit2 = false;
        }
    }

    /* Validacao segundo digito */

    let digito01 = resultado[0] * 11
    let digito02 = resultado[1] * 10
    let digito03 = resultado[2] * 9
    let digito04 = resultado[4] * 8
    let digito05 = resultado[5] * 7
    let digito06 = resultado[6] * 6
    let digito07 = resultado[8] * 5
    let digito08 = resultado[9] * 4
    let digito09 = resultado[10] * 3
    let digito10 = resultado[12] * 2

    let segundaSoma = digito01 + digito02 + digito03 + digito04 + digito05 + digito06 + digito07 + digito08 + digito09 + digito10;

    let divisao2 = segundaSoma % 11;
    let sub2 = 11 - divisao2;

    if (sub2 >= 10) {
        if (resultado[13] == 0) {
            var segundDigit1 = 0
        } else {
            segundDigit1 = false
        }
    } else {
        if (sub2 == resultado[13]) {
            var segundDigit2 = true;
        } else {
            segundDigit2 = false;
        }
    }

    if (ValidacaoSimples == false) {
        alert("CPF invalido , verifique o campo")
        CPFValido = false;
    } else {
        if (primeDigit1 == 0 || primeDigit2 == true) {
            if (segundDigit1 == 0 || segundDigit2 == true) {
                console.log("CPF valido")
                CPFValido = true;
            } else {
                if (primeDigit1 == false || primeDigit2 == false || segundDigit1 == false || segundDigit2 == false) {
                    alert("CPF invalido , verifique o campo")
                    CPFValido = false;
                } else {
                    alert("algo deu errado")
                }
            }
        } else {
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

function ValidacaoGeral() {
    campoVazio()
    if (CPFValido == true && DataValida == true) {
        return true;
    }else{    
        console.log('não validou, algo está errado')
        return false;
    }
}



function MostrarMensagem(texto, cor, titulo, icon) {
    texto = (texto !== 'undefined') ? texto : 'Testando Atencao'
    iziToast.show({
        title: titulo,
        message: texto,
        position: 'topRight',
        color: cor,
        icon: icon
    })
}


function escolherTipoUsuario(elemento) {
    let div_dadosHospitalares = document.getElementById('div_dadosHospitalares')
    if (elemento.value == "Administrador") {
       
        div_dadosHospitalares.style.display = 'none'
    } else {
        div_dadosHospitalares.style.display = 'block'
    }

    

}


