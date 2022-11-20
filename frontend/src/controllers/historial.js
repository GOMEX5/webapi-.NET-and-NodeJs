const {render} = require('ejs');
const axios = require('axios');
const https = require('https')

const agent = new https.Agent({
    rejectUnauthorized: false,
   requestCert: false,
   agent: false,
  })

exports.historial = (req, res) => {
    async function getHistorial() {
        try {
            axios({
                method: 'get',
                url: 'http://localhost:5000/api/Historials',
                responseType: 'json',
                withCredentials: true,
                httpsAgent: agent
              })
                .then(function (response) {
                  // console.log(response.data);
                  res.render('Historial/Historial',{
                    title: 'Historial',
                    historial: response.data,
                    login: req.session.loggedin,
        admin: req.session.admin,
        user: req.session.name
                })
                });
        } catch (error) {
            console.error(error);
        }
    }
    getHistorial();
}


// exports.insert = async (req,res) =>{
//     res.render('insert',{
//         title: 'Crud NodeJS MongoDB',
//     })
// }
// exports.add = async (req,res) => {
//     const task = new Task(req.body);
//     await task.save();
//     res.redirect('/');
// }

// exports.delete = async (req,res) => {
//     const {id} = req.params;
//     await Task.remove({_id:id});
//     res.redirect('/');
// }

// exports.done = async (req,res) =>{
//     const {id} = req.params;
//     const task = await Task.findById(id);
//     task.status = !task.status;
//     await task.save();
//     res.redirect('/');
// }

// exports.edit = async (req,res) => {
//     const {id} = req.params;
//     const task = await Task.findById(id);
//     res.render('edit',{
//         title: 'Crud NodeJS MongoDB',
//         task
//     });
// }

// exports.update = async (req,res) => {
//     const {id} = req.params;
//     await Task.update({_id:id},req.body);
//     res.redirect('/');
// }

