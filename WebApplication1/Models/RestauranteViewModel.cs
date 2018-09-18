using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace RSistema.Models
{

    public class RestauranteViewModel
    {
        //   public Int32 PratoId { get; set; }
        //   [Required(ErrorMessage = "O nome do prato é obrigatório", AllowEmptyStrings = false)]
     
        [Display(Name = "Nome do Restaurante")]
        public String RestauranteNome { get; set; }
     //   [Required(ErrorMessage = "Informe o preço do prato", AllowEmptyStrings = false)]
     //   [Display(Name = "Preço do Prato(R$)")]
    //    public Decimal PratoPreco { get; set; }
    //    [Required(ErrorMessage = "Selecione um restaurante", AllowEmptyStrings = false)]
    //    [Display(Name = "Nome do Restaurante")]
        public Int32 RestauranteId { get; set; }

      
    }
}