'use strict';

document.addEventListener("DOMContentLoaded", () => {
    let jsonText = document.getElementById("jsonText");
    let jsonButton = document.getElementById("jsonButton");
    let message = document.getElementById("message");

    jsonButton.addEventListener("click", () => {
        try {
            let parseText = JSON.parse(jsonText.value);
            console.log(parseText);
            message.innerText = "Printed to console.";
        }
        catch {
            message.innerText = "Input was not valid JSON!";
        }
 
    });
});