function compare(a, b) {
    console.log("a: " + a);
    console.log("b: " + b);

    // Double equals "==" and triple equals "==="

    // == coerces type to compare values, regardless of type
    console.log("a == b: " + (a == b));

    // === checks for same value AND same type (with some exceptions, largely because of reference equality for objects)
    console.log("a === b: " + (a === b));
    console.log();

    // Best practice: always use '===' unless you have a good reason to use '=='
}

compare(5, "5");