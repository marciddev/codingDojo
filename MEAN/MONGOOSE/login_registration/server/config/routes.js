const controller = require('../controllers/route_controller');

module.exports = (app) => {
    app.get('/', (request, response) => {
        controller.index(request, response);
    })
    app.post('/register-user', (request, response) => {
        controller.register(request, response);
    })
    app.post('/login-user', (request, response) => {
        controller.login(request, response);
    })
}