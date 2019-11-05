const controller = require('../controllers/route_controller');

module.exports = function(app) {
    app.get('/tasks', (request, response) => {
        controller.index(request, response);
    })
    app.get('/tasks/:id', (request, response) => {
        controller.view_task(request, response);
    })
    app.post('/tasks', (request, response) => {
        controller.make_task(request, response);
    })
    app.put('/tasks/:id', (request, response) => {
        controller.put_task(request, response);
    })
    app.delete('/tasks/:id', (request, response) => {
        controller.del_task(request, response);
    })
}