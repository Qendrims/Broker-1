var index=0;
var foto=document.getElementsByClassName("foto");

function slideshow(){
    for(i=0;i<foto.length;i++){
        foto[i].style.display="none";
    }
    index++;
    if(index>foto.length)
    {index=1;}
    foto[index-1].style.display="block";
    setTimeout(slideshow,2000);
}
window.onload=slideshow();