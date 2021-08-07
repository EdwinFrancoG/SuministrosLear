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
                return "Por favor ingrese informacion en los campos";
            }

            bool profileName = perfil.PerfilName == null;
            if (profileName)
            {
                return "Ingrese el nombre del perfil";
            }

            bool profileDescription = perfil.Descripcion == null;
            if (profileName)
            {
                return "Por favor ingrese la descripcion del perfil a crear";
            }
            
            return null;
        }
    }
}