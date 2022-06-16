let username = localStorage.getItem("broker-username");
let navListLeft = document.getElementById("list1");
let navHeader = document.getElementById("homepageHeader");
let navFixed = navHeader.offsetTop;

const slideshowImages = document.querySelectorAll(".homepage-slider .homepage-slider-imgs");

const nextImageDelay = 3000;
let currentImageCounter = 0;

//slideshowImages[currentImageCounter].style.display="block";
slideshowImages[currentImageCounter].style.opacity = 1;

setInterval(nextImage, nextImageDelay);

function nextImage() {
    //slideshowImages[currentImageCounter].style.display="none";
    //slideshowImages[currentImageCounter].style.opacity=0;
    slideshowImages[currentImageCounter].style.zIndex = -2;
    const tempCounter = currentImageCounter;
    setTimeout(() => {
        slideshowImages[tempCounter].style.opacity = 0;
    }, 1000);
    currentImageCounter = (currentImageCounter + 1) % slideshowImages.length;
    //slideshowImages[currentImageCounter].style.display="block";
    slideshowImages[currentImageCounter].style.opacity = 1;
    slideshowImages[currentImageCounter].style.zIndex = -1;
}

const agents = [
    {
        name: "Mark Cetinski",
        location: "California",
        languages: "English",
    },
    {
        name: "Maya Huan ",
        location: "Texas",
        languages: "Latin",
    },
    {
        name: "Patrick Herman",
        location: "California",
        languages: "English",
    },
    {
        name: "Joe Daniel",
        location: "Texas",
        languages: "English",
    },
    {
        name: "Roberto Hurley",
        location: "New York",
        languages: "English",
    },
    {
        name: "Tracy Daniel",
        location: "New York",
        languages: "English",
    },
];

function clearSearch(e) {
    document.querySelector(".searchResults").innerHTML = "";
    document.querySelector(".searchResults").style.display = "none";
}

document
    .querySelector(".homepageSearch")
    .addEventListener("keyup", function (e) {
        e.preventDefault();
        const search = document.querySelector(".homepageSearch").value;
        clearSearch();

        if (search.length > 0) {
            for (var i = 0; i < agents.length; i++) {
                if (agents[i].name.toLowerCase().includes(search.toLowerCase())) {
                    document.querySelector(".searchResults").innerHTML += `
                <div class="searchResults-item">
                <span class="search-item">${agents[i].name}</span>
                <span class="search-item">${agents[i].location}</span>
                <span class="search-item"${agents[i].languages}</span>
                </div>
                `;
                }
            }
            document.querySelector(".searchResults").style.display = "block";
        }
    });

//setting nav bar to fixed
function navbarFixed() {
    if (window.pageYOffset > navFixed) {
        navHeader.classList.add("fixed")
    } else {
        navHeader.classList.remove("fixed");
    }
}
window.onscroll = function () {
    navbarFixed();
}

//change the inner html of navbar based on whether the user is logged in or not


navHeader.innerHTML +=
    username == null
        ? `
    <ul class="nav-list" id="list2">
      <li id="Buy" ><a href="/Post/PostPage">Posts</a></li>
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
    <li><a class="dropdown-item" href="/Post/Postpagecreate">Create Post</a></li>
    <li><a class="dropdown-item" href="/Post/MyPosts">My posts</a></li>
    <li><a class="dropdown-item" href="/Home/Postpage">All posts</a></li>
    <li><a class="dropdown-item" href="/Post/ArchivedPosts">Archived posts</a></li>
    <li><hr class="dropdown-divider"></li>
    <li id="LogOut"><a class="dropdown-item" href="#">Log Out</a></li>
  </ul>
</div>
`;

let signIn = document.getElementById("SignIn");
signIn?.addEventListener("click", () => {
    location.href = ("/Home/Login");
});

let logout = document.getElementById('LogOut');
logout?.addEventListener('click', () => {
    localStorage.removeItem('broker-username');
    location.reload();
})

// get data from backend to create a set with unique categories











const prevBtn = document.querySelectorAll('.prev');
const nextBtn = document.querySelectorAll('.next');



//create objects where key is the category and value is index of slider

var indexes = {};

//fetch('https://localhost:44359/Home/GetSomething').then(res => res.json()).then(data => {
//const prevBtn = document.querySelectorAll('.prev');
//const nextBtn = document.querySelectorAll('.next');

nextBtn.forEach(next => {
    next.addEventListener('click', e => switchSlide(e, 'next'));
})

prevBtn.forEach(prev => {
    prev.addEventListener('click', e => switchSlide(e, 'prev'));
});

fetch('https://localhost:44359/Home/GetSomething').then(res => res.json()).then(data => {
    data = JSON.parse(data);

    for (let cat of data) {
        indexes[cat] = 0;
    }
})



function switchSlide(e, arg) {

    if (indexes.Home == undefined) {
        return;
    }

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