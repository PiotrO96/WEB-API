using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS4_WebApi.Shared.Models
{
    public class Produkt
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Produkt_Nazwa { get; set; }
        public int Produkt_Cena { get; set; }
        public string Produkt_Opis { get; set; }
      
    }
}
