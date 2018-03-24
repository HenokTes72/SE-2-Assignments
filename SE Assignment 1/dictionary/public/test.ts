var nate = {
    name: "Nate",
    guitars: ["Gibson","Matin","Taylor"],
    printGuitars: function(){
        this.guitars.forEach(element => console.log(this.name+" plays a "+element));
    }
}
nate.printGuitars();