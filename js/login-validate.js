
let usernameError = document.getElementById('username_error');
let passError = document.getElementById('password_error');



var users=[
    {
        username:"Adhurim",
        email:'adhurim@gmail.com',
        password:"123123123"
    },
    {
        username:"Lir",
        email:'lir@gmail.com',
        password:"liriballata"
    },
]; 

var verifyUsername = function (e) {
    e.preventDefault();
    let username = document.getElementById('username').value;
let password = document.getElementById('password').value;

   let isLoggedIn = false;
    users.forEach(user => {
        if((username.value == user.username || username.value == user.email) && password.value == user.password){
            localStorage.setItem('broker-username',user.username);
           location.href = '../html/views/welcomePage.html';
   isLoggedIn = true;
        }
    });

    if(!isLoggedIn){
        usernameError.style.display = 'block';
        username.value = "";
        passError.style.display='block';
        password.value = "";
        username.focus();
    }
}


document.getElementById('myForm').addEventListener("submit",function(e){
    verifyUsername(e);
});