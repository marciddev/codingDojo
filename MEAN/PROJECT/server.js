const express = require('express');
const app = express();
const mongoose = require('mongoose');
const path = require('path');
const http = require('http').Server(app);
const io = require('socket.io')(http);
const session = require('express-session');
app.use(express.static(__dirname + '/public/dist/public'));
app.use(express.json());
app.use(session({
    secret: 'keyboard cat',
    resave: false,
    saveUninitialized: true,
    cookie: { secure: true }
  }))
let count = 0;
io.on('connection', socket => {
    count++;
    io.emit('numOnline', count);
    socket.on('disconnect', () => {
        count = count-1;
        console.log(count + " is on disconnect");
        io.emit('numOnline', count);
    })
    socket.on('message_sent', data => {
        io.emit('message_back_to_client', data)
    })
})

http.listen(1337);