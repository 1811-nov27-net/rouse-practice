'use strict';

let x = "1234";

// In JS, we *usually* try to avoid autmoatic type coercion, an excpetion being if-else conditions

if (x) {
    console.log("x is truthy");
}

// Truthy: converts to true as a boolean
// Falsy: converts to false as a boolean

// All values are truthy, except for a few exceptions:
/*
        0 (and -0)
        NaN
        ""
        null
        undefined
        false
*/