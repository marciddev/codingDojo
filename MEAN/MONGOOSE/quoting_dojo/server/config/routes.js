const mongoose = require('mongoose');//importing mongoose itself
require('./mongoose');
const quotes = require('../controllers/quotes');
module.exports = function (app) {
    app.get('/', (request, response) => {
        quotes.index(request, response);
    })

    //creating the form submission function
    app.post('/', function (request, response) {
        quotes.post_index(request, response);
    })
}