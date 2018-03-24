"use strict";
exports.__esModule = true;
var events_1 = require("events");
var ee = new events_1.EventEmitter();
ee.subscribe(function (name) { return console.log("hello " + name); });
ee.emit('Heni');
