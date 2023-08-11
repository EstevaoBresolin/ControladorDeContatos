// Banco.cs
using System.Collections.Generic;

namespace ControleContatos.Models
{
    public class Banco
    {
        public List<ContatoModel> lista { get; set; }

        public List<UsuarioModel> listaUsuario { get; set; }

       

        public Banco()
        {
            lista = new List<ContatoModel>();
            listaUsuario = new List<UsuarioModel>();
            
        }
       
    }
}
