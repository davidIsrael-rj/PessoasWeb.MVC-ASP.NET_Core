using Pessoas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pessoas.Repositorio
{
    public interface IPessoaRepositorio
    {
        PessoasModel ListarPorId(int Id);

        List<PessoasModel> BuscarTodos();

        PessoasModel Adicionar(PessoasModel pessoas);

        PessoasModel Atualizar(PessoasModel pessoas);

        bool Apagar(int Id);

    }
}
