using Pessoas.Data;
using Pessoas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pessoas.Repositorio
{
    public class PessoaRepositorio : IPessoaRepositorio
    {

        private readonly BancoContext _bancoContext;

        public PessoaRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public PessoasModel ListarPoId(int id)
        {
            return _bancoContext.Pessoas.FirstOrDefault(x => x.Id == id);
        }

        public PessoasModel Adicionar(PessoasModel pessoas)
        {
            
            _bancoContext.Pessoas.Add(pessoas);
            _bancoContext.SaveChanges();
            return pessoas;
        }

        public bool Apagar(int Id)
        {
            PessoasModel pessoaDB = ListarPoId(Id);

            if (pessoaDB == null) throw new System.Exception("Houve um erro na deleção do contato!");

            _bancoContext.Pessoas.Remove(pessoaDB);
            _bancoContext.SaveChanges();

            return true;
        }

        public PessoasModel Atualizar(PessoasModel pessoas)
        {
            PessoasModel pessoaDB = ListarPoId(pessoas.Id);
            if (pessoaDB == null) throw new System.Exception("Houve um erro na atualização da Pessoa ");

            pessoaDB.Nome = pessoas.Nome;
            pessoaDB.CPF = pessoas.CPF;
            pessoaDB.Ativo = pessoas.Ativo;

            _bancoContext.Pessoas.Update(pessoaDB);
            _bancoContext.SaveChanges();

            return pessoaDB;
        }

        public List<PessoasModel> BuscarTodos()
        {
            return _bancoContext.Pessoas.ToList();
        }

        public PessoasModel ListarPorId(int Id)
        {
            return _bancoContext.Pessoas.FirstOrDefault(x => x.Id == Id);
        }
    }
}
