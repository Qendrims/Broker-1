let username = document.getElementById("username");
let password = document.getElementById("password");

let usernameError = document.getElementById("username_error");
let passError = document.getElementById("password_error");  
let btnLogin = document.getElementById('submit-btn')

username.addEventListener('keyup',e=>enableButton(e,password))

password.addEventListener('keyup',e=>enableButton(e,username))

//enable button when username and password input are not empty
function enableButton(e,input){
    if(e.target.value != "" && input.value != ""){
      
        btnLogin.disabled = false;
        btnLogin.style.cursor = 'pointer !important';
    }
}

//todo: switch with backend data

var users=[
    {
        username:"adhurim",
        email:'adhurim@gmail.com',
        password:"123123123",
        
    },
    {
        username:"lir",
        email:'lir@gmail.com',
        password:"liriballata"   
    },
    {
        username:"meli",
        email: "meli@gmail.com",
        password: "123123123",

    },
    {
        username: "nora",
        email: "nora@gmail.com",
        password: "123123123",

    },
]; 

var verifyUsername = function (e) {
  e.preventDefault();

  let hasError = true;
  users.forEach((user) => {
    if (
      (username.value.toLowerCase() == user.username ||
        username.value.toLowerCase() == user.email) &&
      password.value == user.password
    ) {
        //username starting with upercase first letter
      localStorage.setItem("broker-username", user.username[0].toUpperCase() + user.username.slice(1));
      location.href = "Index";
      hasError = false;
    }
  });

  if (hasError) {
      btnLogin.disabled = true;
      btnLogin.style.cursor = 'not-allowed !important'
    usernameError.style.display = "block";
    username.value = "";
    passError.style.display = "block";
    password.value = "";
    username.focus();
  }
};

document.getElementById("myForm").addEventListener("submit", function (e) {
  verifyUsername(e);
});
