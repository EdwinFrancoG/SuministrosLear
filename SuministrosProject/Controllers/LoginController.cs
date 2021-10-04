using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.DirectoryServices;
using System.Runtime.InteropServices;
using SuministrosProject.Models;
using System.Web.Mvc;
using System.ComponentModel;

namespace SuministrosProject.Controllers
{
    public class LoginController : Controller
    {
        private SuministrosContext db = new SuministrosContext();
        // GET: Login
        public ActionResult loginGet()
        {
            return View();
        }

        public string Logear(string usuario, string password)
        {
       
            using (DirectoryEntry entry = new DirectoryEntry())
            {
                entry.Username = usuario;
                entry.Password = password;

                DirectorySearcher directorySearcher = new DirectorySearcher(entry);

                directorySearcher.Filter = "(objectclass=user)";

                try
                {
                    if (directorySearcher.FindOne() != null)
                    {
                        if (db.Usuario.FirstOrDefault(u=>u.usuario == usuario) != null)
                        {
                            return "OK";
                        }
                        else
                        {
                            return "NofoundInDB";
                        }
                    }
                }
                catch (Exception)
                {
                    return "NoEncontrado";
                }
                return "OK";
            }

        }
    }
}