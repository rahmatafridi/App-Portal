function validateForm(e) {
    var formIsValid = true;
    // check that a valid email address has been entered
   /* var emailRegExp = /[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}/;
    if (!emailRegExp.test(String($("#txtEmail").val()).toUpperCase())) {
        addError("txtEmail", "Please enter a valid email address.");
        formIsValid = false;
    } else {
        removeError("txtEmail");
    }

    // check that first name has one or more characters
    if ($("#txtFirstName").val() == '') {
        addError("txtFirstName", "This field is required.");
        formIsValid = false;
    } else {
        removeError("txtFirstName");
    }
    // check that last name has one or more characters
    if ($("#txtLastName").val() == '') {
        addError("txtLastName", "This field is required.");
        formIsValid = false;
    } else {
        removeError("txtLastName");
    }

    // check that a valid phone number is entered
    var phoneRegExp = /^\(?[1-9]\d{2}\)?\s?\-?\.?\d{3}\s?\-?\.?\d{4}$/;
    if (!phoneRegExp.test($("#txtPhone").val())) {
        addError("txtPhone", "Valid phone number required.");
        formIsValid = false;
    } else {
        removeError("txtPhone");
    }
    */

      if ($("#txtFirstName").val() == '') {
        addError("txtFirstName", "This field is required.");
        formIsValid = false;
    } else {
        removeError("txtFirstName");
    }

    
    if (!formIsValid) {
        e.preventDefault();
    }
}

function addError(id, msg) {
    if ($("#" + id).parent().find("label[class=error]").attr("generated") == "true") {
        $("#" + id).parent().find("label[class=error]").css("display", "block");
    } else {
        $("#" + id).parent().append('<label for="' + id + '" generated="true" class="error">' + msg + '</label>').css("display", "block");
    }
}
function removeError(id) {
    $("#" + id).parent().find("label[class=error]").css("display", "none");
}