let username = localStorage.getItem('broker-username');
let homepageHeader = document.getElementById('homepageHeader');

homepageHeader.innerHTML = username == null ? `
<ul class="nav-list" id="list1">
<li id="Home"><a href="#">Home</a></li>
<li id="About"><a href="#">About</a></li>
<li id="Contact"><a href="#">Contact</a></li>
<li id="SignIn"><a href="#" >Sign In</a></li>
</ul>
<img src="../../imgs/logo.jpg" alt="logo">
<ul class="nav-list" id="list2">
<li id="Buy"><a href="#">Buy</a></li>
<li id="Sell"><a href="#">Sell</a></li>
<li id="Rent"><a href="#">Rent</a></li>
<li id="Agents"><a href="#">Agents</a></li>
</ul>
` :  `
<ul class="nav-list" id="list1">
<li id="Home"><a href="#">Home</a></li>
<li id="About"><a href="#">About</a></li>
<li id="Contact"><a href="#">Contact</a></li>
</ul>
<img src="../../imgs/logo.jpg" alt="logo">
<div class="dropdown">
  <button class="btn dropdown-toggle" type="button" id="dropdownMenuButton2" data-bs-toggle="dropdown" aria-expanded="false">
    Welcome ${username}
  </button>
  <ul class="dropdown-menu dropdown-menu-dark" aria-labelledby="dropdownMenuButton2">
    <li><a class="dropdown-item active" href="#">Action</a></li>
    <li><a class="dropdown-item" href="#">Another action</a></li>
    <li><a class="dropdown-item" href="#">Something else here</a></li>
    <li><hr class="dropdown-divider"></li>
    <li id="LogOut"><a class="dropdown-item" href="#">Log Out</a></li>
  </ul>
</div>
`;



let signIn = document.getElementById('SignIn');
signIn?.addEventListener('click',()=>{
    
    location.href= '../login-page.html';
})

let logout = document.getElementById('LogOut');
logout?.addEventListener('click',()=>{
    localStorage.removeItem('broker-username');
    location.reload();
})
