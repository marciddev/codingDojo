const express = require('express');
const app = express();

app.set('views', __dirname + '/client/views');
app.set('view engine', 'ejs');

app.use(express.json());
app.use(express.static(__dirname + '/public/dist/public'));


require('./server/config/mongoose').main();
require('./server/config/routes')(app);

app.listen(1337);