var express = require('express');
var app = express();
var portNumber = 5000;

function isPrime(num){
    var isPrim = true;
    
    return isPrim;
}

app.use(express.static('public'));
//  app.use(user);
//  app.use(word);


var counter = 1 ;


app.get("/chkPrime", function(req, res) {
    res.header("Access-Control-Allow-Origin", "*");
    
    var num = binaryToDecimalConverter(bitGenerator(23))+(counter*10000);

    var isPrime = true;

    //idk the reason why i wrote the prime number checker code here.
    for(var j=2;j<num;j++){
        if(parseInt(num) % j == 0){
            isPrime = false;
        }
    }

    res.send("<h>Hello</h> "+"isPrime "+parseInt(num)+" = "+isPrime);
    console.log("request "+counter);
    counter+=1;
});

function binaryToDecimalConverter(binaryDigit) {
    var decimalNum = 0;
    var bdigitLength = binaryDigit.length;
    for (var i = 0; i < bdigitLength; i++) {
        decimalNum += (parseInt(binaryDigit[bdigitLength - 1 - i]) * powerTwo(i));
    }
    return decimalNum;
}

function powerTwo(exponent) {
    var res = 1;
    for (var i = 0; i < exponent; i++) {
        res *= 2;
    }
    return res;
}

function bitGenerator(numberOfBit) {
    var result = "";
    for (var k = 0; k < numberOfBit; k++) {
        result += parseInt((Math.random() * 1.99)); // bit 0 | 1
    }
    return result;
}



app.listen(portNumber);
console.log("server is running on port "+portNumber);
