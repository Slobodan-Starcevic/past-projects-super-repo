document.getElementById('speciesDropdown').addEventListener('change', async function () {
    const speciesId = this.value;

    try {
        const response = await fetch(`/EmployeeDashboardNotes?handler=OnGetAnimals&speciesId=${speciesId}`);
        console.log(response);
        const data = await response.json();
        console.log(data);

        const animalsDropdown = document.getElementById('animalDropdown');
        animalsDropdown.innerHTML = '';

        const defaultOption = document.createElement('option');
        defaultOption.value = '';
        defaultOption.text = '-';
        animalsDropdown.appendChild(defaultOption);

        data.forEach(animal => {
            const option = document.createElement('option');
            option.value = animal.animalId;
            option.text = animal.animalName;
            animalsDropdown.appendChild(option);
        });
    } catch (error) {
        console.error('Error fetching animals:', error);
    }
});

function confirmProfileChange() {
    if (confirm('Are you sure you want to change your profile info?')) {
        document.getElementById('delete-form2').submit();
    } else {
        return false;
    }
}

