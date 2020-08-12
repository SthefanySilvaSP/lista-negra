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


        [HttpPost]
        public ActionResult<Models.Response.ListaNegraResponse> Inserir (Models.Request.ListaNegraRequest req)
        {
            try
            {
                Models.TbListaNegra tb = conversor.ToTable(req);
                business.Inserir(tb);

                return conversor.ToResponse(tb);

            }
            catch (Exception ex)
            {
                return BadRequest(new Models.ErrorResponse(400, ex));
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
                return BadRequest (new Models.ErrorResponse(500, ex));

            }
        }
    }
}