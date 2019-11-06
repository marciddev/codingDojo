const controller = require('../controllers/routes_controller');

module.exports = (app) => {
    app.get('/', (request, response) => {
        controller.index(request, response);
    })
    app.post('/register-user', (request, response) => {
        controller.register(request, response);
    })
    app.get('/home', (request, response) => {
        controller.home(request, response);
    })
    app.post('/login-user', (request, response) => {
        controller.login(request, response);
    })
    app.get('/logout', (request, response) => {
        controller.logout(request, response);
    })
    app.post('/create_secret', (request, response)=> {
        controller.secretcreate(request, response);
    })
    app.get('/secret/delete/:id', (request, response) => {
        controller.secretdelete(request, response);  
    })
    app.get('/secret/:id', (request, response) => {
        controller.view_secret(request, response);
    })
    app.post('/create-comment/secret:id', (request, response) => {
        controller.make_comment(request, response);
    })
}