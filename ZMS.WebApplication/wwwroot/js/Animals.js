$(document).ready(function () {

	GetAnimals();

    $("#getAll").click(function (event) {
        event.preventDefault();
        GetAnimals();
    });

    $("#feedAll").click(function (event) {
        event.preventDefault();
        FeedAllAnimals();
    });

    $("#addNew").click(function (event) {
        event.preventDefault();
        AddNewAnimals();
    });
});


function GetAnimals() {
    console.log("Get all animals");
    $.ajax({
        url: '/api/animals',
        type: 'GET',
        contentType: "application/json",
        success: function (animals) {
            console.log("GetAnimals from BackEnd Successful");
            WriteResponse(animals);
        }
    });
}

function FeedAllAnimals() {
    console.log("Feed all animals");
    $.ajax({
        url: '/api/animals',
        type: 'PUT',
        contentType: "application/json",
        success: function () {
            console.log("Success");
            GetAnimals();
        }
    });
}

function AddNewAnimals() {
    console.log("Add new animal");

    var item = {
        Name: $("#animalName").val(),
        Sex: $("#animalSex").val(),
        Age: $("#animalAge").val(),
        AnimalClassId: 1
    };

    $.ajax({
        url: '/api/animals',
        type: 'POST',
        data: JSON.stringify(item),
        contentType: "application/json",
        success: function () {
            console.log("Success");
            GetAnimals();
        }
    });
}

function WriteResponse(animals) {
    var rows = "";
    $.each(animals, function (index, animal) {
        rows += row(animal);
    });

    $("table tbody").html(rows);
}

var row = function (animal) {
    var animalSex = "Male";
    if (animal.sex === 1) {
        animalSex = "Female";
    }

    var strResult = `<tr data-rowid='${animal.id}'> 
        <td>${animal.id}</td>
		<td>${animal.name}</td>
        <td>${animalSex}</td>
        <td>${animal.age}</td>
        <td>${animal.isHungry}</td></tr>`;

    return strResult;
}