const controller = require('../controllers/route_controller');

module.exports = function(app) {
    app.get('/tasks', (request, response) => {
        controller.index(request, response);
    })
    app.post('/tasks', controller.make_task);
    app.get('/tasks/:id', (request, response) => {
        controller.view_task(request, response);
    })
    app.put('/tasks/:id', controller.put_task);
    app.delete('/tasks/:id', (request, response) => {
        controller.del_task(request, response);
    })
}