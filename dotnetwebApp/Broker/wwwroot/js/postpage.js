let welcome = document.getElementById('usernameWelcome');
let username = localStorage.getItem('broker-username');
if(username != null){
    welcome.textContent = `Welcome ${username}`
}