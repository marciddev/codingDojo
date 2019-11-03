const express = require("express");
const app = express();
const server = app.listen(1337);
app.use(express.static(__dirname + "/static"));
app.set('view engine', 'ejs');
app.set('views', __dirname + '/views');
const session = require('express-session');
app.use(express.urlencoded({extended: true}));
app.use(session({
  secret: 'keyboardkitteh',
  resave: false,
  saveUninitialized: true,
  cookie: { maxAge: 60000 }
}))
const io = require('socket.io')(server);
let counter = 0;
io.on('connection', function(socket) {
    console.log("connected");
    socket.on('isclicked', function(data) {
        counter++;
        io.emit('update_number', {count: counter});
    })
    socket.on('reset', function(data) {
        counter = data.num;
    })
})
app.get("/", (request, response) => {
    response.render("index");
})