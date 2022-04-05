const postimet=[

{id:1,
title:"Emri Titullit 1",
img:'broker1.jpg',
description:"Pershkrimi i postimit 1",
price:'100$',
},
{id:2,
    title:"Emri Titullit 2",
    img:'broker2.jpg',
    description:"Pershkrimi i postimit 2",
    price:'200$',
    },
    {id:3,
        title:"Emri Titullit 3",
        img:'broker3.jpg',
        description:"Pershkrimi i postimit 3",
        price:'300$',
        },
        {id:4,
            title:"Emri Titullit 4",
            img:'broker4.jpg',
            description:"Pershkrimi i postimit 4",
            price:'400$',
            }


];


const main=document.querySelector('#main');



window.addEventListener('load',function(e){
        // console.log('alban selmanaj');
        postimet.forEach(function(p){

            main.innerHTML+=`
        <div class="user-post">
            <h1>${p.id}</h1>
            <img src="../images/${p.img}" alt="image">
            <h3>${p.description}</h3>
            <p>${p.price}</p>
        </div>

        `;



        })

        


})