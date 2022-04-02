
let usernameError = document.getElementById('username_error');
let passError = document.getElementById('password_error');



var verifyUsername = function (e) {
    e.preventDefault();
    let username = document.getElementById('username').value;
let password = document.getElementById('password').value;

   let isLoggedIn = false;
    users.forEach(user => {
        if(username == user.username && password == user.password){
            localStorage.setItem('broker-username',username);
           location.href = '../html/postpage.html';
   isLoggedIn = true;
        }
    });

    if(!isLoggedIn){
        usernameError.style.display = 'block';
        passError.style.display='block';
    }
}


document.getElementById('myForm').addEventListener("submit",function(e){
    verifyUsername(e);
});