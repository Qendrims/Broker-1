var checks = {
  nameCheck: true,
  lastnameCheck: true,
  lastnameCheck: false,
};

//['nameCheck','lastnameCheck']

function checkButton() {
  var el = Object.keys(checks)
  for (var e of el) {
    if (!checks[e]) {//true
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



    var els = document.querySelectorAll("form > input");

    document.querySelectorAll(".together").forEach((element) => {
        element.addEventListener("keyup", (e) => Validate(e));
    });

    var displayAgentId = document.getElementsByClassName("form-check-input");
    var displayAgentDiv = document.getElementById("agentIdDiv");

    for (var i = 0; i < displayAgentId.length; i++) {
        displayAgentId[i].addEventListener('change', function (e) {
            if (e.target.value == "agent") {
                displayAgentDiv.classList.add('hidden');
            }
            else if (e.target.value == "simpleUser") {
                displayAgentDiv.classList.remove('hidden');
            }
        });
    }
}
