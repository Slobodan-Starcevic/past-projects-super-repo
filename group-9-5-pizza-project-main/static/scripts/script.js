
const boxes = document.querySelectorAll('.pizza-amount');

boxes.forEach(box => {
  box.addEventListener('change', function handleClick(event) {
    const pepamount = +document.getElementsByName('pepperoni_amount')[0].value;
    const maramount = +document.getElementsByName('margherita_amount')[0].value;
    const hawamount = +document.getElementsByName('hawaii_amount')[0].value;
    const cheeseamount = +document.getElementsByName('cheeselover_amount')[0].value;
    const meatamount = +document.getElementsByName('meatlover_amount')[0].value;
    const tot= pepamount*10 + maramount*15 + hawamount*12 + cheeseamount*13 + meatamount*14;
    
    document.getElementById('total').textContent = tot;
});
});