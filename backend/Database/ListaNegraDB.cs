using System.Collections.Generic;
using System.Linq;

namespace backend.Database
{
    public class ListaNegraDB
    {
        Models.lista_negraContext ctx = new Models.lista_negraContext();
        public Models.TbListaNegra Inserir (Models.TbListaNegra tb) 
        {
            ctx.Add(tb);
            ctx.SaveChanges();

            return tb;
        }

        public List<Models.TbListaNegra> ConsultarTodos ()
        {
            return ctx.TbListaNegra.ToList();
        }
    }
}