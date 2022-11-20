const {render} = require('ejs');
const axios = require('axios');
const https = require('https')

const agent = new https.Agent({
    rejectUnauthorized: false,
   requestCert: false,
   agent: false,
  })

exports.libros = (req, res) => {
        async function getLibros() {
            try {
                axios({
                    method: 'get',
                    url: 'http://localhost:8080/api/Libros',
                    responseType: 'json',
                    withCredentials: true,
                    httpsAgent: agent
                  })
                    .then(function (response) {
                    //   console.log(response.data);
                      res.render('Libro/Libros',{
                        title: 'Biblioteca',
                        libros: response.data,
                        login: req.session.loggedin,
                        admin: req.session.admin,
                        user: req.session.name
                    })
                    });
            } catch (error) {
                console.error(error);
            }
        }
        getLibros();
}


exports.addLibro = async (req,res) =>{
    if (req.session.admin) {
        res.render('Libro/addLibro',{
            title: 'Add Libro',
            login: req.session.loggedin,
            admin: req.session.admin,
            user: req.session.name
        })
    } else {
        res.redirect('/Libros');
    }
}

exports.insertLibro = (req, res) => {
    if (req.session.admin) {
        const libro = req.body;
    console.log(libro);
    try {
        axios.post('http://localhost:5000/api/Libros',{
            titulo : libro.titulo,
            categoria : libro.categoria,
            autor : libro.autor,
            editorial : libro.editorial,
            img : libro.img,
        },{
            responseType: 'json',
            withCredentials: true,
            httpsAgent: agent
        })
        .then(function (response) {
            // console.log(response.data);
            res.redirect('/Libros');
          });
    } catch (error) {
        console.error(error);
    }
    } else {
        res.redirect('/Libros');
    }
}


exports.deleteLibros = (req, res) => {
    if (req.session.admin) {
        const { id } = req.params;
    try {
        axios.delete('http://localhost:5000/api/Libros/'+id,{
        responseType: 'json',
        withCredentials: true,
        httpsAgent: agent
    })
    .then(function (response) {
        // console.log(response.data);
        res.redirect('/Libros');
      });
    } catch (error) {
        console.log(error);
    }
    } else {
        res.redirect('/Libros');
    }
}

exports.editLibros = (req, res) => {
    if (req.session.admin) {
        const { id } = req.params;
    try {
        axios.get('http://localhost:5000/api/Libros/'+id,{
        responseType: 'json',
        withCredentials: true,
        httpsAgent: agent
    })
    .then(function (response) {
        // console.log(response.data);
        res.render('Libro/updateLibro',{
            title: 'Editar Libro',
            libro: response.data,
            login: req.session.loggedin,
            admin: req.session.admin,
            user: req.session.name
        })
      });
    } catch (error) {
        console.log(error);
    }
    } else {
        res.redirect('/Libros');
    }
}

exports.updateLibros = (req, res) => {
    const { id } = req.params;
    const libro = req.body;
    try {
            axios.put('http://localhost:5000/api/Libros',{
            idLibro : parseInt(id),
            titulo : libro.titulo,
            categoria : libro.categoria,
            autor : libro.autor,
            editorial : libro.editorial,
            img : libro.img,
        },{
            responseType: 'json',
            withCredentials: true,
            httpsAgent: agent
        })
        .then(function (response) {
            // console.log(response.data);
            res.redirect('/Libros');
        });

    } catch (error) {
        console.log(error);
    }
}
