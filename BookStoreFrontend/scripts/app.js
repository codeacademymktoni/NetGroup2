function createCard(book) {
  var col = document.createElement("div");
  col.classList.add("col-md-3");

  var card = document.createElement("div");
  card.classList.add("card");

  var cardBody = document.createElement("div");
  cardBody.classList.add("card-body");

  var cardTitle = document.createElement("h4");
  cardTitle.classList.add("card-title");
  cardTitle.innerText = book.title;

  var cardAuthor = document.createElement("h4");
  cardAuthor.classList.add("card-title");
  cardAuthor.innerText = book.author;

  var cardDescription = document.createElement("p");
  cardDescription.classList.add("card-text");
  cardDescription.innerText = book.description;

  var cardPrice = document.createElement("p");
  cardPrice.classList.add("card-text");
  cardPrice.innerText = book.price;

  var cardGenre = document.createElement("p");
  cardGenre.classList.add("card-text");
  cardGenre.innerText = book.genre;

  var cardBtn = document.createElement("button");
  cardBtn.classList.add("btn");
  cardBtn.classList.add("btn-primary");

  if(localStorageService.exists('cartItems', book.id)){
    cardBtn.innerHTML = "Remove from cart";
    cardBtn.onclick = function(e){
      removeFromCart(e, book.id);
    }
  }else{
    cardBtn.innerHTML = "Add to cart";
    cardBtn.onclick = function(e){
      addToCart(e, book.id);
    }
  }

  cardBody.appendChild(cardTitle);
  cardBody.appendChild(cardAuthor);
  cardBody.appendChild(cardDescription);
  cardBody.appendChild(cardPrice);
  cardBody.appendChild(cardGenre);
  cardBody.appendChild(cardBtn);

  card.appendChild(cardBody);
  col.appendChild(card);

  var cardContainer = document.getElementById("card-container");
  cardContainer.appendChild(col);
}

function addToCart(event, bookId){

  localStorageService.add("cartItems", bookId);

  event.target.innerHTML = "Remove from cart";
  event.target.onclick = function(e){
    removeFromCart(e, bookId);
  }
}

function removeFromCart(event, bookId){
  localStorageService.remove("cartItems", bookId);
 
  event.target.innerHTML = "Add to cart";
  event.target.onclick = function(e){
    addToCart(e, bookId);
  }
}

function initApp() {
  renderCards();
}

function getWithFilter() {
  var authorInput = document.getElementById("authorSearchInput").value;
  var titleInput = document.getElementById("titleSearchInput").value;

  renderCards(authorInput, titleInput);
}

function renderCards(authorInput = "", titleInput = ""){
  var loader = document.getElementById("loader");
  loader.style.display = "block";
  axios.get(`https://bookstoreapica.azurewebsites.net/api/books?author=${authorInput}&title=${titleInput}`)
  .then(function (response) {
    document.getElementById("card-container").innerHTML = "";
    for (let i = 0; i < response.data.length; i++) {
      createCard(response.data[i]);
    }
  })
  .catch(function (error) {
    console.log(error);
  }).finally(function(){
      loader.style.display = "none";
  }).finally(() => {loader.style.display = "none"});
}

initApp();