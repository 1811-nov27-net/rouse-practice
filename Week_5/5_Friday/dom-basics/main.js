'use strict';

function alertMe() {
    alert("You clicked the element!");
}

// We access most of the DOM API by using the document object

//let col1 = document.getElementById("col1");

//col1.onclick = alertMe;

// Scripts run as soon as they're encountered in the HTML, and elements are created as soon as they're encountered
window.onload = function () {
    // This is the basic way of waiting until the document is all loaded before trying to interact with it
    let col1 = document.getElementById("col1");

    col1.onclick = alertMe;
};

// Better way that allows multiple functions to all listen on the same event
window.addEventListener("load", function() {
    let col1 = document.getElementById("col1");
    col1.onclick = alertMe;
});

function printEventDetails(event) {
    console.log(event);
    console.log(event.target);
    console.log(this);
}


// Don't wait until literally every single page/document asset is loaded, only wait until all the elements are created in the DOM
document.addEventListener("DOMContentLoaded", () => {
    let col1 = document.getElementById("col1");
    col1.addEventListener("click",alertMe);

    let header = document.getElementById("header");
    header.innerText += ", changed by JS!";
    header.innerHTML = `<u>${header.innerHTML}</u>`;

    // JQuery is a common JS library that makes many common DOM tasks faster to write

    let cell1 = document.getElementById("cell1");
    cell1.addEventListener("click", printEventDetails);


    let tbody = document.getElementById("tbody");

    // By default, event listeners/handlers are in bubbling mode
    tbody.addEventListener("click", printEventDetails);

    // "true" as third parameter will set capturing mode
    tbody.addEventListener("click", printEventDetails, true);
});