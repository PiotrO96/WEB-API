using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS4_WebApi.Shared.Models
{
   public class Przedmiot
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Przedmiot_Cena { get; set; }
        public string Przedmiot_Nazwa { get; set; }
        public string Przedmiot_Opis { get; set; }
    }
}
