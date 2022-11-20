const {Router} = require('express');
const router = Router();

//login
const controllersLogin = require('../controllers/login');
router.get('/login',controllersLogin.login);
router.post('/logiar',controllersLogin.logiar);
router.get('/logout',controllersLogin.logout);
router.get('/registro_usuario',controllersLogin.registro);
router.post('/registral',controllersLogin.registral);

//Libros
const controllersLibros = require('../controllers/libros');
router.get('/',controllersLibros.libros);
router.get('/Libros',controllersLibros.libros);
router.get('/add_Libro',controllersLibros.addLibro);
router.post('/insert_libro',controllersLibros.insertLibro);
router.get('/delete_libro/:id',controllersLibros.deleteLibros);
router.get('/edit_libro/:id',controllersLibros.editLibros);
router.post('/update_libro/:id',controllersLibros.updateLibros);

//Usuarios
const controllersUsuarios = require('../controllers/Usuarios');
router.get('/Usuarios',controllersUsuarios.Usuarios);
router.get('/add_usuario',controllersUsuarios.addUsuario);
router.post('/insert_usuario',controllersUsuarios.insertUsuario);
router.get('/delete_usuario/:id',controllersUsuarios.deleteUsuario);
router.get('/edit_usuario/:id',controllersUsuarios.editUsuario);
router.post('/update_usuario/:id',controllersUsuarios.updateUsuario);

//Revistas
const controllersRevistas = require('../controllers/revista');
router.get('/Revistas',controllersRevistas.revistas);
router.get('/add_Revista',controllersRevistas.addRevista);
router.post('/insert_revista',controllersRevistas.insertRevista);
router.get('/delete_revista/:id',controllersRevistas.deleteRevista);
router.get('/edit_revista/:id',controllersRevistas.editRevista);
router.post('/update_revista/:id',controllersRevistas.updateRevista);

//Historial
const controllersHistorial = require('../controllers/historial');
router.get('/Historial',controllersHistorial.historial);

//Periodicos
const controllersPeriodico = require('../controllers/periodico');
router.get('/Periodico',controllersPeriodico.periodico);
router.get('/add_periodico',controllersPeriodico.addPeriodico);
router.post('/insert_periodico',controllersPeriodico.insertPeriodico);
router.get('/delete_periodico/:id',controllersPeriodico.deletePeriodico);
router.get('/edit_periodico/:id',controllersPeriodico.editPeriodico);
router.post('/update_periodico/:id',controllersPeriodico.updatePeriodico);

//AudioLibros
const controllersAudioLibros = require('../controllers/audioLibro');
router.get('/AudioLibro',controllersAudioLibros.audioLibros);
router.get('/add_audio_libro',controllersAudioLibros.addAudioLibro);
router.post('/insert_audio_libro',controllersAudioLibros.insertAudioLibro);
router.get('/delete_audio_libro/:id',controllersAudioLibros.deleteAudioLibros);
router.get('/edit_audio_libro/:id',controllersAudioLibros.editAudioLibros);
router.post('/update_audio_libro/:id',controllersAudioLibros.updateAudioLibros);

module.exports = router;