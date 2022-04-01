let username = document.getElementById('username');
let password = document.getElementById('password');

let usernameError = document.getElementById('username_error');
let passError = document.getElementById('password_error');



username.addEventListener('keyup',e=>{
    username.value = e.target.value;
})

password.addEventListener('keyup',e=>{
    password.value = e.target.value;
    if(password.value.length < 7)
    passError.style.display = 'block'
    else
    passError.style.display = 'none'
})

var users=[
    {
        username:"Adhurim",
        email:'adhurim@gmail.com',
        password:"123123123"
    },
    {
        username:"Lir",
        email:'liri@gmail.com',
        password:"liriballata"
    },
]; 

var verifyUsername = function (e) {
    e.preventDefault();

   let isLoggedIn = false;
    users.forEach(user => {
        if((username.value == user.username || username.value == user.email) && password.value == user.password){
            localStorage.setItem('broker-username',username.value);
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