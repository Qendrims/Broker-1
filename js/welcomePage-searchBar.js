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
