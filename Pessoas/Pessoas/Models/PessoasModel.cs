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

        [StringLength(200)]
        public string Nome { get; set; }
        [StringLength(11)]
        public string CPF { get; set; }
              
        public bool Ativo { get; set; }
      
    }
}
