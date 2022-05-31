var index = 0;
var foto = document.getElementsByClassName("foto");

function slideshow() {
  for (i = 0; i < foto.length; i++) {
    foto[i].style.display = "none";
  }
  index++;
  if (index > foto.length) {
    index = 1;
  }
  foto[index - 1].style.display = "block";
  setTimeout(slideshow, 2000);
}

function slideshowManually() {
  for (i = 0; i < foto.length; i++) {
    foto[i].style.display = "none";
  }
  if (index > foto.length) {
    index = 1;
  }
  foto[index - 1].style.display = "block";
}

function nextSlide() {
  index++;
  slideshowManually();
}

function prevSlide() {
  index--;
  slideshowManually();
}

//todo: implement click on button to show next slide
window.onload = slideshow;
