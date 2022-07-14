
var data = {};
function onChange(e) {
    e.preventDefault();
    data = {
        ...data,
        [e.target.name]: e.target.value
    }
}


let fileInput = document.getElementById('inputGroupFile01');
let imgContainer = document.getElementById('uploadedImages');
let numOfFiles = document.getElementById('filesNumber');
imgContainer.innerHTML = "";
let allFilesList = [];

function SetNumberFilesUploaded(textElement, number) {
    textElement.textContent = `${number} Files Selected`;
}

function preview() {
    let fileList = [];


    for (i of fileInput.files) {
        let fileAlreadyUploaded = allFilesList.some(file => file.name == i.name);
        if (!fileAlreadyUploaded) {
            allFilesList.push(i)
            fileList.push(i);
        }
    }

    SetNumberFilesUploaded(numOfFiles, allFilesList.length)
    //numOfFiles.textContent = `${allFilesList.length} Files Selected`;

    for (let i = 0; i < fileList.length; i++) {
        let reader = new FileReader();
        let figure = document.createElement("figure");

        reader.onload = () => {
            let img = document.createElement("img");
            let btn = document.createElement("button");
            btn.innerHTML = 'x';
            btn.setAttribute("class", "remove-btn");
            btn.setAttribute("id", "remove-btn");
            btn.setAttribute("type", "button");
            img.setAttribute("src", reader.result);
            img.setAttribute("id", i);
            figure.appendChild(img);
            figure.appendChild(btn);

            btn.addEventListener('click', e => {
                let img = e.target.previousElementSibling.getAttribute('id');

                document.querySelectorAll('img').forEach(image => {
                    if (image.id > img) {
                        image.id--;
                    }
                })

                fileList = fileList.filter((file, index) => index != img);
                allFilesList = fileList;
                SetNumberFilesUploaded(numOfFiles, allFilesList.length)
                e.target.parentElement.remove();
            })

        }

        imgContainer.appendChild(figure);
        reader.readAsDataURL(fileList[i]);

    }
}


let select = document.getElementById("select-option");
select.addEventListener('change', showAttribute);

function showAttribute() {
    console.log('select')

    let selectValue = document.getElementById("select-option").value;
    let allelements = document.getElementsByClassName("category-inputs")
    for (let i = 0; i < allelements.length; i++) {
        allelements[i].classList.add("hide");
    }
    if (selectValue == "2" || selectValue == "3") {
        document.getElementById('apartmentFloor').classList.remove('hide');
        document.getElementById('size').classList.remove('hide');
        document.getElementById('room').classList.remove('hide');
        document.getElementById('bathroom').classList.remove('hide');
    }
    else if (selectValue == "4") {
        document.getElementById('size').classList.remove('hide');
    }
    else if (selectValue == "5") {
        //bar
        document.getElementById('apartmentFloor').classList.remove('hide');
        document.getElementById('size').classList.remove('hide');
    }
    else {
        //house
        document.getElementById('size').classList.remove('hide');
        document.getElementById('room').classList.remove('hide');
        document.getElementById('bathroom').classList.remove('hide');
        document.getElementById('houseFloor').classList.remove('hide');
    }

}

$(document).ready(() => {
    toastr.options.closeDuration = 5000;
    document.querySelectorAll('input, textarea').forEach(inp => {
        inp.addEventListener('change', onChange)
    })
    document.querySelector('form').addEventListener('submit', handleSubmit)
})

