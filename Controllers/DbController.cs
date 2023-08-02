using Blog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProvaApi.Db;

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
        [Route("getById")]
        public async Task<IEnumerable<DDato>> getData(int id) { 
            return await db.get(id);
        }
        [Authorize]
        [HttpPost]
        [Route("postDatoByid")]
       
        public async void addDato(int id,string descrizione)
        {
            db.addContenuto(id, descrizione);
        }
        [HttpPost]
        [Route("addUtente")]
        public async void addUtente(string nome,string cognome)
        {
            db.addUtente(nome, cognome);
        }

        [HttpGet]
        [Route("GetUtenti")]
        public async Task<IEnumerable<DPersona>> getUtenti()
        {
            return await db.getPersone();
        }


    }
}
