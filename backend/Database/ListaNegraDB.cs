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

        public void Excluir (int id)
        {
            ctx.Remove(ctx.TbListaNegra.ToList().Where(x => x.IdListaNegra == id));
        }

        public Models.TbListaNegra Alterar (int id, Models.TbListaNegra tb)
        {
            Models.TbListaNegra tbModificar =  ctx.TbListaNegra.ToList().FirstOrDefault(x => x.IdListaNegra == id);

            tbModificar.NmPessoa = tb.NmPessoa;
            tbModificar.DsMotivo = tb.DsMotivo;
            tbModificar.DsLocal = tb.DsLocal;
            tbModificar.DtInclusao = tb.DtInclusao;
            tbModificar.DsFoto = tb.DsFoto;
            ctx.SaveChanges();

            return tbModificar;

        }
    }
}