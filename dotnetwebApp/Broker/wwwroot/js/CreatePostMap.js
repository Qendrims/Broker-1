var startLat = 40.75637123;
var startLong = -73.98545321;

var options = {
    center: [startLat, startLong],
    zoom: 12
}



document.getElementById('lat').value = startLat;
document.getElementById('lon').value = startLong;

var map = L.map('map', options);


L.tileLayer('http://{s}.tile.osm.org/{z}/{x}/{y}.png', { attribution: 'OSM' }).addTo(map);

var myMarker = L.marker([startLat, startLong], { title: "Coordinates", alt: "Coordinates", draggable: true }).addTo(map).on('dragend', function () {
    var lat = myMarker.getLatLng().lat.toFixed(8);
    var lon = myMarker.getLatLng().lng.toFixed(8);

    document.getElementById('lat').value = lat;
    document.getElementById('lon').value = lon;

});

function chooseAddr(lat1, lng1) {
    map.setView([lat1, lng1], 12);
    myMarker.setLatLng([lat1, lng1]);
    lat = lat1.toFixed(8);
    lon = lng1.toFixed(8);
    document.getElementById('lat').value = lat;
    document.getElementById('lon').value = lon;

    document.getElementById('results').innerHTML = "";
    //document.getElementById('currAddress').textContent = address;

}

function myFunction(arr) {
    var out = "<br />";
    var i;


    if (arr.length > 0) {
        for (i = 0; i < arr.length; i++) {
            // out += "<div class='address' title='Show Location and Coordinates' onclick='chooseAddr(" + arr[i].lat + ", " + arr[i].lon + ", " + arr[i].display_name + ");return false;'>" + arr[i].display_name + "</div>";
            out += "<div class='address' title='Show Location and Coordinates' onclick='chooseAddr(" + arr[i].lat + ", " + arr[i].lon + ");'>" + arr[i].display_name + "</div>";
        }
        document.getElementById('results').innerHTML = out;
    }
    else {
        document.getElementById('results').innerHTML = "Sorry, no results...";
    }

}



function latlongSearch(lat, long) {
    fetch("https://nominatim.openstreetmap.org/reverse?format=jsonv2&lat=" + lat + "&lon=" + long).then(res => res.json()).then(data => {

        document.getElementById('currAddress').textContent = data.display_name;

    });
}

map.on('click', e => {
    var lat = e.latlng.lat.toFixed(8);
    var long = e.latlng.lng.toFixed(8);

    myMarker.setLatLng([lat, long]);
    map.setView([lat, long], 15)
    latlongSearch(lat, long);
    document.getElementById('lat').value = lat;
    document.getElementById('lon').value = long;
})

function addr_search() {
    var inp = document.getElementById("addr");
    var xmlhttp = new XMLHttpRequest();
    var url = "https://nominatim.openstreetmap.org/search?format=json&limit=5&q=" + inp.value;
    xmlhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            var myArr = JSON.parse(this.responseText);
            myFunction(myArr);
        }
    };
    xmlhttp.open("GET", url, true);
    xmlhttp.send();
}