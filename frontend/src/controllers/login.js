const {render} = require('ejs')
const express = require('express')
const bcryptjs = require('bcryptjs');
const axios = require('axios');
const https = require('https');

const agent = new https.Agent({
    rejectUnauthorized: false,
   requestCert: false,
   agent: false,
  })

exports.login = (req,res) =>{
    res.render('login',{
        title: 'Login',
        login: req.session.loggedin,
        admin: req.session.admin,
        user: req.session.name
    })
}

exports.logiar = async(req,res)=>{
    const correo = req.body.correo;
    const pass = req.body.pass;
    let passwordHaash = await bcryptjs.hash(pass, 8);
    let c = false,p = false, a = false;
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
                  let data = response.data;
                  for (let i = 0; i < data.length; i++) {
                      if(correo == data[i].correo){
                           c = true;
                        if (pass === data[i].password){
                            p = true;
                            req.session.name = data[i].nombre;
                            if (data[i].tipo == "Admin") {
                                a = true
                                req.session.admin = true;
                            } else {
                                continue;
                            }
                        } else {
                            continue;
                        }
                      }else{
                          continue
                      }

                  }
                  console.log(c , p);
                  if (c && p) {
                    req.session.loggedin = true;
                    res.redirect('/Libros');
                  } else {
                    req.session.loggedin = false;
                    req.session.admin = true;
                    res.redirect('/login');
                  }
                });
        } catch (error) {
            console.error(error);
        }
    }
    getUsuarios();
}

exports.registro = async (req,res) =>{
    res.render('registro',{
        title: 'Registro',
        login: req.session.loggedin,
          admin: req.session.admin,
          user: req.session.name
    })
  }

exports.registral = async(req, res) => {
    const user = req.body;
    const pass = req.body.pass;
    // let passwordHaash = await bcryptjs.hash(pass, 8);
    try {
        axios.post('http://localhost:5000/api/Usuarios',{
          nombre: user.nombre,
          apellido: user.apellido,
          tipo: "user",
          correo: user.correo,
          password: pass,
        },{
            responseType: 'json',
            withCredentials: true,
            httpsAgent: agent
        })
        .then(function (response) {
            // console.log(response.data);
            res.redirect('/login');
          });
    } catch (error) {
        console.error(error);
    }
  }

exports.logout = (req, res) =>{
    req.session.destroy(()=>{
        res.redirect('/login')
    })
}