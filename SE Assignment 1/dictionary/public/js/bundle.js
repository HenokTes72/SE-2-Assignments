$(document).ready(function() {
  var token = -1;
  let root = document.getElementById("root");
  let nav = document.getElementsByTagName('nav')[0];

  function getMethod(val) {
    if (val == "login") {
      return ` 
                <div class="form-group group1">
                    <label for="exampleInputEmail1">Username</label>
                    <input type="text" class="form-control log-user-name" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter username">
                </div>
                <div class="form-group group2">
                    <label for="exampleInputPassword1">Password</label>
                    <input type="password" class="form-control log-password" id="exampleInputPassword1" placeholder="Password">
                </div>
                <span class="output"></span>
                <button  class="btn btn-default login-button">Login</button>
            
            `;
    } else if (val == "register") {
      return ` 
                <div class="form-group group1">
                    <label for="exampleInputEmail1">Username</label>
                    <input type="text" class="form-control reg-user-name" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter username">
                </div>
                <div class="form-group group2">
                    <label for="exampleInputPassword1">Password</label>
                    <input type="password" class="form-control reg-password" id="exampleInputPassword1" placeholder="Password">
                </div>
                <span class="output"></span>
                <button  id ="register-but" class="btn btn-default register-button">Register</button>
            `;
    }
  }
  function putWordList(word, meaning) {
    return ` <div class="card-header">
                    <h4 class="h4">${word}</h4>
                </div>
                <div class="card-body">
                    <p class="p">${meaning}</p>
                </div>
            </div>
        `;
  }
  function getAddWordTemplate(){
      return `  <div class="form-group group1">
                    <label for="exampleInputEmail1">Word</label>
                    <input type="text" class="form-control add-word" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter word">
                </div>
                <div class="form-group group2">
                    <label for="exampleInputPassword1">Meaning</label>
                    <input type="text" class="form-control add-meaning" id="exampleInputPassword1" placeholder="Meaning">
                </div>
                <span class="output"></span>
                <button  id ="add-but" class="btn btn-default add-button">Add</button>
            `;
  }
  function getEditTemplate() {
    return `  <div class="form-group group1 edit-group1">
                    <label for="exampleInputEmail1">Word</label>
                    <input type="text" class="form-control edit-word" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter word">
                </div>
                <ul class="list-group edit-list-group">
                </ul>
                <div class="form-group group2">
                    <label for="exampleInputPassword1">Meaning</label>
                    <input type="text" class="form-control edit-meaning" id="exampleInputPassword1" placeholder="Meaning">
                </div>
                <span class="output"></span>
                <button  id ="add-but" class="btn btn-default edit-button">Edit</button>
            `;
  }
  function getSearchTemplate() {
    return `
        <div class="form-group group3">
            <input type="text" class="form-control reg-user-name" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Search here...">
            <ul class="list-group">
            </ul>
            <div class="card">
            </div>
    `;
  }
  function getLoginHeaderTemplate() {
    return `
        <li class="nav-item">
            <a class="nav-link" href="#">Add</a>
        </li>
        <li class="nav-item">
            <a class="nav-link" href="#">Edit</a>
        </li>
        <li class="nav-item">
            <a class="nav-link " href="#">Search</a>
        </li>
        <li class="nav-item">
            <a class="nav-link " href="#">Logout</a>
        </li>
    `;
  }
  function getInitialHeaderTemplate(){
    return `
      <a class="navbar-brand" href="login">Henok's Dictionary</a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarToggleExternalContent" aria-controls="navbarToggleExternalContent"
            aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarToggleExternalContent">
            <ul class="navbar-nav mr-auto mt-2 mt-lg-0 mnav-ul">
                <li class="nav-item">
                    <a class="nav-link" href="login">Login</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link " href="register">Register</a>
                </li>
            </ul>
        </div>
    `;
  }
  function addWordHandler(){
    root.innerHTML = getAddWordTemplate();
    $("button.add-button").click(function() {
      var outputSpan = document.getElementsByClassName("output")[0];
      var word = $("input.add-word").val();
      var meaning = $("input.add-meaning").val();
      $.get("/addWord?word=" + word + "&meaning=" + meaning + "&authorization=" + token,
        function(data, status) {
          if (status == "success") {
            outputSpan.innerHTML = data;
          }
        }
      );
    });
  }
  function editHandler() {
    root.innerHTML = getEditTemplate();
    search(1,0);
    $("button.edit-button").click(function() {
      var outputSpan = document.getElementsByClassName("output")[0];
      var word = $("input.edit-word").val();
      var meaning = $("input.edit-meaning").val();
      $.get("/edit?word=" + word + "&meaning=" + meaning + "&authorization=" + token, function(
        data,
        status
      ) {
        if (status == "success") {
          outputSpan.innerHTML = data;
        }
      });
    });
  }
  function search(showMeaning,shcard){
    var searchBar = document.getElementsByTagName("input")[0];
    searchBar.oninput = function() {
      $.get("/search?word=" + searchBar.value.trim() + '&authorization='+token, function(data, status) {
        if (status == "success") {
          let listGroup = document.getElementsByTagName("ul")[1];
          listGroup.innerHTML = data;
          var rcard = document.getElementsByClassName("card")[0];
          if (rcard) {
            rcard.innerHTML = "";
          }
          if(showMeaning == 1) searchUlHandler(shcard);
        }
      });
    };
  }
  function searchUlHandler(showcard){
    var searchBar = document.getElementsByTagName("input")[0];
    var listGroup = document.getElementsByTagName("ul")[1];
    $("ul button").each(function() {
      $(this).click(function() {
        var card = document.getElementsByClassName("card")[0];
        if(showcard == 1){
            card.innerHTML = putWordList($(this).text(), $(this).attr("val"));
        }
        else{
            var meaningBar = document.getElementsByTagName('input')[1];
            if(meaningBar){
                meaningBar.value = $(this).attr('val');
            }
        }
        searchBar.value = $(this).text();
        listGroup.innerHTML = "";
      });
    });
  }
  function searchHandler() {
    //this method changes the body to searchTemplate and then handles all tasks related to word
    root.innerHTML = getSearchTemplate();
    search(1,1);
  }
  function handleLoginHeaderLinks(){
    $("a").each(function() {
      $(this).click(function() {
        switch($(this).text()){
            case "Add": 
                addWordHandler();
                break;
            case "Search":
                searchHandler();
                break;
            case "Edit":
                editHandler();
                break;
            case "Logout":
                token = -1;
                handleInitialState();
        }
      });
    });
  }
  function handleChange() {
    $("button.login-button").click(function() {
      var outputSpan = document.getElementsByClassName("output")[0];
      var navbar = document.getElementsByTagName("ul")[0];
      var header = $("a.navbar-brand");
      var luserName = $("input.log-user-name").val();
      var lpassword = $("input.log-password").val();
      $.get("/login?username=" + luserName + "&password=" + lpassword + "&authorization=" + token, function(data,status) {
        if (status == "success") {
          if ((data + "").includes("Hello")) {
            token = (data+"").split(' ')[1];
            //outputSpan.innerHTML = data;
            navbar.innerHTML = getLoginHeaderTemplate();
            handleLoginHeaderLinks();
            header.text(luserName + " 's Dictionary");
            searchHandler();
          } else {
            outputSpan.innerHTML = data;
          }
        }
      });
    });
    $("button.register-button").click(function() {
      var outputSpan = document.getElementsByClassName("output")[0];
      var ruserName = $("input.reg-user-name")
        .val()
        .trim();
      var rpassword = $("input.reg-password")
        .val()
        .trim();
      $.get(
        "/register?username=" + ruserName + "&password=" + rpassword,
        function(data, status) {
          if (status == "success") {
            outputSpan.innerHTML = data;
          }
        }
      );
    });
    $("a").each(function() {
      $(this).click(function() {
        event.preventDefault();
        root.innerHTML = getMethod($(this).attr("href"));
        handleChange();
        $(".active").removeClass("active");
        $(this).addClass("active");
      });
    });
  }
  function handleInitialState(){
    root.innerHTML = getMethod("login");
    nav.innerHTML = getInitialHeaderTemplate();
    handleChange();
  }
  handleInitialState();
});
