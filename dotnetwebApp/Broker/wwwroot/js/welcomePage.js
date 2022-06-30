let username = localStorage.getItem("broker-username");
let navListLeft = document.getElementById("list1");
let navHeader = document.getElementById("homepageHeader");
let navFixed = navHeader.offsetTop;

const slideshowImages = document.querySelectorAll(
  ".homepage-slider .homepage-slider-imgs"
);

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
    navHeader.classList.add("fixed");
  } else {
    navHeader.classList.remove("fixed");
  }
}
window.onscroll = function () {
  navbarFixed();
};

//change the inner html of navbar based on whether the user is logged in or not


// get data from backend to create a set with unique categories

const prevBtn = document.querySelectorAll(".prev");
const nextBtn = document.querySelectorAll(".next");

//create objects where key is the category and value is index of slider


//fetch('https://localhost:44359/Home/GetSomething').then(res => res.json()).then(data => {
//const prevBtn = document.querySelectorAll('.prev');
//const nextBtn = document.querySelectorAll('.next');

var indexes = {};

nextBtn.forEach(next => {
    next.addEventListener('click', e => switchSlide(e, 'next'));
})

prevBtn.forEach(prev => {
    prev.addEventListener('click', e => switchSlide(e, 'prev'));
});

prevBtn.forEach((prev) => {
  prev.addEventListener("click", (e) => switchSlide(e, "prev"));
});

fetch("https://localhost:44359/Home/GetSomething")
  .then((res) => res.json())
  .then((data) => {
    data = JSON.parse(data);

    for (let cat of data) {
        indexes[cat.CategoryName] = 0;
    }

})



function switchSlide(e, arg) {
  if (indexes.Home == undefined) {
    return;
  }

    if (indexes.House == undefined) {
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


    //console.log(indexes, currentBtn, parentEl, allSlides, slidesLength)


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

