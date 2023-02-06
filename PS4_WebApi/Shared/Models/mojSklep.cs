using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS4_WebApi.Shared.Models
{
   public class mojSklep
    {
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SklepId { get; set; }
        public string NazwaPrzedmiotu { get; set; }
        public string Zamawiajacy { get; set; }
        public int Ilosc { get; set; }
        public int CalkowitaIlosc { get; set; }
        public string Opis { get; set; }
       

    }
}
