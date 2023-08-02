
using ProvaApi.Db;

namespace Blog.Models
{
    public interface ImodelDb
    {

        public Task<IEnumerable<DDato>?> get(int id);//(descrizione)
        public Task<Dictionary<int,IEnumerable<DDato>>> get();//id utente,(titolo,descrizione)
        public void addContenuto(int idUtente,string descrizione);
        public Task<int> getId(string nome,string cognome);//id utente
        public void addUtente(string nome,string cognome);
        public Task<IEnumerable<DPersona>> getPersone();
    }
}
