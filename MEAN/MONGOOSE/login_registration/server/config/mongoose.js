const mongoose = require('mongoose');
const fs = require('fs');
const path = require('path');

module.exports = {
    main: () => {
        mongoose.connect('mongodb://localhost/login_registration_db');
        // create a variable that points to the models folder
        var models_path = path.join(__dirname, './../models');
        console.log('*'.repeat(90));
        console.log(models_path);
        // read all of the files in the models_path and require (run) each of the javascript files
        fs.readdirSync(models_path).forEach(function (file) {
            if (file.indexOf('.js') >= 0) {
                // require the file (this runs the model file which registers the schema)
                require(models_path + '/' + file);
            }
        })
    }
}