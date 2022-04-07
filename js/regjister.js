var checks = {
  nameCheck: true,
  lastnameCheck: true,
  lastnameCheck: false,
};

//['nameCheck','lastnameCheck']

function checkButton(){
    var el=Object.keys(checks)
    for(var e of el){
        if(!checks[e]){//true
            document.getElementById("sumbit-btn").disabled = true;
            return;
        } 
    }
    document.getElementById("sumbit-btn").disabled = false;

}

function Validate(e) {
  e.preventDefault();

  if (e.target.value == null || e.target.value == "") {
    e.target.nextElementSibling.classList.remove("hidden");
    checks[e.target.getAttribute("data-check")] = false;
  } else {
    e.target.nextElementSibling.classList.add("hidden");
    checks[e.target.getAttribute("data-check")] = true;
  }

  checkButton();

  var name = document.getElementById("firstname").value;
  var lastname = document.getElementById("lastname").value;
  var username = document.getElementById("username").value;
  var email = document.getElementById("email").value;
  var pass = document.getElementById("password").value;
  var confirmPass = document.getElementById("conf_pass").value;

  var nameCheck =
    (lastnameCheck =
    usernameCheck =
    emailCheck =
    passCheck =
    confirmPassCheck =
      false);
  if (name == "" || name == null) {
    document.getElementById("firstname_err").classList.remove("hidden");
  } else {
    nameCheck = true;
    document.getElementById("firstname_err").classList.add("hidden");
  }
  if (lastname == "" || lastname == null) {
    document.getElementById("lastname_error").classList.remove("hidden");
  } else {
    lastnameCheck = true;
    document.getElementById("lastname_error").classList.add("hidden");
  }
  if (username == "" || username == null) {
    document.getElementById("username_error").classList.remove("hidden");
  } else {
    usernameCheck = true;
    document.getElementById("username_error").classList.add("hidden");
  }
  if (email == "" || email == null) {
    document.getElementById("email_error").classList.remove("hidden");
  } else {
    emailCheck = true;
    document.getElementById("email_error").classList.add("hidden");
  }
  if (pass == "" || pass == null) {
    document.getElementById("password_error").classList.remove("hidden");
  } else {
    passCheck = true;
    document.getElementById("password_error").classList.add("hidden");
  }
  if (confirmPass == "" || confirmPass != pass) {
    document
      .getElementById("confirm_password_error")
      .classList.remove("hidden");
  } else {
    confirmPassCheck = true;
    document.getElementById("confirm_password_error").classList.add("hidden");
  }
  if (
    nameCheck &&
    lastnameCheck &&
    emailCheck &&
    usernameCheck &&
    passCheck &&
    confirmPassCheck
  ) {
    document.getElementById("sumbit-btn").disabled = false;
    document.getElementById("sumbit-btn").style.cursor = "pointer";
  }
}

var els = document.querySelectorAll("form > input");

document.querySelectorAll(".together").forEach((element) => {
  element.addEventListener("keyup", (e) => Validate(e));
});
