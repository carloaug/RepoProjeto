
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PagedList;


namespace RSistema.Models
{
    [Table("Restaurantes")]
    public class Restaurante
    {
        //  public int? Pagina { get; set; }
        public int RestauranteId { get; set; }
        [Display(Name = "Nome do Restaurante")]
        public String RestauranteNome { get; set; }
        public List<Prato> Pratos { get; set; }

        public IPagedList<Restaurante> ProcuraResultados { get; set; }
        // public string BotaoProcurar { get; set; }
      
    }
}
