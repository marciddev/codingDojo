const express = require('express');
const app = express();
const path = require('path');
app.listen(1337);
app.use(express.static(__dirname + '/public/dist/public'));

app.all("*", (request,response,next) => {
    response.sendFile(path.resolve("./public/dist/public/index.html"))
})
