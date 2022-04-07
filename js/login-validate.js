let username = document.getElementById("username");
let password = document.getElementById("password");

let usernameError = document.getElementById("username_error");
let passError = document.getElementById("password_error");



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
      localStorage.setItem("broker-username", user.username);
      location.href = "../html/views/welcomePage.html";
      hasError = false;
    }
  });

  if (hasError) {
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
