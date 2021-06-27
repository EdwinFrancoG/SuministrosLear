using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using SuministrosProject.Domain;
using SuministrosProject.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace SuministrosProject.AppServices
{
    public class CategoriasAppServices
    {
        public SuministrosContext db = new SuministrosContext();
        public readonly categoriasDomain CatDomain = new categoriasDomain();

        public CategoriasAppServices()
        {
        }

        public async Task<string> IngresarCategoria(Categoria categoria)
        {
            var respuestaCatgoriaDomain = CatDomain.validarIngresoCaetegoria(categoria);
            bool ErrorEnDomain = respuestaCatgoriaDomain != null;
            if (ErrorEnDomain)
            {
                return respuestaCatgoriaDomain;
            }

            try
            {
                db.Categoria.Add(categoria);
                await db.SaveChangesAsync();

            }
            catch (Exception e)
            {
                return e.Message;                
            }
            return  null;
        }
    }
}