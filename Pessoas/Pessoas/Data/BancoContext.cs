using Microsoft.EntityFrameworkCore;
using Pessoas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pessoas.Data
{
    public class BancoContext: DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }
        
        public DbSet<PessoasModel> Pessoas { get; set; }

    }
}
