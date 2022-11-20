const {render} = require('ejs');
const axios = require('axios');
const https = require('https')

const agent = new https.Agent({
    rejectUnauthorized: false,
   requestCert: false,
   agent: false,
  })

exports.revistas = (req, res) => {
    async function getRevistas() {
        try {
            axios({
                method: 'get',
                url: 'http://localhost:5000/api/Revistas',
                responseType: 'json',
                withCredentials: true,
                httpsAgent: agent
              })
                .then(function (response) {
                  // console.log(response.data);
                  res.render('Revista/Revistas',{
                    title: 'Revista',
                    revista: response.data,
                    login: req.session.loggedin,
        admin: req.session.admin,
        user: req.session.name
                })
                });
        } catch (error) {
            console.error(error);
        }
    }
    getRevistas();
}


exports.addRevista = async (req,res) =>{
  res.render('Revista/addRevista',{
      title: 'Add Revista',
      login: req.session.loggedin,
        admin: req.session.admin,
        user: req.session.name
  })
}

exports.insertRevista = (req, res) => {
  const revista = req.body;
  try {
      axios.post('http://localhost:5000/api/Revistas',{
          titulo : revista.titulo,
          autor : revista.autor,
          fechaPublicacion : revista.fechaPublicacion,
          img : revista.img,
      },{
          responseType: 'json',
          withCredentials: true,
          httpsAgent: agent
      })
      .then(function (response) {
          // console.log(response.data);
          res.redirect('/Revistas');
        });
  } catch (error) {
      console.error(error);
  }
}


exports.deleteRevista = (req, res) => {
  const { id } = req.params;
  try {
      axios.delete('http://localhost:5000/api/Revistas/'+id,{
      responseType: 'json',
      withCredentials: true,
      httpsAgent: agent
  })
  .then(function (response) {
      // console.log(response.data);
      res.redirect('/Revistas');
    });
  } catch (error) {
      console.log(error);
  }
}

exports.editRevista = (req, res) => {
  const { id } = req.params;
  try {
      axios.get('http://localhost:5000/api/Revistas/'+id,{
      responseType: 'json',
      withCredentials: true,
      httpsAgent: agent
  })
  .then(function (response) {
      // console.log(response.data);
      res.render('Revista/updateRevista',{
          title: 'Editar Revista',
          revista: response.data,
          login: req.session.loggedin,
        admin: req.session.admin,
        user: req.session.name
      })
    });
  } catch (error) {
      console.log(error);
  }
}

exports.updateRevista = (req, res) => {
  const { id } = req.params;
  const revista = req.body;
  console.log(id);
  console.log(revista);
  try {
          axios.put('http://localhost:5000/api/Revistas',{
          idRevista : parseInt(id),
          titulo : revista.titulo,
          autor : revista.autor,
          fechaPublicacion : revista.fechaPublicacion,
          img : revista.img,
      },{
          responseType: 'json',
          withCredentials: true,
          httpsAgent: agent
      })
      .then(function (response) {
          // console.log(response.data);
          res.redirect('/Revistas');
      });

  } catch (error) {
      console.log(error);
  }
}
