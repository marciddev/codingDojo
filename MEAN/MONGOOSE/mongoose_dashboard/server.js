//import express
const express = require('express');
//import mongoose
const mongoose = require('mongoose');
//setting the app
const app = express();
//running the server
//setting up the configuration of the app
// set up builtin middleware
//static
app.use(express.static(__dirname + "/client/static"));
//setup the post methods 
app.use(express.urlencoded());
//set the view files up
app.set('views', __dirname + '/client/views');
//set up the view engine itself
app.set('view engine', 'ejs');

//mongoose config ---------------------------
const m = require('./server/config/mongoose');
m.main();

//schema blueprint
const mongooseSchema = new mongoose.Schema({
    name: {type: String, required: true, minlength: 3},
    age: Number,
    created_at: {type: Date, default: Date.now()}
})

//create collections
const Mongoose = mongoose.model('mongoose', mongooseSchema);

//--------------------------------------------
require('./server/config/routes')(app);
app.listen(1337);