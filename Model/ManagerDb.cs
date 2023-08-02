using Blog.Models;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using ProvaApi.Db;

namespace ProvaApi.Model
{
    public class ManagerDb : ImodelDb

    {
        private readonly Context context;
        public ManagerDb(Context _context) {
          this.context = _context;
        }
        
        public async void addContenuto(int _idUtente, string _descrizione)
        {
            context.dato.Add(new DDato { descrizione = _descrizione, idUtente= _idUtente });
            context.SaveChanges();
        }

        public async void addUtente(string _nome, string _cognome)
        {
            DPersona p = new DPersona {nome = _nome, cognome = _cognome };
            context.persona.Add(p);
            context.SaveChanges();
        }

        public async Task<IEnumerable<DDato>?> get(int id)
        {
            return context.dato.Where(x => x.idUtente==id);

        }

        public async Task<Dictionary<int, IEnumerable<DDato>>> get()
        {
            Dictionary<int, IEnumerable<DDato>> r = new Dictionary<int, IEnumerable<DDato>>();
            foreach (DPersona p in context.persona.Include(p => p.Id))
            {

                r[p.Id] = await get(p.Id);
            }
            return r;
        }

        public async Task<int> getId(string _nome, string _cognome)
        {
            var r=context.persona.Where(x => (x.nome == _nome && x.cognome == _cognome)).FirstOrDefault();
            if (r != null)
                return r.Id;
            else
                return 0;
        }
        public async Task<IEnumerable<DPersona>> getPersone()
        {
            List<DPersona> r = new List<DPersona>();

            foreach (DPersona p in this.context.persona)
            {
                Console.WriteLine(p.nome);  
                r.Add(p);
            }
            return r;
        }
    }
}
