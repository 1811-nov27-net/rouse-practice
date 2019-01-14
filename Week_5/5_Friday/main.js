console.log('main.js');

// JavaScript is dynamically typed - variables have no types, only values have types
// JS is interpreted, not compiled
// JS is run in the browser, or server-side with things like Node.JS

// numbers
x = 5;
x = 5.5; // only one type of number in JS (regardless of whether it's integer, floating point, etc)
x = Infinity;
x = -Infinity;
x = -0;
x = NaN;  // NaN (Not a Number) is still a number type...for some reason

// Strings
x = "asdf";
x = 'qwer'; // can use either single quote (') or double quote ("), but you should stick to one convention

// Boolean
x = true;
x = false;

// Null
x = null; // typeof lists null as an object; this isn't really true, but is kept for backwards compatibility

// Object
// we don't use classes as templates for objects in JS
x = {}; // works like "dynamic" in C#
x.asdf = true;
x.derp = "I'm a little teapot, short and stout";

// Object properties can be accessed through indexing syntax or dot (.) syntax 
console.log(x["asdf"]);

x = [1, 2, 3]; // arrays counts as objects

// Functions are first-class objects and have parameter names, but not parameter or return types
function my_func(a, b, c = 5) {
    console.log(b);
    console.log(c);
}
// if no return statement, returns undefined

x = my_func(1);  // Unpassed parameters will be undefined

x = my_func;
x.abc = "whargarble";

// Undefined
//x = undefined;

console.log(x);

console.log("value of x: " + x);
console.log("type of x: " + typeof(x));

console.log("value of x.notreal: " + x.notreal);
console.log("type of x.notreal: " + typeof(x.notreal));

// JS was standarized under the name 'ECMAScript' ('ES' for short)
// ES is used when referring to which JS version is being used (ex: "We're using ES5")

// Symbol - added in ES5, for GUIDs, unique IDs for things

// ES versions:
//      ES5                 - this is the baseline for all modern JS becuase all browsers support it; uses prototypal inheritance
//      ES6 (or ES2015)     - added classes and interfaces
//      ES2016
//      ES2017

// There are many other languages that people have come up with that extends JS and compile (or rather, "transpilation"; compiles to a language that isn't really more low-level) down to JS:
//      TypeScript (by Microsoft)   - adds opt-in strict typing to JS
//      CoffeeScript

// We also transpile ES6 to ES5 (or any higher version to a lower version)