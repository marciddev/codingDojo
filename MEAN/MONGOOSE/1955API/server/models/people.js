const mongoose = require('mongoose');

const PersonSchema = new mongoose.Schema({
    name: String,
    created_at: {type: Date, default: Date.now()}
})
module.exports = mongoose.model('Person',PersonSchema);