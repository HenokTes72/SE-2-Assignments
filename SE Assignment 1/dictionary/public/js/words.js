var express = require("express");
var fs = require("fs");

var word = express.Router();


//checks if the request word and meaning are not empty
function addAndEditMiddleware(req,res,next){
    var word = req.query["word"];
    var meaning = req.query["meaning"];

    if(word != "" && meaning != ""){
        if(word != undefined && meaning != undefined){
            next();
        }
        else{
            res.send('<h6 class="h6">Please enter a word and a meaning</h6>');
        }
    }
    else{
        res.send("<h6 class=\"h6\">Please enter a word and a meaning</h6>");
    }
}

word.use(function(req,res,next){
    res.header("Access-Control-Allow-Origin", "*");
    res.header("Access-Control-Allow-Headers", "Origin, x-Requested-With,Content-Type,Accept");
    next();
});

//a middleware that authetinicate wheather a person is legal or not
word.use(function(req,res,next){
    var token = req.query["authorization"];
    console.log(token);
    var tokenDatabase = JSON.parse(fs.readFileSync("./tokens.json", "utf8").trim());
    if(tokenDatabase[token]){
        next();
    }
    else{
        res.send("<h6 class=\"h6\"> unauthorized access</h6>");
    }
});

word.use('/search',function(req,res,next){
    var word = req.query["word"];
    if(word != "" && word !== undefined){
        next();
    }
    else{
        res.send("");
    }
});

word.use("/addWord", addAndEditMiddleware);
word.use("/edit", addAndEditMiddleware);

word.get("/search", function(req, res) {
  var word = req.query["word"];
  var dictionary = JSON.parse(fs.readFileSync("./words.json", "utf8").trim());
  var result = [],prop;
    for (prop in dictionary) {
      if ((prop + "").startsWith(word) || (prop + "").startsWith(word.toUpperCase())) {
        var val = dictionary[prop];
        result += '<button type=\'button\' class=\'list-group-item list-group-item-action\' val="' + val + '">' + prop + "</button>";
      }
    }
    res.send(result);
});
word.get('/addWord',function(req,res){
    var word = req.query["word"];
    var meaning = req.query["meaning"];
    var dictionaryJson = JSON.parse(fs.readFileSync("./words.json", "utf8").trim());
    if (dictionaryJson[word] === undefined) {
        dictionaryJson[word] = meaning;
        fs.writeFileSync("./words.json", JSON.stringify(dictionaryJson));
        res.send("<h6><b><i>"+word+"</i></b> added succsessfully</h6>");
    }
    else{
        res.send("<h6 class=\"h6\">"+word+" already exist </h6>");
    }
});
word.get("/edit", function(req, res) {
  var word = req.query["word"];
  var meaning = req.query["meaning"];
  var dictionaryJson = JSON.parse(
    fs.readFileSync("./words.json", "utf8").trim()
  );
  if (dictionaryJson[word] !== undefined) {
    dictionaryJson[word] = meaning;
    fs.writeFileSync("./words.json", JSON.stringify(dictionaryJson));
    res.send("<h6><b><i>" + word + "</i></b> edited succsessfully</h6>");
  } else {
    res.send('<h6 class="h6"> can not find word ' + word);
  }
});

module.exports = word;
