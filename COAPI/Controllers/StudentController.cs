using COAPI.Models;
using com.sun.org.apache.xpath.@internal.operations;
using CsQuery.Engine.PseudoClassSelectors;
using CsQuery.Utility;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace COAPI.Controllers
{

    public class StudentsController : Controller
    {
        // LOGIN 
        public object Login(string uname, string pass)
        {
            string JSON;
            using (Entities c = new Entities())
            {

                if (c.USERS_TABLE.FirstOrDefault(p => p.Username == uname) != null)
                {
                    if (c.USERS_TABLE.FirstOrDefault(p => p.Password == pass) != null)
                    {
                        var items = c.USERS_TABLE.Where(x => x.Username == uname && x.Password == pass)
                                .Select(x => new
                                {
                                    username = x.Username,
                                    password = x.Email
                                });

                        JSON = JsonConvert.SerializeObject(items);
                        return JSON;
                    }
                    return false;
                }
                return false;
            }
        }




        //Register a user

        public bool Register(Model m)
        {

            using (Entities c = new Entities())
            {

                USERS_TABLE reg = new USERS_TABLE
                {
                    Username = m.username,
                    Email = m.email,
                    Password = m.password
                };
                c.USERS_TABLE.Add(reg);
                c.SaveChanges();
            }
            return true;

        }



        public bool PlaceOrder(PlaceOrders p)
        {

            using (Entities5 c = new Entities5())
            {

                Place_Order reg = new Place_Order
                {
                    rupya = p.rupya,
                    ph = p.ph,
                    paisa = p.paisa,
                    firstname = p.firstname,
                    lastname = p.lastname,
                    email = p.email,
                    countrycode = p.countrycode,
                    country = p.country,
                    buyerfname = p.buyerfname,
                    buyerlname = p.buyerlname,
                    address = p.address,
                    state = p.state,
                    pin = p.pin
                };
                c.Place_Order.Add(reg);
                c.SaveChanges();
            }
            return true;

        }


        public object ViewOrders(string username)
        {
            
            using (Entities5 c = new Entities5())
            {
               var items = c.Place_Order.Where(x => x.buyerfname == username)
                                       .Select(x => new
                                        {

                                         rupya = x.rupya,
                                           address = x.address,
                                           buyerfname = x.rupya,
                                           firstname = x.firstname,

                                           //paisa = p.paisa,
                                           //firstname = p.firstname,
                                           //lastname = p.lastname,
                                           //email = p.email,
                                           //countrycode = p.countrycode,
                                           //country = p.country,
                                           //buyerfname = p.buyerfname,
                                           //buyerlname = p.buyerlname,
                                           //address = p.address,
                                           //state = p.state,
                                           //pin = p.pin



                                           //username = x.Username,
                                           //password = x.Email
                                       });

               var JSONA = JsonConvert.SerializeObject(items);
                return JSONA;

            }
            return false;
          
        }

    }
}