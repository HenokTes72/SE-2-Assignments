var nate = {
    name: "Nate",
    guitars: ["Gibson", "Matin", "Taylor"],
    printGuitars: function () {
        var _this = this;
        this.guitars.forEach(function (element) { return console.log(_this.name + " plays a " + element); });
    }
};
nate.printGuitars();
