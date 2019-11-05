const express = require('express');
const app = express();

app.set('views', __dirname + '/client/views');
app.set('view engine', 'ejs');

app.use(express.json());
app.use(express.static(__dirname + '/client/static'));

const mong = require('./server/config/mongoose');
mong.main();

require('./server/config/routes')(app);



app.listen(1337);