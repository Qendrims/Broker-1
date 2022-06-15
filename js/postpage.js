var data=[];
let title = document.getElementById('exampleInputEmail1');
let file = document.getElementById('inputGroupFile01');
let description = document.getElementById('description');
var body = document.getElementById("post-preview");

function postPreview(e){
    e.preventDefault();
    var text=`
    <h1>Post Preview</h1>
            <div id="inner-posts">
               <h1>${title.value}</h1>
                <p>${description.value}</p>
            </div>`;
    body.innerHTML +=text;
}

<<<<<<< HEAD
document.getElementById("myForm").addEventListener("submit",e=>postPreview(e));
let welcome = document.getElementById('usernameWelcome');
let username = localStorage.getItem('broker-username');
if(username != null){
    welcome.textContent = `Welcome ${username}`
}
=======
document.getElementById("myForm").addEventListener("submit",e=>postPreview(e));
>>>>>>> 8f709ac5b95d0865e74671e62dae114185dcf686
