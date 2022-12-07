let h1_mes = document.getElementById('h1_mes')
h1_mes.innerHTML = localStorage.getItem('mes')

var diasDoMes = localStorage.getItem('diasDoMes')

var mesNumeral = localStorage.getItem('mesNumeral')

var anoDoMes = localStorage.getItem('anoDoMes')
var periodo = 'manha'


var listaEnfermeiros = []
var listaTecnicos = []
var listaAux = []
var listaLegendaEnf = []
var listaLegendaTec = []
var listaLegendaAux = []
var aux = []

atualizar()


function atualizar() {
    
    listaEnfermeiros = []
    listaTecnicos = []
    listaAux = []
    listaLegendaEnf = []
    listaLegendaTec = []
    listaLegendaAux = []

    const req = fetch('https://localhost:44345/api/API/cronograma_editar/' + mesNumeral + '/' + anoDoMes + '/' + periodo, {
        method: 'GET',
        headers: { 'Content-Type': 'application/json' },


    })
        .then(data => data.json())
        .then(data => {
            console.log(data)
            listaEnfermeiros.push(data[0]);
            listaTecnicos.push(data[1])
            listaAux.push(data[2])
            listaLegendaEnf.push(data[3])
            listaLegendaTec.push(data[4])
            listaLegendaAux.push(data[5])
            console.log(periodo)
            

            Remover()
            ListaDias()
            AdicionarEnfermeiros()           
            AdicionarTecnicos()
            AdicionarAuxEnf()
            atualizarLegendas()

            throw new Error('O cronograma deste periodo ainda não foi cadastrado')
        })
        
        .catch((error) => console.log('Erro: ' + error + '\n Req:' + req));

}





//Atualiza as legendas dos funcionarios
function atualizarLegendas() {
    //Atualiza legenda dos enfermeiros
    let select_Enfermeiro = document.getElementsByClassName('select_Enfermeiro')
    let auxiliarEnf = listaLegendaEnf[0] 
    for (let i = 0; i < select_Enfermeiro.length; i++) {
        select_Enfermeiro[i].childNodes.forEach(item => {
            if (item.value == auxiliarEnf[i]["legenda"]) {
                item.setAttribute("selected", "true")
                
            }
        })
       
    }    
    Array.from(select_Enfermeiro).forEach(item => {
        item.dispatchEvent(new Event('change'));
    })


    //Atualizar legenda dos Tecnicos
    let select_Tecnico = document.getElementsByClassName('select_Tecnico')
    let auxiliarTec = listaLegendaTec[0]
   
    for (let i = 0; i < select_Tecnico.length; i++) {
        select_Tecnico[i].childNodes.forEach(item => {
            if (item.value == auxiliarTec[i]["legenda"]) {
                item.setAttribute("selected", "true")
            }
        })
    }

    Array.from(select_Tecnico).forEach(item => {
        item.dispatchEvent(new Event('change'));
    })

    //Atualizar Auxiliares
    let select_Auxiliar = document.getElementsByClassName('select_Auxiliar')
    let auxiliarAux = listaLegendaAux[0]
 
    for (let i = 0; i < select_Auxiliar.length; i++) {
        select_Auxiliar[i].childNodes.forEach(item => {
            if (item.value == auxiliarAux[i]["legenda"]) {
                item.setAttribute("selected","true")
            }
        })
    }

    Array.from(select_Auxiliar).forEach(item => {
        item.dispatchEvent(new Event('change'));
    })
}

const select_cronograma_adm = document.getElementsByName('Legenda')
function mudarLegenda(elemento) {
    
    if (elemento.value == 'PR') {
        elemento.parentElement.removeAttribute("id")
        elemento.removeAttribute("id")
        elemento.setAttribute('class', 'select_cronograma_adm select_infermeiro_tabela_adm')


    } else if (elemento.value == 'FI') {
        elemento.parentElement.setAttribute('id', 'falta_injustificada')
        elemento.setAttribute('class', 'select_cronograma_adm select_infermeiro_tabela_adm')
        elemento.setAttribute('id', 'falta_injustificada')
    } else {
        elemento.setAttribute('class', 'select_cronograma_adm select_infermeiro_tabela_adm ')
        elemento.parentElement.setAttribute('id', 'folga')
        elemento.setAttribute('id', 'folga')
    }
    
}



function AdicionarEnfermeiros() {
    //Retira tabela Enfermeiros caso não tenha nenhum usuário
    var div_Enfermeiros = document.getElementById('div_Enfermeiros')
    div_Enfermeiros.setAttribute("style", "display:none;")
    if (listaEnfermeiros[0].length >= 1) {
        div_Enfermeiros.setAttribute("style", "display:block;")
    }



    let opções = ["PR", "X", "ABA", "LTS", "LP", "LG", "FE", "FI", "PF", "CH", "TL", "AF", "TC", "FT"]
    var tabela = document.getElementById('tbody_Enfermeiros')
    //Repete a quantidade de users

    listaEnfermeiros[0].forEach(item => {


        var tr = document.createElement("tr");
        tabela.appendChild(tr)
        tr.setAttribute("name", "tr_Enfermeiros")
        tr.setAttribute("class", "tabela_cronograma_adm")

        var tdNome = document.createElement("td")
        tr.appendChild(tdNome)
        tdNome.setAttribute("class", "opcao_tabela_cronograma_enf nome_infermeiro_tabela_adm")
        tdNome.setAttribute("name", "nFuncionarios")
        tdNome.innerText = item["nome"]



        var input = document.createElement("input");
        tabela.appendChild(input)
        input.setAttribute("type", "hidden")
        input.setAttribute("value", item["id"])
        input.setAttribute("name", "nome")


        var tdCoren = document.createElement("td")
        tr.appendChild(tdCoren)
        tdCoren.setAttribute("class", "opcao_tabela_cronograma_enf corem_infermeiro_tabela_adm")
        tdCoren.innerText = item["coren"]

        //Repete a quantidade de dias
        for (let j = 1; j <= diasDoMes; j++) {


            var td = document.createElement("td")
            tr.appendChild(td)
            td.setAttribute("class", "opcao_tabela_cronograma_enf")

            var inputDiasAll = document.createElement("input")
            inputDiasAll.setAttribute("type", "hidden")
            inputDiasAll.setAttribute("name", "diasAll")
            inputDiasAll.setAttribute("value", "")

            var select = document.createElement("select")
            td.append(select)
            select.setAttribute("class", "select_cronograma_adm select_infermeiro_tabela_adm select_Enfermeiro")
            select.setAttribute("name", "Legenda")
            select.setAttribute("onChange", "mudarLegenda(this)")
            //declaração das options
            opções.forEach(item => {
                var option = document.createElement("option")
                select.appendChild(option)
                option.innerText = item
                option.setAttribute("value", item)
            })

        }
    })


    return listaEnfermeiros

}


function AdicionarTecnicos() {
    //Retira tabela Tecnicos caso não tenha nenhum usuário
    var div_Tecnicos = document.getElementById('div_Tecnicos')
    div_Tecnicos.setAttribute("style", "display:none;")
    if (listaTecnicos[0].length >= 1) {
        div_Tecnicos.setAttribute("style", "display:block;")
    }

    let opções = ["PR", "X", "ABA", "LTS", "LP", "LG", "FE", "FI", "PF", "CH", "TL", "AF", "TC", "FT"]
    var tabela = document.getElementById('tbody_Tecnicos')

    //Repete a quantidade de users

    listaTecnicos[0].forEach(item => {


        var tr = document.createElement("tr");
        tabela.appendChild(tr)
        tr.setAttribute("name", "tr_Tecnicos")
        tr.setAttribute("class", "tabela_cronograma_adm")

        var tdNome = document.createElement("td")
        tr.appendChild(tdNome)
        tdNome.setAttribute("class", "opcao_tabela_cronograma_enf nome_infermeiro_tabela_adm")
        tdNome.setAttribute("name", "nFuncionarios")
        tdNome.innerText = item["nome"]


        var input = document.createElement("input");
        tabela.appendChild(input)
        input.setAttribute("type", "hidden")
        input.setAttribute("value", item["id"])
        input.setAttribute("name", "nome")

        var tdCoren = document.createElement("td")
        tr.appendChild(tdCoren)
        tdCoren.setAttribute("class", "opcao_tabela_cronograma_enf corem_infermeiro_tabela_adm")
        tdCoren.innerText = item["coren"]

        //Repete a quantidade de dias
        for (let j = 1; j <= diasDoMes; j++) {


            var td = document.createElement("td")
            tr.appendChild(td)
            td.setAttribute("class", "opcao_tabela_cronograma_enf")

            var inputDiasAll = document.createElement("input")
            inputDiasAll.setAttribute("type", "hidden")
            inputDiasAll.setAttribute("name", "diasAll")
            inputDiasAll.setAttribute("value", "")

            var select = document.createElement("select")
            td.append(select)
            select.setAttribute("class", "select_cronograma_adm select_infermeiro_tabela_adm select_Tecnico")
            select.setAttribute("name", "Legenda")
            select.setAttribute("onchange", "mudarLegenda(this)")
            //declaração das options
            opções.forEach(item => {
                var option = document.createElement("option")
                select.appendChild(option)
                option.innerText = item
                option.setAttribute("value", item)
            })

        }
    })



    return listaTecnicos
}

function AdicionarAuxEnf() {
    //Retira tabela AuxEnf caso não tenha nenhum usuário
    var div_AuxEnf = document.getElementById('div_AuxEnf')
    div_AuxEnf.setAttribute("style", "display:none;")
    if (listaAux[0].length >= 1) {
        div_AuxEnf.setAttribute("style", "display:block;")
    }



    let opções = ["PR", "X", "ABA", "LTS", "LP", "LG", "FE", "FI", "PF", "CH", "TL", "AF", "TC", "FT"]
    var tabela = document.getElementById('tbody_AuxEnf')

    //Repete a quantidade de users

    listaAux[0].forEach(item => {


        var tr = document.createElement("tr");
        tabela.appendChild(tr)
        tr.setAttribute("name", "tr_AuxEnf")
        tr.setAttribute("class", "tabela_cronograma_adm")

        var tdNome = document.createElement("td")
        tr.appendChild(tdNome)
        tdNome.setAttribute("class", "opcao_tabela_cronograma_enf nome_infermeiro_tabela_adm")
        tdNome.setAttribute("name", "nFuncionarios")
        tdNome.innerText = item["nome"]


        var input = document.createElement("input");
        tabela.appendChild(input)
        input.setAttribute("type", "hidden")
        input.setAttribute("value", item["id"])
        input.setAttribute("name", "nome")

        var tdCoren = document.createElement("td")
        tr.appendChild(tdCoren)
        tdCoren.setAttribute("class", "opcao_tabela_cronograma_enf corem_infermeiro_tabela_adm")
        tdCoren.innerText = item["coren"]

        //Repete a quantidade de dias
        for (let j = 1; j <= diasDoMes; j++) {


            var td = document.createElement("td")
            tr.appendChild(td)
            td.setAttribute("class", "opcao_tabela_cronograma_enf")

            var inputDiasAll = document.createElement("input")
            inputDiasAll.setAttribute("type", "hidden")
            inputDiasAll.setAttribute("name", "diasAll")
            inputDiasAll.setAttribute("value", "")

            var select = document.createElement("select")
            td.append(select)
            select.setAttribute("class", "select_cronograma_adm select_infermeiro_tabela_adm select_Auxiliar")
            select.setAttribute("name", "Legenda")
            select.setAttribute("onchange", "mudarLegenda(this)")
            //declaração das options
            opções.forEach(item => {
                var option = document.createElement("option")
                select.appendChild(option)
                option.innerText = item
                option.setAttribute("value", item)
            })

        }
    })



    return listaEnfermeiros

}





function ListaDias() {
    //Tabela Enfermeiros
    var tr_Enfermeiros = document.getElementById('tr_Enfermeiros')
    tr_Enfermeiros.setAttribute("class", "linha_1_cronograma_enf")

    var tdNome_Enfermeiros = document.createElement("td")
    tr_Enfermeiros.appendChild(tdNome_Enfermeiros)
    tdNome_Enfermeiros.innerText = 'Enfermeiros'

    tdNome_Enfermeiros.setAttribute("class", "nome_infermeiro_tabela_adm")

    var tdCoren_Enfermeiros = document.createElement("td")
    tr_Enfermeiros.appendChild(tdCoren_Enfermeiros)
    tdCoren_Enfermeiros.innerText = 'Coren'

    tdCoren_Enfermeiros.setAttribute("class", "nome_infermeiro_tabela_adm")
    //Tabela Técnicos
    var tr_Tecnicos = document.getElementById('tr_Tecnicos')
    tr_Tecnicos.setAttribute("class", "linha_1_cronograma_enf")

    var tdNome_Tecnicos = document.createElement("td")
    tr_Tecnicos.appendChild(tdNome_Tecnicos)
    tdNome_Tecnicos.innerText = 'TÉC. DE ENFERMAGEM'

    tdNome_Tecnicos.setAttribute("class", "nome_infermeiro_tabela_adm")

    var tdCoren_Tecnicos = document.createElement("td")
    tr_Tecnicos.appendChild(tdCoren_Tecnicos)
    tdCoren_Tecnicos.innerText = 'Coren'

    tdCoren_Tecnicos.setAttribute("class", "nome_infermeiro_tabela_adm")

    //Tabela Aux.Enfermagem
    var tr_AuxEnf = document.getElementById('tr_AuxEnf')
    tr_AuxEnf.setAttribute("class", "linha_1_cronograma_enf")

    var tdNome_AuxEnf = document.createElement("td")
    tr_AuxEnf.appendChild(tdNome_AuxEnf)
    tdNome_AuxEnf.innerText = 'AUX.ENFERMAGEM'

    tdNome_AuxEnf.setAttribute("class", "nome_infermeiro_tabela_adm")

    var tdCoren_AuxEnf = document.createElement("td")
    tr_AuxEnf.appendChild(tdCoren_AuxEnf)
    tdCoren_AuxEnf.innerText = 'Coren'

    tdCoren_AuxEnf.setAttribute("class", "nome_infermeiro_tabela_adm")




    for (let i = 1; i <= diasDoMes; i++) {
        var td_Enfermeiros = document.createElement("td")
        tr_Enfermeiros.appendChild(td_Enfermeiros)
        td_Enfermeiros.setAttribute("value", i)
        i >= 10 ? td_Enfermeiros.innerText = i : td_Enfermeiros.innerText = "0" + i
        td_Enfermeiros.setAttribute("name", "diasd")
        td_Enfermeiros.setAttribute("class", "select_infermeiro_tabela_adm")

        var td_Tecnicos = document.createElement("td")
        tr_Tecnicos.appendChild(td_Tecnicos)
        td_Tecnicos.setAttribute("value", i)
        i >= 10 ? td_Tecnicos.innerText = i : td_Tecnicos.innerText = "0" + i
        td_Tecnicos.setAttribute("name", "diasd")
        td_Tecnicos.setAttribute("class", "select_infermeiro_tabela_adm")

        var td_AuxEnf = document.createElement("td")
        tr_AuxEnf.appendChild(td_AuxEnf)
        td_AuxEnf.setAttribute("value", i)
        i >= 10 ? td_AuxEnf.innerText = i : td_AuxEnf.innerText = "0" + i
        td_AuxEnf.setAttribute("name", "diasd")
        td_AuxEnf.setAttribute("class", "select_infermeiro_tabela_adm")


        var input = document.createElement("input")
        input.setAttribute("type", "hidden")
        input.setAttribute("name", "dias")
        input.setAttribute("value", "")
    }
    var dias = document.getElementsByName('diasd')

    let h1_mes = document.getElementById("h1_mes")


}




function Remover() {

    //Remove o conteudo da tabela enfermeiros
    var tr_Enfermeiros = document.getElementById('tr_Enfermeiros')

    while (tr_Enfermeiros.firstChild) {
        tr_Enfermeiros.removeChild(tr_Enfermeiros.firstChild);
    }
    //Remove o conteudo da tabela Tecnicos
    var tr_Tecnicos = document.getElementById('tr_Tecnicos')

    while (tr_Tecnicos.firstChild) {
        tr_Tecnicos.removeChild(tr_Tecnicos.firstChild);
    }

    //Remove o conteudo da tabela Aux.Enf
    var tr_AuxEnf = document.getElementById('tr_AuxEnf')

    while (tr_AuxEnf.firstChild) {
        tr_AuxEnf.removeChild(tr_AuxEnf.firstChild);
    }

    //Removendo os input hidden com values da tabela enfermeiros   
    var input_Nome_Enf = document.getElementsByName('nome')
    var maker_Nome_Enf = input_Nome_Enf.length

    for (let i = 0; i < maker_Nome_Enf; i++) {
        input_Nome_Enf[0].parentNode.removeChild(input_Nome_Enf[0])
    }

    //Removendo os input hidden com values da tabela tecnicos    
    var input_Nome_Tecnicos = document.getElementsByName('nome')
    var maker_Nome_Tecnicos = input_Nome_Tecnicos.length

    for (let i = 0; i < maker_Nome_Tecnicos; i++) {
        input_Nome_Tecnicos[0].parentNode.removeChild(input_Nome_Tecnicos[0])
    }

    //Removendo os input hidden com values da tabela AuxEnf  
    var input_Nome_AuxEnf = document.getElementsByName('nome')
    var maker_Nome_AuxEnf = input_Nome_AuxEnf.length

    for (let i = 0; i < maker_Nome_AuxEnf; i++) {
        input_Nome_AuxEnf[0].parentNode.removeChild(input_Nome_AuxEnf[0])
    }

    //Remove os tr's o conteudo da tabela de enfermeiros
    var tbody_Enfermeiros = document.getElementById('tbody_Enfermeiros')
    var tr_Enfermeiros = document.getElementsByName('tr_Enfermeiros')
    var marker_Enfermeiros = tr_Enfermeiros.length

    for (let i = 0; i < marker_Enfermeiros; i++) {
        tbody_Enfermeiros.removeChild(tr_Enfermeiros[0])
    }

    //Remove os tr's o conteudo da tabela de Tecnicos

    var tbody_Tecnicos = document.getElementById('tbody_Tecnicos')
    var tr_Tecnicos = document.getElementsByName('tr_Tecnicos')
    var marker_Tecnicos = tr_Tecnicos.length

    for (let i = 0; i < marker_Tecnicos; i++) {
        tbody_Tecnicos.removeChild(tr_Tecnicos[0])
    }

    //Remove os tr's o conteudo da tabela de AuxEnf
    var tbody_AuxEnf = document.getElementById('tbody_AuxEnf')
    var tr_AuxEnf = document.getElementsByName('tr_AuxEnf')
    var marker_AuxEnf = tr_AuxEnf.length

    for (let i = 0; i < marker_AuxEnf; i++) {
        tbody_AuxEnf.removeChild(tr_AuxEnf[0])
    }


}


//====================================================================

//retorna o numero do mes escolhido
function EscolherMes(nome) {

    mes = nome.value
    h1.textContent = nome.innerText
    mesRes.setAttribute("value", mes)
    mesRes.textContent = "Valor Retornado: " + h1.innerText

    Remover()

    atualizar()

    return mes
}
//Verifica quantos dias o mes escolhido tem
function DiasDoMes() {
    var data = new Date(anoRes, mes, 0)
    return data.getDate(anoRes, mes)
}

function EscolherPeriodo(valor) {
    periodo = valor.value
    periodoRes.setAttribute("value", periodo)
    atualizar()
    return console.log(periodo)

}

//==============================================================================