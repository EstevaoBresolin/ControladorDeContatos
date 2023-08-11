using System.Runtime.CompilerServices;

namespace ControleContatos.Models
{
    public class GeradorDeContato
    {
        Banco banco;
        ContatoModel contato;

        public GeradorDeContato(Banco _banco, ContatoModel _contato) 
        {
            banco = _banco;
            contato = _contato;
        }
        public string GerarNome()
        {
            Random random = new Random();
            string nomeAleatorio;
            int x = Convert.ToInt32(random.Next(0, 19));
            int y = Convert.ToInt32(random.Next(0, 19));
            string[] nome = { "Alice", "Miguel", "Sophia", "Arthur", "Helena", "Bernardo", "Valentina", "Heitor", "Laura", "Davi", "Isabella", "Lorenzo", "Manuela", "Théo", "Júlia", "Pedro", "Heloísa", "Gabriel", "Luiza", "Enzo" };
            string[] sobrenome = { "Silva", "Santos", "Oliveira", "Pereira", "Almeida", "Ferreira", "Rodrigues", "Gomes", "Martins", "Ribeiro", "Alves", "Lima", "Costa", "Araújo", "Monteiro", "Carvalho", "Barbosa", "Melo", "Moura", "Nascimento" };
            return nomeAleatorio = nome[x] + " " + sobrenome[y];           
        }
        public string GerarNumero()
        {
            Random random = new Random();
            int numero1 = Convert.ToInt32(random.Next(90000, 99999));
            int numero2 = Convert.ToInt32(random.Next(1000, 9999));
            string numero = numero1 + "-" + numero2;
            return numero;
        }

        public void AtualizaId()
        {
            for(int i = 0; i < banco.lista.Count; i++)
            {
                contato.Id = i;
            }
        }
        
    }
}
