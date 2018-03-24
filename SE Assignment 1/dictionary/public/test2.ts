import { EventEmitter } from 'events';
let ee = new EventEmitter();
ee.subscribe((name: string) => console.log(`hello ${name}`));
ee.emit('Heni');