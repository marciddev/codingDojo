const mongoose = require('mongoose');

const mongooseSchema = new mongoose.Schema({
    name: {type: String, required: true, minlength: 3},
    age: Number,
    created_at: {type: Date, default: Date.now()}
})

//create collections
module.exports = mongoose.model('Mongoose', mongooseSchema);