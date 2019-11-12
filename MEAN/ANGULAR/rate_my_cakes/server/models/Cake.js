const mongoose = require('mongoose');
const revSchema = require('./../models/Review');
const cakeSchema = new mongoose.Schema({
    baker: {type: String, required: true, minlength: 5},
    image: {type: String, required: true, minlength: 3},
    reviews: [revSchema]
})
const Cake = new mongoose.model('Cake', cakeSchema);
module.exports = Cake;