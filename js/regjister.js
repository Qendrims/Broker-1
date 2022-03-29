function Validate(e){
    e.preventDefault();
    
    var name = document.getElementById("firstname");
    var lastname = document.getElementById("lastname").value;
    var username = document.getElementById("username").value;
    var email = document.getElementById("email").value;
    var pass = document.getElementById("password").value;
    var confirmPass = document.getElementById("conf_pass").value;
    
    

    if(name == "" || name == null){
        
    }
    else{
        nameCheck=true;
    }
    if(lastname == "" || lastname == null){

    }

}



var nameCheck = lastnameCheck = usernameCheck = emailCheck = passCheck = confirmPassCheck = false
document.querySelectorAll('input').forEach(inp =>{
    inp.addEventListener('keyup',e=>{
        console.log(nameCheck)
        if(e.target.name == "firstname" && e.target.value != ""){
            
            nameCheck = true;
        }
        else document.getElementById("firstname_err").classList.remove("hidden");
    })
})
