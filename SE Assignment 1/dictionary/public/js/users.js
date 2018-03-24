var express = require("express");
var fs = require("fs");

var user = express.Router();

//logging middleware
user.use(function(req, res, next) {
  var userName = req.query["username"];
  var password = req.query["password"];

  if (userName != ""  && password != "") {
    next();//&& userName !== undefined && password !== undefined why this misruputs our program
  } else {
    res.send('<h6 class="h6">Username or password not given</h6>');
  }
});

user.use("/register", function(req, res, next) {
  var userName = req.query["username"];
  var passWord = req.query["password"];
  var usersJson;
  var result;

  fs.exists("./users.json", function(exists) {
    if (exists) {
      usersJson = JSON.parse(fs.readFileSync("./users.json", "utf8").trim());
      if (usersJson[userName]) {
        res.send('<h6 class="h6">Account already exist</h6>');
      } else {
        usersJson[userName] = passWord;
        fs.writeFileSync("./users.json", JSON.stringify(usersJson));
        next();
      }
    } else {
      fs.writeFileSync(
        "./users.json",
        '{"' + userName + '":"' + passWord + '"}'
      );
      console.log("next is called after users.json create");
      next();
    }
  });
});
user.use("/login", function(req, res, next) {
  var userName = req.query["username"];
  var passWord = req.query["password"];
  var usersJson;
  var result;
  fs.exists("./users.json", function(exists) {
    if (exists) {
      usersJson = JSON.parse(fs.readFileSync("./users.json", "utf8").trim());
      if (usersJson[userName] == passWord) {
        next();
      } else {
        res.send("<h6 class=h6>Incorrect username or password</h6>");
      }
    } else {
      res.send("<h6 class=h6>Incorrect username or password</h6>");
    }
  });
});
user.get("/register", function(req, res) {
  res.send("<h6>Registerd successefully</h6>");
});

user.get("/login", function(req, res) {
  var token = generateToken(req.query["password"]);
  console.log("login request is coming");
  var userName = req.query["username"];
  var tokensJson;
  fs.exists("./tokens.json", function(exists) {
    if (exists) {
      tokensJson = JSON.parse(fs.readFileSync("./tokens.json", "utf8").trim());
      tokensJson[token] = userName;
      fs.writeFileSync("./tokens.json", JSON.stringify(tokensJson));
    } else {
      fs.writeFileSync("./tokens.json", '{"' + token + '":"' + userName + '"}');
    }
  });
  res.send("<h6>Hello "+token+" "+ req.query["username"] + "</h6>");
});

function generateToken(name){
  return name+"xx"+"12";
} 

module.exports = user;
