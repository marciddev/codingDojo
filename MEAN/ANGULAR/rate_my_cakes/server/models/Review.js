const mongoose = require('mongoose');
const cakeSchema = require('./Cake');

const reviewSchema = new mongoose.Schema({
    rating: {type: Number, required: true},
    comment: {type: String, required: true},
})

const Review = new mongoose.model("Review", reviewSchema);
module.exports = cakeSchema;