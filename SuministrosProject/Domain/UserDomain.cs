using SuministrosProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuministrosProject.Domain
{
    public class UserDomain
    {
        public string userValidate(Usuario user)
        {
            bool userModelIsEmpty = user == null;
            if (userModelIsEmpty)
            {
                return "Please Insert Data in the fields";
            }

            bool nameIsNull = user.Nombre == null;
            if (nameIsNull)
            {
                return "The field of the name is empty, plese insert the name";
            }

            bool lastnameIsNull = user.Apellido == null;
            if (lastnameIsNull)
            {
                return "The field of the last name is empty, plese insert the last name";
            }

            bool userIsNull = user.usuario == null;
            if (userIsNull)
            {
                return "Please insert the user of: " + user.Nombre;
            }

            return null;

        }

    }
}