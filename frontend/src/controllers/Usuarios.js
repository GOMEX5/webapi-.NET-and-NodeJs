const {render} = require('ejs');
const axios = require('axios');
const https = require('https');
const bcryptjs = require('bcryptjs');

const agent = new https.Agent({
    rejectUnauthorized: false,
   requestCert: false,
   agent: false,
  })

exports.Usuarios = (req, res) => {
    async function getUsuarios() {
        try {
            axios({
                method: 'get',
                url: 'http://localhost:5000/api/Usuarios',
                responseType: 'json',
                withCredentials: true,
                httpsAgent: agent
              })
                .then(function (response) {
                  // console.log(response.data);
                  res.render('Usuarios/Usuarios',{
                    title: 'Usuarios',
                    usuarios: response.data,
                    login: req.session.loggedin,
                    admin: req.session.admin,
                    user: req.session.name
                })
                });
        } catch (error) {
            console.error(error);
        }
    }
    getUsuarios();
}


exports.insertUsuario = async(req, res) => {
  const user = req.body;
  const pass = req.body.pass;
  // let passwordHaash = await bcryptjs.hash(pass, 8);
  try {
      axios.post('http://localhost:5000/api/Usuarios',{
        nombre: user.nombre,
        apellido: user.apellido,
        tipo: user.tipo,
        correo: user.correo,
        password: pass,
      },{
          responseType: 'json',
          withCredentials: true,
          httpsAgent: agent
      })
      .then(function (response) {
          // console.log(response.data);
          res.redirect('/Usuarios');
        });
  } catch (error) {
      console.error(error);
  }
}

exports.addUsuario = (req,res) =>{
  res.render('Usuarios/addUsuario',{
      title: 'Login',
      login: req.session.loggedin,
      admin: req.session.admin,
      user: req.session.name
  })
}

exports.deleteUsuario = (req, res) => {
  if (req.session.admin) {
      const { id } = req.params;
  try {
      axios.delete('http://localhost:5000/api/Usuarios/'+id,{
      responseType: 'json',
      withCredentials: true,
      httpsAgent: agent
  })
  .then(function (response) {
      // console.log(response.data);
      res.redirect('/Usuarios');
    });
  } catch (error) {
      console.log(error);
  }
  } else {
      res.redirect('/Libros');
  }
}

exports.editUsuario = (req, res) => {
  if (req.session.admin) {
      const { id } = req.params;
  try {
      axios.get('http://localhost:5000/api/Usuarios/'+id,{
      responseType: 'json',
      withCredentials: true,
      httpsAgent: agent
  })
  .then(function (response) {
      console.log(response.data);
      res.render('Usuarios/updateUsuario',{
          title: 'Editar Usuario',
          usuario: response.data,
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

exports.updateUsuario = (req, res) => {
  const { id } = req.params;
  const user = req.body;
  try {
          axios.put('http://localhost:5000/api/Usuarios',{
          idUsuario : parseInt(id),
          nombre : user.nombre,
          apellido : user.apellido,
          tipo : user.tipo,
          correo : user.correo,
          password : user.pass
      },{
          responseType: 'json',
          withCredentials: true,
          httpsAgent: agent
      })
      .then(function (response) {
          // console.log(response.data);
          res.redirect('/Usuarios');
      });

  } catch (error) {
      console.log(error);
  }
}