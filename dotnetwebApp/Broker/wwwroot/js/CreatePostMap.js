
var startLat;
var startLong;

if (document.getElementById('lat').value == "") {

    startLat = 40.75637123;
    startLong = -73.98545321;
} else {
    startLat = document.getElementById('lat').value;
    startLong = document.getElementById('lon').value;
}


var options = {
    center: [startLat, startLong],
    zoom: 14
}


var map = L.map('map', options);

L.tileLayer('http://{s}.tile.osm.org/{z}/{x}/{y}.png', { attribution: 'OSM' }).addTo(map);

var myMarker = L.marker([startLat, startLong], { title: "Coordinates", alt: "Coordinates", draggable: true }).addTo(map).on('dragend', function () {
    var lat = myMarker.getLatLng().lat.toFixed(8);
    var lon = myMarker.getLatLng().lng.toFixed(8);

    document.getElementById('lat').value = lat;
    document.getElementById('lon').value = lon;
    latlongSearch(lat,lon)
});


function chooseAddr(lat1, lng1, address) {
    console.log(address);
    map.setView([lat1, lng1], 14);
    myMarker.setLatLng([lat1, lng1]);
    lat = lat1.toFixed(8);
    lon = lng1.toFixed(8);
    document.getElementById('lat').value = lat;
    document.getElementById('lon').value = lon;
    
    document.getElementById('results').innerHTML = "";
    latlongSearch(lat1,lng1)
}

//show search results
function myFunction(arr) {
    var out = "";
    var i;


    if (arr.length > 0) {
        for (i = 0; i < arr.length; i++) {

              out += `<div class="address" title="Show Location and Coordinates" onclick="chooseAddr(${arr[i].lat},${arr[i].lon},'${arr[i].display_name}')"> ${arr[i].display_name} </div>`

        }
        document.getElementById('results').innerHTML = out;
    }
    else {
        document.getElementById('results').innerHTML = "Sorry, no results...";
    }

}



// search address based on latitude and longitude
function latlongSearch(lat, long) {
    fetch("https://nominatim.openstreetmap.org/reverse?format=jsonv2&lat=" + lat + "&lon=" + long).then(res => res.json()).then(data => {
         document.getElementById('currAddress').textContent = data.display_name;
        document.getElementById('city').value = data.address.city != null ? data.address.city : "";
        document.getElementById('country').value = data.address.country != null ? data.address.country : "";
        document.getElementById('neighbourhood').value = data.address.neighbourhood != null ? data.address.neighbourhood : "";
        document.getElementById('road').value = data.address.road != null ? data.address.road : "";
        document.getElementById('state').value = data.address.state != null ? data.address.state : "";
        document.getElementById('housenumber').value = data.address.house_number != null ? +data.address.house_number : "";
        document.getElementById('zipcode').value = data.address.postcode != null ? +data.address.postcode : "";
        
   });
}

// click on map function
map.on('click', e => {
    var lat = e.latlng.lat.toFixed(8);
    var long = e.latlng.lng.toFixed(8);

    myMarker.setLatLng([lat, long]);
    map.setView([lat, long], 14)
    latlongSearch(lat, long);

    document.getElementById('lat').value = lat;
    document.getElementById('lon').value = long;

      
})

// search address with text input
function addr_search() {
    var inp = document.getElementById("addr");
    var xmlhttp = new XMLHttpRequest();
    var url = "https://nominatim.openstreetmap.org/search?format=json&limit=5&q=" + inp.value;
    xmlhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            var myArr = JSON.parse(this.responseText);
           // console.log(myArr);
            myFunction(myArr);
        }
    };
    xmlhttp.open("GET", url, true);
    xmlhttp.send();
}