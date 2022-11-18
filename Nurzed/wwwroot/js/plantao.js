var listaEnfermeiros = []
var listaTecnicos = []
var listaAux = []
var listaAusentes = []


var data1 = '2022-12-10'
var periodo = 'manha'
clicar()
function clicar() {
    listaEnfermeiros = []
    listaTecnicos = []
    listaAux = []
    listaAusentes = []
    

    const req =  fetch('https://localhost:44345/api/API/data/' + data1 + '/' + periodo, {
        method: 'GET',
        headers: { 'Content-Type': 'application/json' },
    })
        .then(data => data.json())
        .then(data => {

            listaEnfermeiros.push(data[0]);            
            listaTecnicos.push(data[1])
            listaAux.push(data[2])
            listaAusentes.push(data[3])
           

            Remover()


            AdicionarEnfermeiros()
            AdicionarTecnicos()
            AdicionarAuxEnf()
            AdicionarAusentes()

        })
        .catch((error) => console.log('Erro: ' + error.status));

    

}




function AdicionarEnfermeiros() {
    var div_Enfermeiros = document.getElementById("div_Enfermeiros")
    var n_enf = document.getElementById("n_enf")
    n_enf.innerHTML = "Enfermeiros:" + listaEnfermeiros[0].length

    listaEnfermeiros[0].forEach(item => {

   
    var card_funcionario_periodo = document.createElement("div")
    div_Enfermeiros.appendChild(card_funcionario_periodo)
    card_funcionario_periodo.setAttribute("class", "card_funcionario_periodo")


    var img = document.createElement("img")
    card_funcionario_periodo.appendChild(img)
    img.setAttribute("src", "/img/enfermeiro.png")
    img.setAttribute("class", "icon_funcio_periodo")
    img.setAttribute("alt", "seringa medica")

    var dados_user_periodo = document.createElement("div")
    card_funcionario_periodo.appendChild(dados_user_periodo)
    dados_user_periodo.setAttribute("class", "dados_user_periodo")
    dados_user_periodo.setAttribute("class","nEnfermeiros")

    var funcio_periodo_Nome = document.createElement("p")
    dados_user_periodo.appendChild(funcio_periodo_Nome)
    funcio_periodo_Nome.innerText = item["nome"]
    funcio_periodo_Nome.setAttribute("class", "funcio_periodo_Nome")

    var funcio_periodo_matricula = document.createElement("p")
    dados_user_periodo.appendChild(funcio_periodo_matricula)
    funcio_periodo_matricula.innerText = "Matrícula:" + item["matricula"]
    funcio_periodo_matricula.setAttribute("class", "funcio_periodo_dados")

    var funcio_periodo_coren = document.createElement("p")
    dados_user_periodo.appendChild(funcio_periodo_coren)
    funcio_periodo_coren.innerText = "COREN:" + item["coren"]
    funcio_periodo_coren.setAttribute("class", "funcio_periodo_dados")
       
    
    })

}

function AdicionarTecnicos() {
    var div_Tecnicos = document.getElementById("div_Tecnicos")
    var n_tec = document.getElementById("n_tec")
    n_tec.innerHTML = "Técnicos de enfermagem:" + listaTecnicos[0].length

    listaTecnicos[0].forEach(item => {

    
        var card_funcionario_periodo = document.createElement("div")
        div_Tecnicos.appendChild(card_funcionario_periodo)
        card_funcionario_periodo.setAttribute("class", "card_funcionario_periodo")


        var img = document.createElement("img")
        card_funcionario_periodo.appendChild(img)
        img.setAttribute("src", "/img/Tecnico.png")
        img.setAttribute("class", "icon_funcio_periodo")
        img.setAttribute("alt", "seringa medica")

        var dados_user_periodo = document.createElement("div")
        card_funcionario_periodo.appendChild(dados_user_periodo)
        dados_user_periodo.setAttribute("class", "dados_user_periodo")

        var funcio_periodo_Nome = document.createElement("p")
        dados_user_periodo.appendChild(funcio_periodo_Nome)
        funcio_periodo_Nome.innerText = item["nome"]
        funcio_periodo_Nome.setAttribute("class", "funcio_periodo_Nome")

        var funcio_periodo_matricula = document.createElement("p")
        dados_user_periodo.appendChild(funcio_periodo_matricula)
        funcio_periodo_matricula.innerText = "Matrícula:" + item["matricula"]
        funcio_periodo_matricula.setAttribute("class", "funcio_periodo_dados")

        var funcio_periodo_coren = document.createElement("p")
        dados_user_periodo.appendChild(funcio_periodo_coren)
        funcio_periodo_coren.innerText = "COREN:" + item["coren"]
        funcio_periodo_coren.setAttribute("class", "funcio_periodo_dados")

    })
  
  
}

function AdicionarAuxEnf() {
    var div_Aux = document.getElementById("div_Aux")
    var n_aux = document.getElementById("n_aux")
    n_aux.innerHTML = "Técnicos de enfermagem:" + listaAux[0].length

    listaAux[0].forEach(item => {

   
    var card_funcionario_periodo = document.createElement("div")
    div_Aux.appendChild(card_funcionario_periodo)
    card_funcionario_periodo.setAttribute("class", "card_funcionario_periodo")


    var img = document.createElement("img")
    card_funcionario_periodo.appendChild(img)
    img.setAttribute("src", "/img/auxiliar.png")
    img.setAttribute("class", "icon_funcio_periodo")
    img.setAttribute("alt", "seringa medica")

    var dados_user_periodo = document.createElement("div")
    card_funcionario_periodo.appendChild(dados_user_periodo)
    dados_user_periodo.setAttribute("class", "dados_user_periodo")

    var funcio_periodo_Nome = document.createElement("p")
    dados_user_periodo.appendChild(funcio_periodo_Nome)
    funcio_periodo_Nome.innerText = item["nome"]
    funcio_periodo_Nome.setAttribute("class", "funcio_periodo_Nome")

    var funcio_periodo_matricula = document.createElement("p")
    dados_user_periodo.appendChild(funcio_periodo_matricula)
    funcio_periodo_matricula.innerText = "Matrícula:" + item["matricula"]
    funcio_periodo_matricula.setAttribute("class", "funcio_periodo_dados")

    var funcio_periodo_coren = document.createElement("p")
    dados_user_periodo.appendChild(funcio_periodo_coren)
    funcio_periodo_coren.innerText = "COREN:" + item["coren"]
    funcio_periodo_coren.setAttribute("class", "funcio_periodo_dados")

    })
}

function AdicionarAusentes() {
    var div_ausentes = document.getElementById("div_ausentes")

    listaAusentes[0].forEach(item => {

        var cedula_ausente_adm = document.createElement("div")
        div_ausentes.appendChild(cedula_ausente_adm)
        cedula_ausente_adm.setAttribute("class", "cedula_ausente_adm")

        var nome_ausencia = document.createElement("p")
        cedula_ausente_adm.appendChild(nome_ausencia)
        nome_ausencia.setAttribute("class", "nome_ausencia")
        nome_ausencia.innerHTML = item["nome"]

        var separa_ausencia = document.createElement("hr")
        cedula_ausente_adm.appendChild(separa_ausencia)
        separa_ausencia.setAttribute("class", "separa_ausencia")        

        var cargo_ausencia = document.createElement("p")
        cedula_ausente_adm.appendChild(cargo_ausencia)
        cargo_ausencia.setAttribute("class", "cargo_ausencia")
        cargo_ausencia.innerHTML = item["id_Cargo"]

        var status_ausencia_adm = document.createElement("p")
        cedula_ausente_adm.appendChild(status_ausencia_adm)
        status_ausencia_adm.setAttribute("class", "status_ausencia_adm")
        status_ausencia_adm.innerHTML = item["id_Curso"]

    })
}

function Remover() {
    //Remove conteudo da div Enfermeiros
    var div_Enfermeiros = document.getElementById("div_Enfermeiros")
    while (div_Enfermeiros.firstChild) {
        div_Enfermeiros.removeChild(div_Enfermeiros.firstChild)
    }

    //Remove o conteudo da div Tecnicos
    var div_Tecnicos = document.getElementById("div_Tecnicos")
    while (div_Tecnicos.firstChild) {
        div_Tecnicos.removeChild(div_Tecnicos.firstChild)
    }

    //Remove o conteudo da div Aux
    var div_Aux = document.getElementById("div_Aux")
    while (div_Aux.firstChild) {
        div_Aux.removeChild(div_Aux.firstChild)
    }


    //Remove o conteudo da div ausentes
    var div_ausentes = document.getElementById("div_ausentes")
    while (div_ausentes.firstChild) {
        div_ausentes.removeChild(div_ausentes.firstChild)
    }


 


}

function EscolherPeriodo(valor) {    
    periodo = valor.value
    var horario = document.getElementById("horario")

    if (periodo == 'manha') {
        horario.innerHTML = "7:00 às 13:30"
    } else if (periodo == 'tarde') {
        horario.innerHTML = "13:00 às 19:00"
    } else if (periodo == 'noite') {
        horario.innerHTML = "21:00 às 07:00"
    }
        
    clicar()
    return periodo

}