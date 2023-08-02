using Blog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ProvaApi.Db;
using System.Diagnostics;
using System.Security.Claims;

namespace ProvaApi.Controllers
{
    [ApiController]
    [Route("db")]
    public class DbController : Controller
    {
        private readonly ImodelDb db;
        public DbController(ImodelDb imodelDb) { db = imodelDb; }
       
        [HttpGet]
        [Authorize]
        [Route("getDati")]
        public async Task<IEnumerable<DDato>> getDati() {
            ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal;
            int id = Int32.Parse(principal.Claims.FirstOrDefault(s => s.Type == "id").Value);
            return await db.get(id);
        }
        [Authorize]
        [HttpPost]
        [Route("addDato")]
       
        public async void addDato(string descrizione)
        {
            ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal;
            int id = Int32.Parse(principal.Claims.FirstOrDefault(s => s.Type == "id").Value);
            Console.WriteLine("id claim"+ id);
            db.addContenuto(id, descrizione);
        }
        [HttpPost]
        [Route("addUtente")]
        public async void addUtente(string nome,string cognome)
        {
            db.addUtente(nome, cognome);
        }

        [HttpGet]
        [Route("getUtenti")]
        public async Task<IEnumerable<DPersona>> getUtenti()
        {
            return await db.getPersone();
        }
        [HttpGet]
        [Route("getClaim")]
        public IEnumerable<string> getClaim()
        {
           
            ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal;
            
            if (null != principal)
            {
                foreach (Claim claim in principal.Claims)
                {
                    yield return   ("CLAIM TYPE: " + claim.Type + "; CLAIM VALUE: " + claim.Value + "</br>");
                }
            }
            yield break;
        }


    }
}
