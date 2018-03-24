// function print(value) {
//   console.log(value);
// }
// function printerr(value){
//     console.log(value+"error");
// }

// function caller(callback1,callback2){
//     var result = 8;
//     if(result % 5 == 0){
//         callback1("odd");
//     }
//     else{
//         callback2("even");
//     }
// }

// var promise = new Promise(function(resolve,reject){
//     var result = 8; 
//     if(result % 5 == 0){
//         resolve("odd");
//     }
//     else{
//         reject("even");
//     }
// });

// promise.then(print,printerr);
// caller(print,printerr);

// var simpleObservable = new Observable(function(observer){
//     observer.next("Data to be sent");
//     observer.complete();
// });

// simpleObservable.subscribe(function (data) {
//     console.log(data);
// });

async function f(){
    var promise = new Promise((resolve,reject) => resolve("abcd"));
    result = await promise;
    console.log(result);
}
f();