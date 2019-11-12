const express = require("express");
const app = express();
const server = app.listen(1337);
const mongoose = require('mongoose');
const flash = require('express-flash');
const session = require('express-session');

app.use(express.static(__dirname + "/static"));
app.set('view engine', 'ejs');
app.set('views', __dirname + '/views');
app.use(express.urlencoded({
    extended: true
}));
app.use(flash());
app.use(session({
    secret: 'keyboardkitteh',
    resave: false,
    saveUninitialized: true,
    cookie: {
        maxAge: 60000
    }
}))
const connect = require('./server/config/mongoose');
connect.main();
require('./server/config/routes')(app);