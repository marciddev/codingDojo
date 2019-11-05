const controller = require('../controller/routes_controller');

module.exports = function (app) {

    app.get('/', (request, response) => {
        controller.index(request, response);
    })
    app.get('/new/:name', (request, response) => {
        controller.new_person(request, response);
    })
    app.get('/remove/:name', (request, response) => {
        controller.delete_person(request, response);
    })
    app.get('/:name', (request, response) => {
        controller.view_person(request, response);
    })
}