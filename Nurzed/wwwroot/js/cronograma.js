

//Dia Atual
var hoje = new Date()

//Ano Atual
var anoRes = hoje.getFullYear()
var ano = document.getElementById("ano")
ano.setAttribute("value",anoRes)



//Mes Atual/Selecionado
var h1 = document.getElementById("h1_mes")
var mes = hoje.getMonth() + 1
var mesRes = document.getElementById("mesRes")
mesRes.setAttribute("value", mes)  

//Periodo selecionado por padrão
var periodoRes = document.getElementById("periodoRes")
var periodo = 'manha'
periodoRes.setAttribute("value",periodo)

var legenda = document.getElementById('legendas')
const myForm = document.querySelector("#myForm")


var nFuncionarios = document.getElementsByName('nFuncionarios')
nFuncionarios = nFuncionarios.length

var dias = document.getElementsByName('dias')
dias = dias.length

var listaEnfermeiros = []
var listaTecnicos = []
var listaAux = []
var aux = []

//////////////////////////////////////////////////////////////////////////////////














clicar()



/////////////////////////////////////////////////////////////////////////////////
myForm.addEventListener("submit", async evt => {
    evt.preventDefault();


    var listaLegenda = AdicionarLegendas()
    var listaUsuarios = AdicionarUsuarios()
    var listaDatas = AdicionarDatas()


    for (let i = 0; i < nFuncionarios; i++) {
        var legendaUser = listaLegenda[i]
        for (let j = 0; j < listaDatas.length; j++) {
            const req = await fetch('/Cronograma/Cadastrar', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({
                    "id": "",
                    "id_Usuarios": listaUsuarios[i],
                    "data": listaDatas[j],
                    "legenda": legendaUser[j],
                    "periodo": periodo


                })
            });

        }
    }
})

/////////////////////////////////////////////////////////////////////////////////
 function clicar() {
     listaEnfermeiros = []
     listaTecnicos = []
     listaAux = []

     const req = fetch('https://localhost:44345/api/API/' + periodo, {
         method: 'GET',
         headers: { 'Content-Type': 'application/json' },


     })
         .then(data => data.json())
         .then(data => {           

             listaEnfermeiros.push(data[0]);
             listaTecnicos.push(data[1])
             listaAux.push(data[2])


             console.log(listaEnfermeiros[0])
             console.log(listaTecnicos[0])
             console.log(listaAux[0])

             
            Remover()
            ListaDias()

            AdicionarEnfermeiros()
            AdicionarTecnicos()
            AdicionarAuxEnf()

         })
         .catch((error) => console.log('Erro: ' + error.status));   
  
}


function AdicionarLegendas() {
    var legenda = document.getElementsByName('Legenda')

    var listaAllLegenda = []
    

  

    var aux = []
    var index = 0
    legenda.forEach(item => {
        listaAllLegenda.push(item.value)

    })


    for (let i = 0; i < nFuncionarios; i++) {
        var legendaUser = []
        for (let j = 0; j < dias; j++) {


            legendaUser.push(listaAllLegenda[index])
            index += 1
        }
        aux.push(legendaUser)

    }


    return aux
}

function AdicionarNomes() {
    var nome = document.getElementsByName('nome')
    var listaNomes = []

    nome.forEach(item => listaNomes.push(item.value))

    return listaNomes
}

function AdicionarDatas() {
   
    var diasAll = document.getElementsByName('dias')
    var data = new Date(anoRes, mes,0);
    
    var index = 0
    var aux = []
    var listaAllDias = []
    diasAll.forEach(item => {
        var data = anoRes + '-' + mes + '-' + item.value
        listaAllDias.push(data)
    })

   



    return listaAllDias
}

function AdicionarCronograma() {
    var listaAllCronograma = []
    var listaUsuarios = AdicionarUsuarios()
    var listaDatas = AdicionarDatas()
    var listaLegendas = AdicionarLegendas()
    var aux = []



    for (let i = 0; i < nFuncionarios; i++) {
    var listaCronograma = []
    for (let j = 0; i < listaUsuarios.length; j++) {
        var listaCronograma = []
        listaCronograma.push(listaUsuarios[j])
        listaCronograma.push(listaDatas[j])
        listaCronograma.push(listaLegendas[j])

        }
        aux.push(listaCronograma)
    }
   
    

    return aux
}

function AdicionarUsuarios() {

    var usuariosAll = document.getElementsByName('nome')

    var listaAllUsuarios = []


    usuariosAll.forEach(item => {
        listaAllUsuarios.push(item.value)
    })

 

    return listaAllUsuarios

}

function AdicionarEnfermeiros() {
    //Retira tabela Enfermeiros caso não tenha nenhum usuário
    if (listaEnfermeiros[0].length < 1) {
        var div_Enfermeiros = document.getElementById('div_Enfermeiros')
        div_Enfermeiros.parentNode.removeChild(div_Enfermeiros)
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
        console.log(listaEnfermeiros)

        var input = document.createElement("input");
        input.setAttribute("type", "hidden")
        input.setAttribute("value", "")
        input.setAttribute("name", "nome")

        var tdCoren = document.createElement("td")
        tr.appendChild(tdCoren)
        tdCoren.setAttribute("class", "opcao_tabela_cronograma_enf corem_infermeiro_tabela_adm")
        tdCoren.innerText = item["coren"]

        //Repete a quantidade de dias
        for (let j = 1; j <= DiasDoMes(); j++) {
           

            var td = document.createElement("td")
            tr.appendChild(td)
            td.setAttribute("class", "opcao_tabela_cronograma_enf")

            var inputDiasAll = document.createElement("input")
            inputDiasAll.setAttribute("type", "hidden")
            inputDiasAll.setAttribute("name", "diasAll")
            inputDiasAll.setAttribute("value", "")   

            var select = document.createElement("select")
            td.append(select)
            select.setAttribute("class", "select_cronograma_adm select_infermeiro_tabela_adm")
            select.setAttribute("name", "Legenda")
            //declaração das options
            opções.forEach(item => {
                var option = document.createElement("option")
                select.appendChild(option)
                option.innerText = item
                option.setAttribute("value", item)
            })

        }
    })
   // }
    console.log("teste Adicionar linha usuarios")

    return listaEnfermeiros

}

function AdicionarTecnicos() {
    //Retira tabela Tecnicos caso não tenha nenhum usuário
    if (listaTecnicos[0].length < 1) {
        var div_Tecnicos = document.getElementById('div_Tecnicos')
        div_Tecnicos.parentNode.removeChild(div_Tecnicos)
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
        console.log(listaTecnicos)

        var input = document.createElement("input");
        input.setAttribute("type", "hidden")
        input.setAttribute("value", "")
        input.setAttribute("name", "nome")

        var tdCoren = document.createElement("td")
        tr.appendChild(tdCoren)
        tdCoren.setAttribute("class", "opcao_tabela_cronograma_enf corem_infermeiro_tabela_adm")
        tdCoren.innerText = item["coren"]

        //Repete a quantidade de dias
        for (let j = 1; j <= DiasDoMes(); j++) {


            var td = document.createElement("td")
            tr.appendChild(td)
            td.setAttribute("class", "opcao_tabela_cronograma_enf")

            var inputDiasAll = document.createElement("input")
            inputDiasAll.setAttribute("type", "hidden")
            inputDiasAll.setAttribute("name", "diasAll")
            inputDiasAll.setAttribute("value", "")

            var select = document.createElement("select")
            td.append(select)
            select.setAttribute("class", "select_cronograma_adm select_infermeiro_tabela_adm")
            select.setAttribute("name", "Legenda")
            //declaração das options
            opções.forEach(item => {
                var option = document.createElement("option")
                select.appendChild(option)
                option.innerText = item
                option.setAttribute("value", item)
            })

        }
    })
    // }
    console.log("teste Adicionar linha usuarios")

    return listaTecnicos
}


function AdicionarAuxEnf() {
    //Retira tabela AuxEnf caso não tenha nenhum usuário
    if (listaAux[0].length < 1) {
        var div_AuxEnf = document.getElementById('div_AuxEnf')
        div_AuxEnf.parentNode.removeChild(div_AuxEnf)
    }
    


    let opções = ["PR", "X", "ABA", "LTS", "LP", "LG", "FE", "FI", "PF", "CH", "TL", "AF", "TC", "FT"]
    var tabela = document.getElementById('tbody_AuxEnf')

    //Repete a quantidade de users

    listaAux[0].forEach(item => {

        console.log(tabela)
        var tr = document.createElement("tr");
        tabela.appendChild(tr)
        tr.setAttribute("name", "tr_AuxEnf")
        tr.setAttribute("class", "tabela_cronograma_adm")

        var tdNome = document.createElement("td")
        tr.appendChild(tdNome)
        tdNome.setAttribute("class", "opcao_tabela_cronograma_enf nome_infermeiro_tabela_adm")
        tdNome.setAttribute("name", "nFuncionarios")
        tdNome.innerText = item["nome"]
        console.log(listaTecnicos)

        var input = document.createElement("input");
        input.setAttribute("type", "hidden")
        input.setAttribute("value", "")
        input.setAttribute("name", "nome")

        var tdCoren = document.createElement("td")
        tr.appendChild(tdCoren)
        tdCoren.setAttribute("class", "opcao_tabela_cronograma_enf corem_infermeiro_tabela_adm")
        tdCoren.innerText = item["coren"]

        //Repete a quantidade de dias
        for (let j = 1; j <= DiasDoMes(); j++) {


            var td = document.createElement("td")
            tr.appendChild(td)
            td.setAttribute("class", "opcao_tabela_cronograma_enf")

            var inputDiasAll = document.createElement("input")
            inputDiasAll.setAttribute("type", "hidden")
            inputDiasAll.setAttribute("name", "diasAll")
            inputDiasAll.setAttribute("value", "")

            var select = document.createElement("select")
            td.append(select)
            select.setAttribute("class", "select_cronograma_adm select_infermeiro_tabela_adm")
            select.setAttribute("name", "Legenda")
            //declaração das options
            opções.forEach(item => {
                var option = document.createElement("option")
                select.appendChild(option)
                option.innerText = item
                option.setAttribute("value", item)
            })

        }
    })
    // }
    console.log("teste Adicionar linha usuarios")

    return listaEnfermeiros

}






function ListaDias() {
    //Tabela Enfermeiros
    var tr_Enfermeiros = document.getElementById('tr_Enfermeiros')
    tr_Enfermeiros.setAttribute("class", "linha_1_cronograma_enf") 

    var tdNome_Enfermeiros = document.createElement("td")
    tr_Enfermeiros.appendChild(tdNome_Enfermeiros)
    tdNome_Enfermeiros.innerText = 'Enfermeiros'
    tdNome_Enfermeiros.setAttribute("name", "diasd")
    tdNome_Enfermeiros.setAttribute("class", "nome_infermeiro_tabela_adm")

    var tdCoren_Enfermeiros = document.createElement("td")
    tr_Enfermeiros.appendChild(tdCoren_Enfermeiros)
    tdCoren_Enfermeiros.innerText = 'Coren'
    tdCoren_Enfermeiros.setAttribute("name", "diasd")
    tdCoren_Enfermeiros.setAttribute("class", "nome_infermeiro_tabela_adm")
    //Tabela Técnicos
    var tr_Tecnicos = document.getElementById('tr_Tecnicos')
    tr_Tecnicos.setAttribute("class", "linha_1_cronograma_enf")   

    var tdNome_Tecnicos = document.createElement("td")
    tr_Tecnicos.appendChild(tdNome_Tecnicos)
    tdNome_Tecnicos.innerText = 'TÉC. DE ENFERMAGEM'
    tdNome_Tecnicos.setAttribute("name", "diasd")
    tdNome_Tecnicos.setAttribute("class", "nome_infermeiro_tabela_adm")    

    var tdCoren_Tecnicos = document.createElement("td")
    tr_Tecnicos.appendChild(tdCoren_Tecnicos)
    tdCoren_Tecnicos.innerText = 'Coren'
    tdCoren_Tecnicos.setAttribute("name", "diasd")
    tdCoren_Tecnicos.setAttribute("class", "nome_infermeiro_tabela_adm")

    //Tabela Aux.Enfermagem
    var tr_AuxEnf = document.getElementById('tr_AuxEnf')
    tr_AuxEnf.setAttribute("class", "linha_1_cronograma_enf")

    var tdNome_AuxEnf = document.createElement("td")
    tr_AuxEnf.appendChild(tdNome_AuxEnf)
    tdNome_AuxEnf.innerText = 'AUX.ENFERMAGEM'
    tdNome_AuxEnf.setAttribute("name", "diasd")
    tdNome_AuxEnf.setAttribute("class", "nome_infermeiro_tabela_adm")

    var tdCoren_AuxEnf = document.createElement("td")
    tr_AuxEnf.appendChild(tdCoren_AuxEnf)
    tdCoren_AuxEnf.innerText = 'Coren'
    tdCoren_AuxEnf.setAttribute("name", "diasd")
    tdCoren_AuxEnf.setAttribute("class", "nome_infermeiro_tabela_adm")




    for (let i = 1; i <= DiasDoMes(); i++) {
        var td_Enfermeiros = document.createElement("td")
        tr_Enfermeiros.appendChild(td_Enfermeiros)
        i >= 10 ? td_Enfermeiros.innerText = i : td_Enfermeiros.innerText = "0" + i
        td_Enfermeiros.setAttribute("name", "diasd")
        td_Enfermeiros.setAttribute("class", "select_infermeiro_tabela_adm")

        var td_Tecnicos = document.createElement("td")        
        tr_Tecnicos.appendChild(td_Tecnicos)        
        i >= 10 ? td_Tecnicos.innerText = i : td_Tecnicos.innerText = "0" + i  
        td_Tecnicos.setAttribute("name", "diasd")
        td_Tecnicos.setAttribute("class", "select_infermeiro_tabela_adm")

        var td_AuxEnf = document.createElement("td")
        tr_AuxEnf.appendChild(td_AuxEnf)
        i >= 10 ? td_AuxEnf.innerText = i : td_AuxEnf.innerText = "0" + i
        td_AuxEnf.setAttribute("name", "diasd")
        td_AuxEnf.setAttribute("class", "select_infermeiro_tabela_adm")


        var input = document.createElement("input")
        input.setAttribute("type", "hidden")
        input.setAttribute("name", "dias")
        input.setAttribute("value", "")
    }
    var dias = document.getElementsByName('diasd')

    
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
   
    clicar()
    
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
    clicar()
    return console.log(periodo)

}

//==============================================================================


