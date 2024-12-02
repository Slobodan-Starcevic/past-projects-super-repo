// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Header menu funtions
function dropDown() {
    document.getElementById("dropdown").classList.toggle("show");
}

window.onclick = function (event) {
    if (!event.target.matches('.dropdown-btn')) {
        var dropdownContent = document.querySelector(".dropdown-content");
        dropdownContent.classList.remove('show');
    }
}

//Header sticky functions
let prevScrollPosition = window.pageYOffset;

window.addEventListener('scroll', function () {
    let currentScrollPosition = window.pageYOffset;

    if (prevScrollPosition > currentScrollPosition) {
        document.querySelector('header').style.top = 0;
    }
    else {
        document.querySelector('header').style.top = '-100px';
    }
    prevScrollPosition = currentScrollPosition;
});


document.getElementById('speciesDropdown').addEventListener('change', function () {
    console.log('Species selected');
    var speciesId = this.value;

    fetch('/EmployeeDashboardNotes?handler=OnGetAnimals&speciesId=' + speciesId)
        .then(response => response.json())
        .then(data => {
            var animalsDropdown = document.getElementById('animalDropdown');
            animalsDropdown.innerHTML = '';
            
            var defaultOption = document.createElement('option');
            defaultOption.value = '';
            defaultOption.text = '-';
            animalsDropdown.appendChild(defaultOption);

            data.forEach(function (animal) {
                var option = document.createElement('option');
                option.value = animal.animalId;
                option.text = animal.animalName;
                animalsDropdown.appendChild(option);
            });
        });
});

