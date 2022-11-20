const app = require('./app');

async function main() {

    //starting server
    await app.listen(app.get('port'), () => {
        console.log('server on localhost:' + app.get('port'));
    });
}

main();