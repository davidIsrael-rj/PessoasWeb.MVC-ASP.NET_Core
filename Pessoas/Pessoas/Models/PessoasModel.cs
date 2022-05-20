using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pessoas.Models
{
    public class PessoasModel
    {    

        public int Id { get; set; }

        [Required(ErrorMessage ="Digite o Nome da Pessoa")]
        [StringLength(200)]
        public string Nome { get; set; }
        
        [Required(ErrorMessage ="Digite o CPF")]
        [StringLength(11)]
        public string CPF { get; set; }
              
        [Required(ErrorMessage ="Escolha uma opção")]
        
        public bool Ativo { get; set; }
      
    }
}
