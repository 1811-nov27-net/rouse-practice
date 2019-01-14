// ES5 has 'strict mode'
'use strict';
// Strict mode turns certain silent errors into thrown errors

// Function statement, declaring a function
function my_func(a) {
    console.log(a);
}

// Function expression
var my_func2 = (function(a) {
    console.log(a);
});

// With ES6, there is also "arrow functions" (aka: lambda expressions)
var my_func3 = a => console.log(a);

var no_params = () => console.log();
var two_params = (a, b) => console.log(a);

// ^ These all declare/create functions all do the same thing, except arrow function have a subtle difference with how the 'this' keyword works

// In ES5, there were only two scopes: document scope (aka global scope) and function scope
// Variables declared outside a function (and/or any set of brackets) have document scope
// Variables declared inside a function have function scope

var x = 5;

function f() {
    console.log(x); // undefined; x is delcared in the function (even before the code itself declares it), but hasn't been given a value
    if(true) {
        var x = 7;
    }
    //asdf = 'asdf'; // In a function without declaring (with var) is global scope; DON'T DO THIS
}

// global scope undeclared
//qwer = '1234';

// Strict mode makes undeclared variables throw errors

// ES6 added blcok scope to JS, using two new ways to declare variables: 'let' and 'const'
// Both let and const delcared a variable in scope only within the nearest pair of braces.  Const prevents changing the value after the first assignment

// Use 'let' or 'const', never 'var' or undeclared

let obj = {
    name: 'Devin',
    skill: 2,
    sayName: function() {console.log(this.name)},

    sayName2() {
        console.log(this.name)
    }
};

obj.sayName();


// In JS, outside arrow functions, "this" is "unbound"/"free" (points to whatever object is using it at runtime; it's not locked to whatever object/function declares it)
// Inside arrow functions, "this" becomes bound/locked to whatever it declaring it
class Person {
    constructor(name, age) {
        this.name = name;
        this.age = age;
        this.sayName = function () {
            console.log(this.name);
        };
    }
}

let person = new Person("Devin", 26);

console.log(person);

class Graduate {
    constructor(name, age, gradYear) {
        this.__proto__ = new Person(name, age);
        this.gradYear = gradYear;
    }
}

let devin = new Graduate("Devin", 26, 2010);
console.log(devin);


// When JS does property access (or assignment) on an object, it first scans the object; if nothing is found, it then looks at that object's __proto__, and on and on
// In ES6, we have proper classes with inheritance
class Person2 {
    constructor(name, age) {
        this.name = name;
        this.age = age;
        this.sayName = function () {
            console.log(this.name);
        };
    }
}


class Graduate2 extends Person {
    constructor(name, age, gradYear) {
        super(name, age);  // 'super' instead if 'base'
        this.gradYear = gradYear;
    }
}

let devin2 = new Person2('devin', 26);

// JS is object-oriented, but without classes; is also functional (functions/behavior are just another kind of data)
// ES6 is object oriented, with classes

// New features in ES6:
/*
    > let, const
    > arrow functions
    > class, interface
    > method syntax for functions as properties
    > string interpolation
    > symbol type for GUIDs
    > new useful built-in functions (e.g. string search)
    > promises for async stuff without callbacks
    > native modules (like namespaces)
    > built-in Set and Map
    > "for of" loop (like foreach)
    > getters and setters for properties like C# does
    > internationalization features
*/


// String interpolation
console.log("person's name: " + devin.name);
console.log(`person's name: ${devin.name}`);