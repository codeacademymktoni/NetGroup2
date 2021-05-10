var localStorageService = {
    add: function (storageKey, item){
        var cartItems = [];

        var storageData = localStorage.getItem(storageKey);
      
        if(storageData != null){
          cartItems = JSON.parse(storageData);
        }
      
        if(cartItems.indexOf(item) == -1){
          cartItems.push(item);
        }
      
        localStorage.setItem(storageKey, JSON.stringify(cartItems));
    },
    remove: function(storageKey, item){
        var storageData = localStorage.getItem(storageKey);

        if(storageData != null){
          var cartItems = JSON.parse(storageData);
          cartItems = cartItems.filter(x => x != item);
      
          localStorage.setItem(storageKey, JSON.stringify(cartItems));
        }
    },
    getAll: function (storageKey){
        var cartItems = [];

        var storageData = localStorage.getItem(storageKey);
    
        if (storageData != null) {
            cartItems = JSON.parse(storageData);
        }

        return cartItems;
    },
    exists: function (storageKey, item){
        var exists = false;
        var storageData = localStorage.getItem(storageKey);
      
        if(storageData != null){
          var cartItems = JSON.parse(storageData);
      
          if(cartItems.indexOf(item) != -1){
            exists = true;
          }
        }
      
        return exists;
      },
      clear : function(storageKey){
        localStorage.removeItem(storageKey);
      }
}

