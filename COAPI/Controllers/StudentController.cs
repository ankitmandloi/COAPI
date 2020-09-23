using COAPI.Models;
using com.sun.org.apache.xpath.@internal.operations;
using CsQuery.Engine.PseudoClassSelectors;
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
        public object Login(string uname,string pass)
        {
            string JSON;
            using (Entities c = new Entities())
            {
                
                if (c.USERS_TABLE.FirstOrDefault(p => p.Username == uname) != null) {
                    if(c.USERS_TABLE.FirstOrDefault(p => p.Password == pass) != null)
                    {
                    var items = c.USERS_TABLE.Where(x => x.Username == uname && x.Password==pass)
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
                   Password =m.password
                };
               c.USERS_TABLE.Add(reg);
                c.SaveChanges();
            }
            return true;
            
        }



        //public bool PlaceOrder(Model m)
        //{

        //    using (Entities c = new Entities())
        //    {

        //        USERS_TABLE reg = new USERS_TABLE
        //        {
        //            Username = m.username,
        //            Email = m.email,
        //            Password = m.password
        //        };
        //        c.USERS_TABLE.Add(reg);
        //        c.SaveChanges();
        //    }
        //    return true;

        //}













    }
}