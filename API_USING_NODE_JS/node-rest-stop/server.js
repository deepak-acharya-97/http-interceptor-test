const http = require('http');
const app = require('./app');
const port = 9009;


const server = http.createServer(app);

server.listen(port);