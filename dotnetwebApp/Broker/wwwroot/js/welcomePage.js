 let username = localStorage.getItem("broker-username");
let navListLeft = document.getElementById("list1");
let navHeader = document.getElementById("homepageHeader");
let navFixed = navHeader.offsetTop;


//setting nav bar to fixed
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

//change the inner html of navbar based on whether the user is logged in or not
navListLeft.innerHTML +=
  username == null
    ? `
<li id="SignIn" ><a href="#" >Sign In</a></li>`
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
    location.href = ("Home/Login");
});

let logout = document.getElementById('LogOut');
logout?.addEventListener('click',()=>{
    localStorage.removeItem('broker-username');
    location.reload();
})

// get data from backend to create a set with unique categories








const prevBtn = document.querySelectorAll('.prev');
const nextBtn = document.querySelectorAll('.next');

nextBtn.forEach(next=>{
  next.addEventListener('click',e=>switchSlide(e,'next'));
})

prevBtn.forEach(prev=>{
  prev.addEventListener('click',e=>switchSlide(e,'prev'));
})

//create objects where key is the category and value is index of slider
let indexes = {};

//categorySet.forEach(cat => {
 //   indexes[cat] = 0;
//})


function switchSlide(e, arg) {
    // select category next/prev button
    let currentBtn = e.currentTarget.getAttribute('data-category-btn')
    // select the parent element of slides
    let parentEl = e.currentTarget.parentElement.children[0];
  // select all slides
 let allSlides = parentEl.children;
 //get the width of slide
 const slideWidth = allSlides[0].offsetWidth;
 // if there are 3 or less slides set length to 0 so there is no need to slide because the container fits 3 elements
 //if there are more than 3 slides set length to -3 because container fits 3 elements
 let slidesLength = allSlides.length <= 3 ? 0 : allSlides.length - 3;

  parentEl.classList.add('transition')    
  // gap is 5% of parent element width so  divide it by 20
  const gap = parentEl.offsetWidth / 20;

        if (slidesLength != 0) {
    if (arg == 'next') {
        parentEl.style.left = `${(parentEl.offsetLeft - slideWidth) - gap}px`
        indexes[currentBtn]++;
  } else {
        parentEl.style.left = `${(parentEl.offsetLeft + slideWidth) + gap}px`
        indexes[currentBtn]--;
  }
}

    if (indexes[currentBtn] == -1 && slidesLength != 0) {
        parentEl.style.left = `${parentEl.offsetLeft - (slideWidth * slidesLength) - gap * slidesLength}px`
        indexes[currentBtn] = slidesLength;
    } else if (indexes[currentBtn] > slidesLength && slidesLength != 0) {
        parentEl.style.left = '0';
        indexes[currentBtn] = 0;
    }
   
}
