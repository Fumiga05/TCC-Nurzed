

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













ListaDias()
clicar()
AdicionarEnfermeiros()
AdicionarTecnicos()



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
             // data.forEach(item => {

             listaEnfermeiros.push(data[0]);
             listaTecnicos.push(data[1])
             listaAux.push(data[2])


             console.log(listaEnfermeiros[0])
             console.log(listaTecnicos[0])
             console.log(listaAux[0])

             //});
             Remover()
             ListaDias()
             AdicionarEnfermeiros()
             AdicionarTecnicos()
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

    //for (let i = 0; i < usuariosAll.length; i++) {
    //    var listaUsuarios = []
    //    for (let j = 0; j < dias.length; j++) {
    //        listaUsuarios.push(listaAllUsuarios[i])
    //    }
    //    aux.push(listaUsuarios)
    //}

    return listaAllUsuarios

}

function AdicionarEnfermeiros() {
    //
    let opções = ["PR", "X", "ABA", "LTS", "LP", "LG", "FE", "FI", "PF", "CH", "TL", "AF", "TC", "FT"]
    var tabela = document.getElementById('tbody')

    //Repete a quantidade de users
    // for (let i = 0; i < listaEnfermeiros.length; i++) {
    listaEnfermeiros[0].forEach(item => {

    
        var tr = document.createElement("tr");
        tabela.appendChild(tr)
        tr.setAttribute("name", "tr_Usuarios")
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
    //
    let opções = ["PR", "X", "ABA", "LTS", "LP", "LG", "FE", "FI", "PF", "CH", "TL", "AF", "TC", "FT"]
    var tabela = document.getElementById('tbody2')

    //Repete a quantidade de users
    
    listaTecnicos[0].forEach(item => {


        var tr = document.createElement("tr");
        tabela.appendChild(tr)
        tr.setAttribute("name", "tr_Usuarios")
        tr.setAttribute("class", "tabela_cronograma_adm")

        var tdNome = document.createElement("td")
        tr.appendChild(tdNome)
        tdNome.setAttribute("class", "opcao_tabela_cronograma_enf nome_infermeiro_tabela_adm")
        tdNome.setAttribute("name", "nFuncionarios")
        tdNome.innerText = item["nome"]

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
    
    console.log("teste Adicionar linha usuarios")

    return listaTecnicos


}







function ListaDias() {
    //TR Enferme
    var tr = document.getElementById('tr')
    tr.setAttribute("class", "linha_1_cronograma_enf-")
    var tdNome = document.createElement("td")
    tr.appendChild(tdNome)
    tdNome.innerText = 'Enfermeiros'
    tdNome.setAttribute("name", "diasd")
    tdNome.setAttribute("class", "nome_infermeiro_tabela_adm")
    var tdCoren = document.createElement("td")
    tr.appendChild(tdCoren)
    tdCoren.innerText = 'Coren'
    tdCoren.setAttribute("name", "diasd")
    tdCoren.setAttribute("class", "nome_infermeiro_tabela_adm")

    for (let i = 1; i <= DiasDoMes(); i++) {
        var td = document.createElement("td")
        tr.appendChild(td)
        td.innerText = i
        td.setAttribute("name", "diasd")
        td.setAttribute("class", "select_infermeiro_tabela_adm")

        var input = document.createElement("input")
        input.setAttribute("type", "hidden")
        input.setAttribute("name", "dias")
        input.setAttribute("value", "")
    }
    var dias = document.getElementsByName('diasd')




}


function Remover() {
    //Remove os td's que foram adicionados anteriormente
    var tr = document.getElementById('tr')
    var dias = document.getElementsByName('diasd')
    var marker = dias.length

    for (let i = 0; i < marker; i++) {
        tr.removeChild(dias[0])
    }


    //Remove os tr's de usuário que foram adicionados anteriormente
    var tabela = document.getElementById('tbody')
    var tr_Usuarios = document.getElementsByName('tr_Usuarios')
    var usuarios = tr_Usuarios.length

    for (let i = 0; i < usuarios; i++) {

        tabela.removeChild(tr_Usuarios[0])

    }

    // while (tabela.firstChild){
    //     tabela.removeChild(tabela.firstChild)
    // }
    console.log("remover")

    return console.log(usuarios)
}





//====================================================================

//retorna o numero do mes escolhido
function EscolherMes(nome) {

    mes = nome.value
    h1.textContent = nome.innerText
    mesRes.setAttribute("value", mes)
    mesRes.textContent = "Valor Retornado: " + h1.innerText
  
    Remover()
    ListaDias()
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


