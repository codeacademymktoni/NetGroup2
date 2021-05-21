function initCart() {
    var cartItems = localStorageService.getAll("cartItems");

    cartItems.forEach(x => {
        console.log(x);
        axios.get(`https://bookstoreapica.azurewebsites.net/api/books/${x}`)
            .then(function (response) {
                createCartItem(response.data);
            })
            .catch(function (error) {
                console.log(error);
            });
    });

}

function createCartItem(book) {
    var card = document.createElement("div");
    card.classList.add("bookCard");

    var cardTitle = document.createElement("h4");
    cardTitle.innerHTML = `Title: ${book.title} - Author: ${book.author}`;

    var cardPrice = document.createElement("h4");
    cardPrice.innerHTML = `Price: ${book.price}`;

    var cardBtn = document.createElement("button");
    cardBtn.classList.add("btn");
    cardBtn.classList.add("btn-primary");
    cardBtn.innerHTML = "Remove from cart"
    cardBtn.onclick = function (e) { removeFromCart(e, book.id) };

    card.appendChild(cardTitle);
    card.appendChild(cardPrice);
    card.appendChild(cardBtn);

    var container = document.getElementById("cartItemContainer");
    container.appendChild(card);
}

function removeFromCart(event, bookId) {
    localStorageService.remove('cartItems', bookId);
    event.target.parentElement.remove();
}

function orderBooks() {
    //get all data from inputs
    var name = document.getElementById("customerName").value;
    var email = document.getElementById("customerEmail").value;
    var address = document.getElementById("customerAddress").value;
    var phone = document.getElementById("customerPhone").value;
    //get booksids from local storage
    validateForm();

    var bookIds = localStorageService.getAll('cartItems');

    var data = {
        fullName: name,
        email: email,
        address: address,
        phone: phone,
        bookIds: bookIds
    }

    axios.post("https://bookstoreapica.azurewebsites.net/api/orders", data)
        .then(function (response) {
            alert(`Thanks for ordering`);
            localStorageService.clear("cartItems");
            location.href = "./index.html"
        })
        .catch(function (error) {
            if(error.response.status == 400){
                for (const property in error.response.data.errors) {
                    console.log(`${property}: ${error.response.data.errors[property]}`);
                }
            }else{
                alert("Something has occured. Please try again later.");
            }
        })


    //make http post to send data to api
    //redirect to index.html
}

// function validateData(data){
//     var result = true;

//     if(data.fullName == null || data.fullName.trim() == ""){
//         result = false;
//     }    

//     if(data.email == null || data.email.trim() == ""){
//         result = false;
//     }  

//     if(data.address == null || data.address.trim() == ""){
//         result = false;
//     }  

//     if(data.phone == null || data.phone.trim() == ""){
//         result = false;
//     }  

//     if(data.bookIds == null || data.bookIds.length == 0){
//         result = false;
//     }  

//     return result;
// }

initCart();

