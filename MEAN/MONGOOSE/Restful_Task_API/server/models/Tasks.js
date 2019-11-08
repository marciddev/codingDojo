const mongoose = require('mongoose');

const TaskSchema = new mongoose.Schema({
    title: {type: String, default: 'default_title'},
    description: {type: String, default: 'default_desc'},
    completed: {type: Boolean, default: false},
    created_at: {type: Date, default: Date.now()},
    updated_at: {type: Date, default: Date.now()}
})
module.exports = mongoose.model('Task', TaskSchema);