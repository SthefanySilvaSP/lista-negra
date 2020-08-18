using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;


namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListaNegraController : ControllerBase
    {
        Utils.ListaNegraConverter conversor = new Utils.ListaNegraConverter();
        Business.ListaNegraBusiness business = new Business.ListaNegraBusiness();
        Business.GerenciadorFoto gerenciadorFoto = new Business.GerenciadorFoto();


        [HttpPost]
        public ActionResult<Models.Response.ListaNegraResponse> Inserir (Models.Request.ListaNegraRequest req)
        {
            try
            {
                Models.TbListaNegra tb = conversor.ToTable(req);
                tb.DsFoto = gerenciadorFoto.GerarNovoNome(req.Foto.FileName);

                business.Inserir(tb);
                gerenciadorFoto.SalvarFoto(tb.DsFoto, req.Foto);
                
                return conversor.ToResponse(tb);

            }
            catch (Exception ex)
            {
                return BadRequest(new Models.Response.ErrorResponse(400, ex));
            }
        }


        [HttpGet]
        public ActionResult<List<Models.Response.ListaNegraResponse>> ConsultarTodos ()
        {
            try 
            {
                List<Models.TbListaNegra> lista = business.ConsultarTodos();

                if (lista.Count == 0)
                    return NotFound();

                return conversor.ToResponseMany(lista);

            }
            catch (Exception ex)
            {
                return BadRequest (new Models.Response.ErrorResponse(500, ex));

            }
        }

        [HttpGet("foto/{nome}")]
        public ActionResult BuscarFoto (string nome)
        {
            try 
            {
                byte[] foto = gerenciadorFoto.LerFoto(nome);
                string contentType = gerenciadorFoto.GerarContentType(nome);

                return File(foto, contentType);
            }
            catch (Exception ex)
            {
                return BadRequest (new Models.Response.ErrorResponse(500, ex));

            }
        } 

        [HttpDelete("{id}")]
        
        public ActionResult<Models.Response.ListaNegraResponse> Alterar (int id, Models.Request.ListaNegraRequest req)
        {
            try 
            {
                Models.TbListaNegra tb =  conversor.ToTable(req);

                Models.TbListaNegra tbAlterado = business.Alterar(id, tb);

                return conversor.ToResponse(tbAlterado);
            }
            catch (Exception ex)
            {
                return BadRequest (new Models.Response.ErrorResponse(500, ex));
            }
        }

    }
}