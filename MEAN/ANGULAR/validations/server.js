const express = require('express');
const app = express();

app.use(express.static(__dirname + '/public/dist/public'));
app.listen(1337);

app.get('/', (request, response) => {
    response.json("Hello");
})