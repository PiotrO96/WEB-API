using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS4_WebApi.Shared.Models
{
    public class Zamowienie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Zamowienie_Nr { get; set; }
        public int Zamowienie_Ilosc { get; set; }
        public string Zamowienie_Sklad { get; set; }
        public string Zamowienie_Nalezy { get; set; }
    }
}
