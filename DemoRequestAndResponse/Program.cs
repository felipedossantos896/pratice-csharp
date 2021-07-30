using RestSharp;
using System;
using System.Threading.Tasks;

namespace DemoRequestAndResponse
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var urlBase = "https://jsonplaceholder.typicode.com";

            //IRestResponse resposta = RequisicaoGenerica(urlBase, "posts", Method.GET, null);

            Post post = new Post
            {
                UserId = 10,
                Title = "Teste",
                Body = "Testando 3"
            };

            RequisicaoDTO requisicaoDTO = new RequisicaoDTO
            {
                UrlBase = urlBase,
                Recurso = "posts",
                Metodo = Method.POST,
                Corpo = post
            };

            IRestResponse resposta = requisicaoDTO.RequisicaoPOST();

            if (resposta == null)
                Console.WriteLine("Erro na requisição");

            Console.WriteLine(resposta.Content);
        }
    }

    public class Post
    {
        public long UserId { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }
    }
}
