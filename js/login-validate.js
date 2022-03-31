var verifyUsername = function (e) {
    e.preventDefault();
    var users=[
        {
            username:"Lir",
            password:"liriballata"
        },
        {
            username:"Adhurim",
            password:"Kra"
        }
    ]; 

    users.forEach(user => {
        if(username == user.username.value && pass == user.password){
            alert("Sucess");
        }
        
    });
}


document.getElementById('myForm').addEventListener("submit",function(e){
    verifyUsername(e);
    verifyPass(e);
});