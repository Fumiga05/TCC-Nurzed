

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
                    "periodo":periodo


                })
            });
            const data = await req.json();
        }
    }
       
    
    
})





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

/*
async function AdicionarLegendas() {
    var legenda = document.getElementsByName('Legenda')
    var listaLegenda = []
    legenda.forEach(item => listaLegenda.push(item.value))
    listaLegenda = listaLegenda.join('')
    legendas.setAttribute("value", listaLegenda)

    console.log(listaLegenda);
    console.log(legenda);

    const req = await fetch('Cronograma', {
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ "data": listaLegenda })
    });

    const data = await req.json();
    console.log(data);
    
}
*/

function EscolherMes(nome) {

    var valor = nome.value
    h1.textContent = nome.innerText
    mesRes.setAttribute("value", valor)    
    mes = valor

}

function EscolherPeriodo(valor) {
    periodo = valor.value
    periodoRes.setAttribute("value", periodo)
    
}


