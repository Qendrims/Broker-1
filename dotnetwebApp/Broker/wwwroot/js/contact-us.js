let nameInput = document.getElementById('name-input');
let nameError = document.getElementById('name-error');
let lastnameInput = document.getElementById('lastname-input');
let lastnameError = document.getElementById('lastname-error');
let emailInput = document.getElementById('email-input');
let emailError = document.getElementById('email-error');
let komentInput = document.getElementById('koment-input');
let komentError = document.getElementById('koment-error');
let formError = document.getElementById('form-error');

document.querySelector('.forma').addEventListener('submit',e=>{
    e.preventDefault();


    formError.style.display = 'none';
    if(nameInput.value == "" || lastnameInput.value == "" || emailInput.value == "" || komentInput.value == ""){
     formError.style.display = 'block';
     formError.textContent = "Ju lutem plotesoni te gjitha fushat"
    } else {   
    }
})