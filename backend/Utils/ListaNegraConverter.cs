using System;
using System.Collections.Generic;
using System.Linq;

namespace backend.Utils
{
    public class ListaNegraConverter
    {
        public Models.TbListaNegra ToTable (Models.Request.ListaNegraRequest req) 
        {
            Models.TbListaNegra tb = new Models.TbListaNegra();

            tb.NmPessoa = req.Nome;
            tb.DsMotivo = req.Motivo;
            tb.DtInclusao = DateTime.Now;
        
            return tb;
        }

        public Models.Response.ListaNegraResponse ToResponse (Models.TbListaNegra tb) 
        {
            Models.Response.ListaNegraResponse resp = new Models.Response.ListaNegraResponse();
        
            resp.ID = tb.IdListaNegra;
            resp.Nome = tb.NmPessoa;
            resp.Motivo = tb.DsMotivo;
            resp.DataInclusao = tb.DtInclusao;

            return resp;
        } 

        public List<Models.Response.ListaNegraResponse> ToResponseMany (List<Models.TbListaNegra> tb)
        {
            List<Models.Response.ListaNegraResponse> lista = 
                tb.Select(x => new Models.Response.ListaNegraResponse()
                {
                    ID = x.IdListaNegra,
                    Nome = x.NmPessoa,
                    Motivo = x.DsMotivo,
                    DataInclusao = x.DtInclusao
                }).ToList();

            return lista;
        }
    }
}