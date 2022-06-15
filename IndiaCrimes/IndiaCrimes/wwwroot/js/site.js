// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//[1] Crime Fact Table
//crimeID
//location
//year
//precovID
//pstoleID

//[1.2]  Property Recovered Table
//precovID
//precov
//precoVal

//[1.3] Property Stolen Table
//pstoleID
//pstole
//pstoleVal

//[2] Criminal Fact Table
//criminalID
//location
//year
//genderID
//asixtnUID
//aeghtntothirtID
//athirttofithID
//afithabovID

//[2.1] Gender Table
//gender
//genderID

//[2.2] Age 16 and Under Table
//asixtnUID
//asixtnU

//[2.3] Age 18 to 30 Table
//aeghtntothirtID
//aeghtntothirt

//[2.4] Age 30 to 50 Table
//athirttofithID
//athirttofith

//[2.5] Age 50 and Up Table
//afithabovID
//afithabov



$(document).ready(function () {
    //******* the following requests will get the data for the drop down menu when the DOM is loaded  ********
    $.getJSON('api/CrimeFact')
        .done(function (data) {
            // On success, 'data' contains a list of years.
            let yearArray = data;
            let yearSelectElement = document.getElementById("yearSelect");
            yearArray.forEach(function (value) {
                yearSelectElement.appendChild(new Option(value.year, value.year)); //***** first char of the prop needs to be lower case even if it is upper in the DB ******
            });
        });

    $.getJSON('api/CrimeFact')
        .done(function (data) {
            // On success, 'data' contains a list of location.
            let locationArray = data;
            let locationSelectElement = document.getElementById("locationSelect");
            locationArray.forEach(function (value) {
                locationSelectElement.appendChild(new Option(value.location, value.location));
            });
        });

    $.getJSON('api/Gender')
        .done(function (data) {
            // On success, 'data' contains a list of gender.
            let genderArray = data;
            let genderSelectElement = document.getElementById("genderSelect");
            genderArray.forEach(function (value) {
                genderSelectElement.appendChild(new Option(value.gender, value.genderId));
            });
        });
});

function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}

async function getNumberOfProperties() {
    console.log(`+++++++++++++++++++++++++++getNumberOfProperties++++++++++++++++++++++++++`)
    document.getElementById('numberPropertiesStolenDescription').innerHTML = `getting the data...`;
    await sleep(2000);

    let yearSelectElement = document.getElementById("yearSelect");
    let yearValue = yearSelectElement.options[yearSelectElement.selectedIndex].value;

    // https://stackoverflow.com/questions/9499794/single-controller-with-multiple-get-methods-in-asp-net-web-api
    $.getJSON(`api/IndiaCrimeDB/GetNumberOfProperties/${yearValue}`).done(function (data) {
        console.log(`data is ${data}`);
        $('#numberPropertiesStolenDescription').text(`that store sold $${data}.`);
    }).fail(function (jqXHR, textStatus, error) {
        $('#numberPropertiesStolenDescription').text(`error: ${error}`);
    });
}

async function getValueProperties() {
    console.log(`+++++++++++++++++++++++++++getvalueProperties++++++++++++++++++++++++++`)
    document.getElementById('valuePropertiesStolenDescription').innerHTML = `getting the data...`;
    await sleep(2000);

    let locationSelectElement = document.getElementById("locationSelect");
    let locationValue = locationSelectElement.options[locationSelectElement.selectedIndex].value;

    $.getJSON(`api/IndiaCrimeDB/GetValueProperties/${locationValue}`).done(function (data) {
        console.log(data)
        let valuePropertiesStolenDescription = document.getElementById('valuePropertiesStolenDescription');
        let txt = `<strong>StoreID | Count</strong><br>`;
        data.forEach((element) => {
            console.log(`StoreID = ${element['storeID']} | Count = ${element['count']}`)
            txt += `=  ${element['storeID']} | ${element['count']}<br>`
        })
        console.log(`txt = ${txt}`)
        totalStoreDataDescription.innerHTML = txt;
        //$('#totalStoreDataDescription').innerHTML = "something else";
        //$('#totalStoreDataDescription').text(`DONE GETTING DATA === ${data}`);
    }).fail(function (jqXHR, textStatus, error) {
        $('#valuePropertiesStolenDescription').text(`error: ${error}`);
    });
}

async function getGenderData() {
    console.log(`+++++++++++++++++++++++++++getGenderData++++++++++++++++++++++++++`)
    document.getElementById('getGenderDescription').innerHTML = `getting the data...`;
    await sleep(2000);

    let genderSelectElement = document.getElementById("genderSelect");
    let genderValue = genderSelectElement.options[genderSelectElement.selectedIndex].value;

    $.getJSON(`api/IndiaCrimeDB/GetGenderData/${genderValue}`).done(function (data) {
        console.log(data)
        let totalStoreDataDescription = document.getElementById('getGenderDescription');
        let txt = `<strong>StoreID | Count</strong><br>`;
        data.forEach((element) => {
            console.log(`StoreID = ${element['storeID']} | Count = ${element['count']}`)
            txt += `=  ${element['storeID']} | ${element['count']}<br>`
        })
        console.log(`txt = ${txt}`)
        totalStoreDataDescription.innerHTML = txt;
        //$('#totalStoreDataDescription').innerHTML = "something else";
        //$('#totalStoreDataDescription').text(`DONE GETTING DATA === ${data}`);
    }).fail(function (jqXHR, textStatus, error) {
        $('#getGenderDescription').text(`error: ${error}`);
    });
}