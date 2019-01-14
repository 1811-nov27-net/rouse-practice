'use strict';

// AJAX - Asynchronous Javascript And XML
// "Let'd make requests and receive responses from XML-based services dynamically in the page."

// Practical modern meaning:  using the DOM API to send requests over the internet

// XMLHttpRequest is the traditional object used for this

function ajaxGet(url, 
    success, 
    failure = res => console.log(res)) {
        let xhr = new XMLHttpRequest();

        xhr.addEventListener("readystatechange", () => {
            console.log(`ready-state is now: ${xhr.readyState}`);
            if (xhr.readyState === 4) {
                // We've received the response
                let responseJSON = xhr.response;
                console.log(responseJSON);

                if(xhr.status >= 200 && xhr.status <= 300) {
                    // Success
                    // DOM API provides JSON deserialize with JSON.parse(), and JSON serialize with JSON.serialize())
                    let responseObj = JSON.parse(responseJSON);
                    console.log(responseObj);
                    let joke = responseObj.value.joke;
                    jokeHeader.innerText = joke;
                }
            }
        }); 

        xhr.open("GET", url);
        xhr.send();
}

document.addEventListener("DOMContentLoaded", () => {
    let jokeHeader = document.getElementById("jokeHeader");
    let jokeButton = document.getElementById("jokeButton");

    jokeButton.addEventListener("click", () => {
        ajaxGet("https://api.icndb.com/joke/random", response => {
            // Success
            // DOM API provides JSON deserialize with JSON.parse(), and JSON serialize with JSON.serialize())
            let responseObj = JSON.parse(responseJSON);
            console.log(responseObj);
            let joke = responseObj.value.joke;
            jokeHeader.innerText = joke;
        });

        console.log("-request about to be sent-");
    });
});
