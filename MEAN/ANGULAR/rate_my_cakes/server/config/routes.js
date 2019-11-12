const controller = require('./../controllers/routes_controller');

module.exports = function(app) {
    app.get('/', controller.home);
    app.post('/', controller.create);
    app.get('/cakes', controller.allcakes);
    app.post('/review/:id', controller.addRev);
    app.get('/cakes/:id', controller.oneCake);
}