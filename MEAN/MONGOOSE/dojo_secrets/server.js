const express = require('express');
const app = express();
const session = require('express-session');
const flash = require('express-flash');
const mongoose = require('mongoose');


app.use(express.static(__dirname + '/client/static'));
app.use(express.urlencoded({extended: true}));
app.use(session({
    secret: 'keyboardkitteh',
    resave: false,
    saveUninitialized: true,
    cookie: {
        maxAge: 60000
    }
}))
app.use(flash());

app.set('views', __dirname + '/client/views');
app.set('view engine', 'ejs');

mongoose.connect('mongodb://localhost/dojo_secrets_db', {
        useNewUrlParser: true
    });

require('./server/config/mongoose');
require('./server/config/routes')(app)



app.listen(1337);