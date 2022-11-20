const {render} = require('ejs');
const axios = require('axios');
const https = require('https')

const agent = new https.Agent({
    rejectUnauthorized: false,
   requestCert: false,
   agent: false,
  })

exports.audioLibros = (req, res) => {
    async function getAudioLibros() {
        try {
            axios({
                method: 'get',
                url: 'http://localhost:5000/api/AudioLibros',
                responseType: 'json',
                withCredentials: true,
                httpsAgent: agent
              })
                .then(function (response) {
                  // console.log(response.data);
                  res.render('AudioLibro/AudioLibros',{
                    title: 'AudioLibros',
                    audioLibro: response.data,
                    login: req.session.loggedin,
        admin: req.session.admin,
        user: req.session.name
                })
                });
        } catch (error) {
            console.error(error);
        }
    }
    getAudioLibros();
}

exports.addAudioLibro = async (req,res) =>{
  res.render('AudioLibro/addAudioLibro',{
      title: 'Add Audio Libro',
      login: req.session.loggedin,
        admin: req.session.admin,
        user: req.session.name
  })
}

exports.insertAudioLibro = (req, res) => {
  const audioLibro = req.body;
  // console.log(audioLibro);
  try {
      axios.post('http://localhost:5000/api/AudioLibros',{
          titulo : audioLibro.titulo,
          tipo : audioLibro.tipo,
          autor : audioLibro.autor,
          editorial : audioLibro.editorial,
          img : audioLibro.img,
      },{
          responseType: 'json',
          withCredentials: true,
          httpsAgent: agent
      })
      .then(function (response) {
          // console.log(response.data);
          res.redirect('/AudioLibro');
        });
  } catch (error) {
      console.error(error);
  }
}


exports.deleteAudioLibros = (req, res) => {
  const { id } = req.params;
  try {
      axios.delete('http://localhost:5000/api/AudioLibros/'+id,{
      responseType: 'json',
      withCredentials: true,
      httpsAgent: agent
  })
  .then(function (response) {
      // console.log(response.data);
      res.redirect('/AudioLibro');
    });
  } catch (error) {
      console.log(error);
  }
}

exports.editAudioLibros = (req, res) => {
  const { id } = req.params;
  try {
      axios.get('http://localhost:5000/api/AudioLibros/'+id,{
      responseType: 'json',
      withCredentials: true,
      httpsAgent: agent
  })
  .then(function (response) {
      // console.log(response.data);
      res.render('AudioLibro/updateAudioLibro',{
          title: 'Editar Audio Libro',
          audioLibro: response.data,
          login: req.session.loggedin,
        admin: req.session.admin,
        user: req.session.name
      })
    });
  } catch (error) {
      console.log(error);
  }
}

exports.updateAudioLibros = (req, res) => {
  const { id } = req.params;
  const audioLibro = req.body;
  try {
          axios.put('http://localhost:5000/api/AudioLibros',{
          idAudioLibro : parseInt(id),
          titulo : audioLibro.titulo,
          tipo : audioLibro.tipo,
          autor : audioLibro.autor,
          editorial : audioLibro.editorial,
          img : audioLibro.img,
      },{
          responseType: 'json',
          withCredentials: true,
          httpsAgent: agent
      })
      .then(function (response) {
          // console.log(response.data);
          res.redirect('/AudioLibro');
      });

  } catch (error) {
      console.log(error);
  }
}