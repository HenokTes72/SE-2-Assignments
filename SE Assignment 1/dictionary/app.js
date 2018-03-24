var express = require('express');
var fs = require('fs');
var app = express();
var user = require('./public/js/users');
var word = require('./public/js/words');
let portNumber = 4000;

app.use(express.static('public'));
app.get('/',function(req,res){
    var homeHtml = fs.readFileSync('./public/home.html','utf8');
    res.send(homeHtml);
});

app.use(user);
app.use(word);

app.listen(portNumber);
console.log("server is running on port "+portNumber);