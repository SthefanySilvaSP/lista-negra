using System;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace backend.Business
{
    public class GerenciadorFoto
    {
        public string GerarNovoNome (string nome) 
        {
            string novoNome = Guid.NewGuid().ToString();
            novoNome += Path.GetExtension(nome);
            return novoNome;
        }
        
        public void SalvarFoto(string nome, IFormFile foto) 
        {
            string path = Path.Combine(AppContext.BaseDirectory, "Storage", "Images", nome);
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                foto.CopyTo(fs);
            }
        }

        public byte[] LerFoto (string nome)
        {
            string path = Path.Combine(AppContext.BaseDirectory, "Storage", "Images", nome);
            byte[] foto = File.ReadAllBytes(path);
            
            return foto;
        }

        public string GerarContentType(string nome)
        {
            string extensao = Path.GetExtension(nome).Replace(".", "");
            string contentType = "application/" + extensao;

            return contentType;
        }
    }
}