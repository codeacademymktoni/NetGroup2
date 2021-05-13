function validateForm() {
    var requiredElements = document.querySelectorAll('[required]');
    var result = true;

    for (var i = 0; i < requiredElements.length; i++) {
        var elementValue = requiredElements[i].value;
        var elementName = requiredElements[i].getAttribute("name");
        if (elementValue == null || elementValue.trim().length == 0) {
            result = false;
            alert(elementName + " is required");
            break;
        }
    }

    return result;
}