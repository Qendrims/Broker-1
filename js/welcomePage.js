let username = localStorage.getItem("broker-username");
let navListLeft = document.getElementById("list1");
let navHeader = document.getElementById("homepageHeader");
let navFixed = navHeader.offsetTop;

function navbarFixed() {
  if (window.pageYOffset > navFixed) {
    navHeader.classList.add("fixed")
  } else {
    navHeader.classList.remove("fixed");
  }
}
window.onscroll = function(){
  navbarFixed();
}

navListLeft.innerHTML +=
  username == null
    ? `
<li id="SignIn"><a href="#" >Sign In</a></li>`
    : ``;

navHeader.innerHTML +=
  username == null
    ? `
    <ul class="nav-list" id="list2">
      <li id="Buy"><a href="#">Buy</a></li>
      <li id="Sell"><a href="#">Sell</a></li>
      <li id="Rent"><a href="#">Rent</a></li>
      <li id="Agents"><a href="#">Agents</a></li>
</ul>
`
    : `
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

let signIn = document.getElementById("SignIn");
signIn?.addEventListener("click", () => {
  location.href = "../login-page.html";
});

let logout = document.getElementById('LogOut');
logout?.addEventListener('click',()=>{
    localStorage.removeItem('broker-username');
    location.reload();
})

let posts = [{
  title: 'Titulli1',
  description: 'Lorem ipsum dolor sit amet consectetur, adipisicing elit. Ullam, excepturi voluptatem? Officia repellat praesentium error quibusdam incidunt quasi minus non nihil. Mollitia adipisci nihil illo natus cum sunt blanditiis aliquid.',
  category: 'Home',
  img: 'grid1.jpg'
},
{
  title: 'Titulli2',
  description: 'Lorem ipsum dolor sit amet consectetur, adipisicing elit. Ullam, excepturi voluptatem? Officia repellat praesentium error quibusdam incidunt quasi minus non nihil. Mollitia adipisci nihil illo natus cum sunt blanditiis aliquid.',
  category: 'Flat',
  img: 'grid1.jpg'
},
{
  title: 'Titulli1',
  description: 'Lorem ipsum dolor sit amet consectetur, adipisicing elit. Ullam, excepturi voluptatem? Officia repellat praesentium error quibusdam incidunt quasi minus non nihil. Mollitia adipisci nihil illo natus cum sunt blanditiis aliquid.',
  category: 'Office',
  img: 'grid1.jpg'
},
{
  title: 'Titulli1',
  description: 'Lorem ipsum dolor sit amet consectetur, adipisicing elit. Ullam, excepturi voluptatem? Officia repellat praesentium error quibusdam incidunt quasi minus non nihil. Mollitia adipisci nihil illo natus cum sunt blanditiis aliquid.',
  category: 'Home',
  img: 'grid1.jpg'
},
{
  title: 'Titulli1',
  description: 'Lorem ipsum dolor sit amet consectetur, adipisicing elit. Ullam, excepturi voluptatem? Officia repellat praesentium error quibusdam incidunt quasi minus non nihil. Mollitia adipisci nihil illo natus cum sunt blanditiis aliquid.',
  category: 'Flat',
  img: 'grid1.jpg'
},
{
  title: 'Titulli1',
  description: 'Lorem ipsum dolor sit amet consectetur, adipisicing elit. Ullam, excepturi voluptatem? Officia repellat praesentium error quibusdam incidunt quasi minus non nihil. Mollitia adipisci nihil illo natus cum sunt blanditiis aliquid.',
  category: 'Office',
  img: 'grid1.jpg'
},
{
  title: 'Titulli1',
  description: 'Lorem ipsum dolor sit amet consectetur, adipisicing elit. Ullam, excepturi voluptatem? Officia repellat praesentium error quibusdam incidunt quasi minus non nihil. Mollitia adipisci nihil illo natus cum sunt blanditiis aliquid.',
  category: 'Flat',
  img: 'grid1.jpg'
},
{
  title: 'Titulli1',
  description: 'Lorem ipsum dolor sit amet consectetur, adipisicing elit. Ullam, excepturi voluptatem? Officia repellat praesentium error quibusdam incidunt quasi minus non nihil. Mollitia adipisci nihil illo natus cum sunt blanditiis aliquid.',
  category: 'Home',
  img: 'grid1.jpg'
},
{
  title: 'Titulli1',
  description: 'Lorem ipsum dolor sit amet consectetur, adipisicing elit. Ullam, excepturi voluptatem? Officia repellat praesentium error quibusdam incidunt quasi minus non nihil. Mollitia adipisci nihil illo natus cum sunt blanditiis aliquid.',
  category: 'Flat',
  img: 'grid1.jpg'
},
]

let postsFlex = document.querySelectorAll('.post-flex')

let content = document.querySelectorAll('.grid-content');
content.forEach(cont => {
  let postsFilter = posts.filter(post=> post.category == cont.id).slice(0,3)
  cont.innerHTML = `<h1 class="category-name">${cont.getAttribute('data-text')}</h1>`;
  postsFilter.forEach(post => {
    cont.innerHTML += `

     <div class="homepagegrid content1">
               <img src='../../imgs/${post.img}' alt="Home">
               <h1>${post.title}</h1>
               <p>${post.description}.</p>
               <a class="btn btn-primary" href="#">Show Details</a>
           </div>
    `
  })
})
