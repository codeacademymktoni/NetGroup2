axios.get('https://localhost:44308/api/books')
    .then(function (response) {
        for (let i = 0; i < response.data.length; i++) {
            createCard(response.data[i]);
        }
    })
    .catch(function (error) {
        console.log(error);
    });

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

    cardBody.appendChild(cardTitle);
    cardBody.appendChild(cardAuthor);
    cardBody.appendChild(cardDescription);
    cardBody.appendChild(cardPrice);
    cardBody.appendChild(cardGenre);

    card.appendChild(cardBody);
    col.appendChild(card);

    var cardContainer = document.getElementById("card-container");
    cardContainer.appendChild(col);
}

  function createBook(){
    var newBook =  {
        title: "Test book = new",
        description: "test book",
        author: "Olivera Nikolovska",
        genre: "Children",
        quantity: 10,
        price: 200.00
      }

    axios.post('https://localhost:44308/api/books', newBook)
      .then(function (response) {
        createCard(newBook);
      })
      .catch(function (error) {
        console.log(error);
      });
  }
