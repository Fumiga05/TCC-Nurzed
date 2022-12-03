let today = new Date();
let currentMonth = today.getMonth();
let currentYear = today.getFullYear();
let selectYear = document.getElementById("year");
let selectMonth = document.getElementById("month");

let months = ["JANEIRO", "FEVEREIRO", "MARÇO", "ABRIL", "MAIO", "JUNHO", "JULHO", "AGOSTO", "SETEMBRO", "OUTUBRO", "NOVEMBRO", "DEZEMBRO"];

let monthAndYear = document.getElementById("monthAndYear");
showCalendar(currentMonth, currentYear);

function next() {
    currentYear = (currentMonth === 11) ? currentYear + 1 : currentYear;
    currentMonth = (currentMonth + 1) % 12;
    showCalendar(currentMonth, currentYear);
}

function previous() {
    currentYear = (currentMonth === 0) ? currentYear - 1 : currentYear;
    currentMonth = (currentMonth === 0) ? 11 : currentMonth - 1;
    showCalendar(currentMonth, currentYear);
}

function jump() {
    currentYear = parseInt(selectYear.value);
    currentMonth = parseInt(selectMonth.value);
    showCalendar(currentMonth, currentYear);
}

function createHref(el) {
    let ancora;
    let teste = 1;

    const a = document.createElement("a")
    a.setAttribute("class", "numero_calendario")

    if (teste == 1) {
        ancora = "/Plantao/Plantao"
    } else if (teste == 2) {
        ancora = "/Plantao/Plantao"
    } else if (teste == 3) {
        ancora = "/Plantao/Plantao"
    } else {
        alert("Erro encontrado , tente outra hora! :(")
    }

    a.setAttribute('href', ancora)
    const x = document.createTextNode(el)

    a.append(x)
    return a
}

function voltarMes() {
    return currentMonth
}

function voltaAno() {
    return currentYear
}

function mandaStorage(dia) {
    localStorage.setItem("dia_adm", dia);

    let volta_mes = voltarMes(); //devolve numero do mes -1
    localStorage.setItem("mes", months[volta_mes])

    let mesNumeral = voltarMes() + 1;
    localStorage.setItem("mesNumeral", mesNumeral)

    let volta_ano = voltaAno(); //ano atual

}

function mandaStorageEditar() {
    let volta_mes = voltarMes(); //devolve numero do mes -1
    localStorage.setItem("mes", months[volta_mes])

    let mesNumeral = voltarMes() + 1;
    localStorage.setItem("mesNumeral", mesNumeral)
}

function showCalendar(month, year) {

    let firstDay = (new Date(year, month)).getDay();
    let daysInMonth = 32 - new Date(year, month, 32).getDate();

    let tbl = document.getElementById("calendar-body");

    tbl.innerHTML = "";

    monthAndYear.innerHTML = months[month];//onde estava o ano
    selectYear.value = year;
    selectMonth.value = month;

    let date = 1;
    for (let i = 0; i < 6; i++) {

        let row = document.createElement("tr");

        for (let j = 0; j < 7; j++) {
            if (i === 0 && j < firstDay) {
                let cell = document.createElement("td");
                cell.onclick = () => mandaStorage();
                let cellText = document.createTextNode("");
                cell.appendChild(cellText);
                row.appendChild(cell);
            }
            else if (date > daysInMonth) {
                break;
            }

            else {
                let cell = document.createElement("td");
                let cellText = document.createTextNode(`<a href=""> ${date}</a>`);
                if (date === today.getDate() && year === today.getFullYear() && month === today.getMonth()) {
                    cell.classList.add("bg-info");
                }
                cell.appendChild(createHref(date));
                row.appendChild(cell);
                date++;
            }
        }
        tbl.appendChild(row);
    }
    dataClique();
}



function dataClique() {
    $(".numero_calendario").on("click", function () {
        mandaStorage($(this).text());
    });
}