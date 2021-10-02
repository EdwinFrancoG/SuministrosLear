using SuministrosProject.Domain;
using SuministrosProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SuministrosProject.AppServices
{
    public class UserAppServices
    {
        public SuministrosContext db = new SuministrosContext();
        public readonly UserDomain _userDomain = new UserDomain();
      
        public async Task<string> IngresarUsuario(Usuario user)
        {
            var respuestaUserDomain = _userDomain.userValidate(user);
            bool ErrorEnDomain = respuestaUserDomain != null;
            if (ErrorEnDomain)
            {
                return respuestaUserDomain;
            }

            try
            {
                db.Usuario.Add(user);
                await db.SaveChangesAsync();

            }
            catch (Exception e)
            {
                return e.Message;
            }
            return null;
        }

    }
}