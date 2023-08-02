using System.ComponentModel.DataAnnotations;

namespace ProvaApi.Db
{
    public class DPersona
    {
        [Key]
        public int Id { get; set; }
        public string nome { get; set; }
        public string cognome { get; set; }

    }
}
