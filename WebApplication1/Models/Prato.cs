using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RSistema.Models
{
    [Table("Pratos")]
    public class Prato
    {
        public int PratoId { get; set; }

        [Required(ErrorMessage = "O nome do prato é obrigatório", AllowEmptyStrings = false)]
        public string PratoNome { get; set; }

      /*  public object Create(Prato novoPrato)
        {
            throw new NotImplementedException();
        }
        */

        // [Required(ErrorMessage = "A descrição do produto é obrigatória", AllowEmptyStrings = false)]
        //public string Descricao { get; set; }
        [Required(ErrorMessage = "Informe o preço do prato", AllowEmptyStrings = false)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
        public decimal PratoPreco { get; set; }
      //  public string Imagem { get; set; }
        public int RestauranteId { get; set; }
        public virtual Restaurante Restaurante { get; set; }
    }
}