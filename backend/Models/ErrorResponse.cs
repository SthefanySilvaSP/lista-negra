using System;
using System.Collections.Generic;

namespace backend.Models
{
    public class ErrorResponse
    {
        public ErrorResponse(int erro, Exception mensagem )
        {
            this.Erro = erro;
            this.Mensagem = mensagem.Message;
        }

        public int Erro { get; set; }
        public string Mensagem { get; set; }
    }
}