using System;
using System.Collections.Generic;

namespace backend.Business
{
    public class ListaNegraBusiness
    {
        Database.ListaNegraDB db = new Database.ListaNegraDB();

        public Models.TbListaNegra Inserir (Models.TbListaNegra tb)
        {
            if (string.IsNullOrEmpty(tb.NmPessoa))
                throw new ArgumentException("O campo nome é obrigatório.");
            if(string.IsNullOrEmpty(tb.DsMotivo))
                throw new ArgumentException("O motivo é obrigatório.");
            
            return db.Inserir(tb);
        }

        public List<Models.TbListaNegra> ConsultarTodos ()
        {
            return db.ConsultarTodos();
        }

        public void Excluir (int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID inválido.");

            db.Excluir(id);
        }

        public Models.TbListaNegra Alterar (int id, Models.TbListaNegra tb)
        {
            if (id <= 0)
                throw new ArgumentException("ID inválido.");
            if (string.IsNullOrEmpty(tb.NmPessoa))
                throw new ArgumentException("O campo nome é obrigatório.");
            if(string.IsNullOrEmpty(tb.DsMotivo))
                throw new ArgumentException("O motivo é obrigatório.");
            
            return db.Alterar(id, tb);

        }
    }
}