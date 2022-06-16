const firstname=document.querySelector('.firstname');
const lastname=document.querySelector('.lastname');
const birthday=document.querySelector('.birthday');
const username=document.querySelector('.username');
const email=document.querySelector('.email');
const password=document.querySelector('.password');
const confirmPassword=document.querySelector('.confirm-password');
const btn=document.querySelector('#submit-btn');


document.querySelector('#form').addEventListener('submit',function(e){

    e.preventDefault();
    var regName = /^[a-zA-Z]+ [a-zA-Z]+$/;

    if(!firstname.ariaValueMax.match(regName)){
        if(firstname.value==''){
            document.querySelector('#firstname_err').innerHTML="Empty firstname erro!";
        }
    }



})
