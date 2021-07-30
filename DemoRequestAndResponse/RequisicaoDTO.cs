using RestSharp;

namespace DemoRequestAndResponse
{
    public class RequisicaoDTO : Requisicao
    {
        public string UrlBase { get; set; }

        public string Recurso { get; set; }

        public Method Metodo { get; set; }

        public object Corpo { get; set; }

        public IRestResponse RequisicaoGET()
        {
            IRestRequest requisicao = new RestRequest(Recurso, Metodo);

            var executarRequisicao = new RestClient(UrlBase);

            return executarRequisicao.Execute(requisicao);
        }

        public IRestResponse RequisicaoPOST()
        {
            IRestRequest requisicao = new RestRequest(Recurso, Metodo);

            var executarRequisicao = new RestClient(UrlBase);

            requisicao.AddJsonBody(Corpo);

            return executarRequisicao.Execute(requisicao);
        }
    }
}