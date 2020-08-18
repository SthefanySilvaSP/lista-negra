using System;

namespace backend.Models.Response
{
    public class ListaNegraResponse
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Motivo { get; set; }
        public string Local { get; set; }
        public DateTime? DataInclusao { get; set; } 
        public string Foto { get; set; }
    }
}