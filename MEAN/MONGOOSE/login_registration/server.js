const express = require('express');
const app = express();

app.use(express.static(__dirname + '/client/static'));
app.use(express.urlencoded());

app.set('views', __dirname + '/client/views');
app.set('view engine', 'ejs');

require('./server/config/mongoose').main();
require('./server/config/routes')(app);

app.listen(1337);