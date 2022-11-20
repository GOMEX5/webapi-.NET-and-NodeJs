const {render} = require('ejs');
const axios = require('axios');
const https = require('https')

const agent = new https.Agent({
    rejectUnauthorized: false,
   requestCert: false,
   agent: false,
  })

exports.periodico = (req, res) => {
    async function getPeriodicos() {
        try {
            axios({
                method: 'get',
                url: 'http://localhost:5000/api/Periodicos',
                responseType: 'json',
                withCredentials: true,
                httpsAgent: agent
              })
                .then(function (response) {
                  // console.log(response.data);
                  res.render('Periodico/Periodicos',{
                    title: 'Periodicos',
                    periodico: response.data,
                    login: req.session.loggedin,
        admin: req.session.admin,
        user: req.session.name
                })
                });
        } catch (error) {
            console.error(error);
        }
    }
    getPeriodicos();
}


exports.addPeriodico = async (req,res) =>{
  res.render('Periodico/addPeriodico',{
      title: 'Add Periodico',
      login: req.session.loggedin,
        admin: req.session.admin,
        user: req.session.name
  })
}

exports.insertPeriodico = (req, res) => {
  const periodico = req.body;
  try {
      axios.post('http://localhost:5000/api/Periodicos',{
          nombre : periodico.nombre,
          tipo : periodico.tipo,
          fechaEdicion : periodico.fechaEdicion,
          numero : periodico.numero,
          img : periodico.img,
      },{
          responseType: 'json',
          withCredentials: true,
          httpsAgent: agent
      })
      .then(function (response) {
          // console.log(response.data);
          res.redirect('/Periodico');
        });
  } catch (error) {
      console.error(error);
  }
}


exports.deletePeriodico = (req, res) => {
  const { id } = req.params;
  try {
      axios.delete('http://localhost:5000/api/Periodicos/'+id,{
      responseType: 'json',
      withCredentials: true,
      httpsAgent: agent
  })
  .then(function (response) {
      // console.log(response.data);
      res.redirect('/Periodico');
    });
  } catch (error) {
      console.log(error);
  }
}

exports.editPeriodico = (req, res) => {
  const { id } = req.params;
  try {
      axios.get('http://localhost:5000/api/Periodicos/'+id,{
      responseType: 'json',
      withCredentials: true,
      httpsAgent: agent
  })
  .then(function (response) {
      // console.log(response.data);
      res.render('Periodico/updatePeriodico',{
          title: 'Editar Periodico',
          periodico: response.data,
          login: req.session.loggedin,
        admin: req.session.admin,
        user: req.session.name
      })
    });
  } catch (error) {
      console.log(error);
  }
}

exports.updatePeriodico = (req, res) => {
  const { id } = req.params;
  const periodico = req.body;
  try {
          axios.put('http://localhost:5000/api/Periodicos',{
          idPeriodico : parseInt(id),
          nombre : periodico.nombre,
          tipo : periodico.tipo,
          fechaEdicion : periodico.fechaEdicion,
          numero : periodico.numero,
          img : periodico.img
      },{
          responseType: 'json',
          withCredentials: true,
          httpsAgent: agent
      })
      .then(function (response) {
          // console.log(response.data);
          res.redirect('/Periodico');
      });

  } catch (error) {
      console.log(error);
  }
}
