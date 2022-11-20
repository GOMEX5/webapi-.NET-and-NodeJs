const path = require('path');
const morgan = require('morgan');
const express = require('express');
const app = express();

//importing routers
const router = require('./routers/index');

//setting
app.set('port',process.env.PORT || 4000);
app.set('views',path.join(__dirname,'views'));
app.set('view engine','ejs');

//session
const session = require('express-session');
app.use(session({
	secret: 'secret',
	resave: true,
	saveUninitialized: true
}));

//middlewares
app.use(morgan('dev'));
app.use(express.urlencoded({extended:false}));

//routers
app.use('/',router);

//static files
app.use(express.static(path.join(__dirname,'public')));

module.exports = app;