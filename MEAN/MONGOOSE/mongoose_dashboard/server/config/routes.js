const mongoose = require('mongoose');
const mongeese = require('../controllers/mongeese');

module.exports = function (app) {
    app.get('/mongooses/edit/:editid', (request, response) => {
        mongeese.index(request, response);
    })

    app.get('/', (request, response) => {
        mongeese.root(request, response);
    })
    app.post('/mongooses', (request, response) => {
        mongeese.mongooses_post(request, response);
    })
    app.get('/mongooses/new', (req, response) => {
        mongeese.new_mongoose(req, response);
    })
    app.get('/mongooses/destroy/:id', (request, response) => {
        mongeese.destroy_mongoose(request, response);
    })
    app.get('/mongooses/:id', (request, response) => {
        mongeese.get_mongoose(request, response);
    })
    app.post('/mongooses/:id', (request, response) => {
        mongeese.post_mongoose(request, response);
    })
}