using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuministrosProject.Models;

namespace SuministrosProject.Domain
{
    public class perfilDomain
    {
        public string validarPerfil(Perfil perfil)
        {
            bool perfilIsEmpty = perfil == null;
            if (perfilIsEmpty)
            {
                return "Please, insert information in the fields";
            }

            bool profileName = perfil.PerfilName == null;
            if (profileName)
            {
                return "Insert the perfil";
            }

            bool profileDescription = perfil.Descripcion == null;
            if (profileName)
            {
                return "Insert a description for the perfil";
            }
            
            return null;
        }
    }
}
