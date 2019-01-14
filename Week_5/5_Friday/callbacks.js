'use strict';

function addNumbers(a, b, callback) {
    let result = a + b;

    return callback(result);
}

addNumbers(3, 4, console.log); // prints 7
addNumbers(3, 4, result => console.log("calculation done"));

// Callbacks are important because we do a lot of listening to/waiting for event in JS, and also async stuff

function newCounter() {
    let x = 0;
    return () => {
        return ++x;
    }
}

let counter = newCounter();
// Normally at this point, "x" would disappear from the stack because it has passed out of scope

console.log(counter());
console.log(counter());
console.log(counter());

// In JS, variables that are referenced by functions that are still in scope, themselves remain in scope
// JS functions "close over" any variables they reference
// This behavior is called "closure", sometimes we call the fucntions themselves "closures"

// Before ES6, we wanted "namespaces", we wanted to encapsulate private details and expose only needed functionality
// Closure allows us to do this

// IIFE (Immediately-Invoked Function Expression)
let library = (function() {
    let privateData = 0;
    return {
        libraryMethod() {
            return privateData;
        },
    }
})();