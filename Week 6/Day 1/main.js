'use strict';

function formCheck() {
    if(document.forms["userInfo"]["fName"].value == "") {
        alert("Please enter a value for 'First Name'");
        return false;
    }

    if(document.forms["userInfo"]["lname"].value == "") {
        alert("Please enter a value for 'Last Name'");
        return false;
    }

    if(document.forms["userInfo"]["email"].value == "") {
        alert("Please enter a value for 'Email'");
        return false;
    }

    if(document.forms["userInfo"]["phone"].value == "") {
        alert("Please enter a value for 'Phone Number'");
        return false;
    }

    if(document.forms["userInfo"]["address"].value == "") {
        alert("Please enter a value for 'Address'");
        return false;
    }

    if(document.forms["userInfo"]["company"].value == "") {
        alert("Please enter a value for 'Company'");
        return false;
    }

    if(document.forms["userInfo"]["job"].value == "") {
        alert("Please enter a value for 'Role In Company'");
        return false;
    }
}