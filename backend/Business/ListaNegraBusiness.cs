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
    }
}